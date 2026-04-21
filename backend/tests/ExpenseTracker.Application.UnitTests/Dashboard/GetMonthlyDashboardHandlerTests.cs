using ExpenseTracker.Application.Dashboard.GetMonthlyDashboard;
using ExpenseTracker.Domain.Expenses;

namespace ExpenseTracker.Application.UnitTests.Dashboard;

public sealed class GetMonthlyDashboardHandlerTests
{
    [Fact]
    public async Task HandleAsync_ReturnsAggregatedDashboardSummary()
    {
        await using var context = TestExpenseTrackerDbContextFactory.CreateContext();
        context.AddExpense(ExpenseEntry.Create(new DateOnly(2026, 4, 1), 50m, "food", null));
        context.AddExpense(ExpenseEntry.Create(new DateOnly(2026, 4, 2), 75m, "transport", null));
        await context.SaveChangesAsync();

        var handler = new GetMonthlyDashboardHandler(context);

        var result = await handler.HandleAsync(new GetMonthlyDashboardQuery("2026-04"), CancellationToken.None);

        Assert.True(result.HasExpenses);
        Assert.Equal(125m, result.TotalSpent);
        Assert.Equal(2, result.ExpenseCount);
        Assert.Equal(2, result.CategoryBreakdown.Count);
    }
}
