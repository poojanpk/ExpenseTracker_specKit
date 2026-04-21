using ExpenseTracker.Domain.Expenses;

namespace ExpenseTracker.Domain.UnitTests;

public sealed class ExpenseEntryTests
{
    [Fact]
    public void Create_SetsMonthKeyFromExpenseDate()
    {
        var entry = ExpenseEntry.Create(new DateOnly(2026, 4, 21), 150m, "food", "Groceries");

        Assert.Equal("2026-04", entry.MonthKey);
        Assert.Equal(150m, entry.Amount);
    }

    [Fact]
    public void Create_ThrowsWhenAmountIsNotPositive()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => ExpenseEntry.Create(new DateOnly(2026, 4, 21), 0m, "food", null));
    }
}
