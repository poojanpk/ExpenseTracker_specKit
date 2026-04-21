using ExpenseTracker.Application.Expenses.GetMonthlyExpenses;
using ExpenseTracker.Domain.Expenses;

namespace ExpenseTracker.Application.UnitTests.Expenses;

public sealed class GetMonthlyExpensesHandlerTests
{
    [Fact]
    public async Task HandleAsync_ReturnsOnlyExpensesForRequestedMonth()
    {
        await using var context = TestExpenseTrackerDbContextFactory.CreateContext();
        context.AddExpense(ExpenseEntry.Create(new DateOnly(2026, 4, 20), 99m, "food", "Dinner"));
        context.AddExpense(ExpenseEntry.Create(new DateOnly(2026, 3, 20), 44m, "food", "Old"));
        await context.SaveChangesAsync();

        var handler = new GetMonthlyExpensesHandler(context);

        var result = await handler.HandleAsync(new GetMonthlyExpensesQuery("2026-04"), CancellationToken.None);

        Assert.Single(result.Items);
        Assert.Equal("2026-04", result.Items[0].MonthKey);
    }
}
