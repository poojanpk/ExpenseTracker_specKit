using ExpenseTracker.Application.Expenses.CreateExpense;
using FluentValidation;

namespace ExpenseTracker.Application.UnitTests.Expenses;

public sealed class CreateExpenseHandlerTests
{
    [Fact]
    public async Task HandleAsync_CreatesExpenseWithDerivedMonthKey()
    {
        await using var context = TestExpenseTrackerDbContextFactory.CreateContext();
        var handler = new CreateExpenseHandler(context, new CreateExpenseValidator());

        var result = await handler.HandleAsync(
            CreateExpenseCommand.Create(new DateOnly(2026, 4, 21), 125.50m, "food", "Lunch"),
            CancellationToken.None);

        Assert.Equal("2026-04", result.MonthKey);
        Assert.Equal(125.50m, result.Amount);
        Assert.Equal("food", result.CategoryCode);
    }

    [Fact]
    public async Task HandleAsync_ThrowsValidationExceptionWhenCategoryMissing()
    {
        await using var context = TestExpenseTrackerDbContextFactory.CreateContext();
        var handler = new CreateExpenseHandler(context, new CreateExpenseValidator());

        await Assert.ThrowsAsync<ValidationException>(() => handler.HandleAsync(
            CreateExpenseCommand.Create(new DateOnly(2026, 4, 21), 32m, "missing", null),
            CancellationToken.None));
    }
}
