using ExpenseTracker.Domain.ValueObjects;

namespace ExpenseTracker.Domain.UnitTests;

public sealed class MonthKeyTests
{
    [Fact]
    public void Parse_ReturnsFormattedMonthKey()
    {
        var monthKey = MonthKey.Parse("2026-04");

        Assert.Equal(2026, monthKey.Year);
        Assert.Equal(4, monthKey.Month);
        Assert.Equal("2026-04", monthKey.Value);
    }

    [Fact]
    public void Previous_ReturnsPreviousCalendarMonth()
    {
        var previous = new MonthKey(2026, 1).Previous();

        Assert.Equal("2025-12", previous.Value);
    }
}
