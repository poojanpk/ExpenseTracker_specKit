using ExpenseTracker.Application.Abstractions;

namespace ExpenseTracker.Application.Dashboard.GetMonthlyDashboard;

public sealed class GetMonthlyDashboardHandler(IExpenseTrackerDbContext dbContext)
{
    public async Task<MonthlyDashboardDto> HandleAsync(GetMonthlyDashboardQuery query, CancellationToken cancellationToken)
    {
        var monthKey = query.ParsedMonthKey.Value;
        cancellationToken.ThrowIfCancellationRequested();

        var expenseItems = dbContext.Expenses
            .Where(expense => expense.MonthKey == monthKey)
            .Join(
                dbContext.Categories,
                expense => expense.CategoryCode,
                category => category.Code,
                (expense, category) => new { expense.Amount, category.Code, category.Name, category.ColorToken })
            .ToList();

        var categoryBreakdown = expenseItems
            .GroupBy(item => new { item.Code, item.Name, item.ColorToken })
            .Select(group => new CategorySummaryDto(
                group.Key.Code,
                group.Key.Name,
                decimal.Round(group.Sum(entry => entry.Amount), 2, MidpointRounding.AwayFromZero),
                group.Count(),
                group.Key.ColorToken))
            .OrderByDescending(item => item.TotalSpent)
            .ThenBy(item => item.CategoryName)
            .ToList();

        var totalSpent = categoryBreakdown.Sum(item => item.TotalSpent);
        var expenseCount = categoryBreakdown.Sum(item => item.ExpenseCount);

        return new MonthlyDashboardDto(monthKey, totalSpent, expenseCount, expenseCount > 0, categoryBreakdown);
    }
}