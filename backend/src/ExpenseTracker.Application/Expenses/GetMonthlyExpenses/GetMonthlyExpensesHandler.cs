using ExpenseTracker.Application.Abstractions;

namespace ExpenseTracker.Application.Expenses.GetMonthlyExpenses;

public sealed class GetMonthlyExpensesHandler(IExpenseTrackerDbContext dbContext)
{
    public async Task<MonthlyExpenseListDto> HandleAsync(GetMonthlyExpensesQuery query, CancellationToken cancellationToken)
    {
        var monthKey = query.ParsedMonthKey.Value;
        cancellationToken.ThrowIfCancellationRequested();

        var items = dbContext.Expenses
            .Where(expense => expense.MonthKey == monthKey)
            .Join(
                dbContext.Categories,
                expense => expense.CategoryCode,
                category => category.Code,
                (expense, category) => new
                {
                    expense.Id,
                    expense.ExpenseDate,
                    expense.MonthKey,
                    expense.Amount,
                    expense.CategoryCode,
                    CategoryName = category.Name,
                    expense.Note,
                    expense.CreatedAt,
                })
            .ToList();

        var orderedItems = items
            .OrderByDescending(expense => expense.ExpenseDate)
            .ThenByDescending(expense => expense.CreatedAt)
            .Select(expense => new MonthlyExpenseItemDto(
                expense.Id,
                expense.ExpenseDate,
                expense.MonthKey,
                expense.Amount,
                expense.CategoryCode,
                expense.CategoryName,
                expense.Note,
                expense.CreatedAt))
            .ToList();

        return new MonthlyExpenseListDto(monthKey, orderedItems);
    }
}
