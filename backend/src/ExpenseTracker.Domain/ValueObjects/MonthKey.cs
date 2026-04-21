using System.Globalization;

namespace ExpenseTracker.Domain.ValueObjects;

public readonly record struct MonthKey
{
    public MonthKey(int year, int month)
    {
        if (year < 2000 || year > 2100)
        {
            throw new ArgumentOutOfRangeException(nameof(year), "Year must be between 2000 and 2100.");
        }

        if (month is < 1 or > 12)
        {
            throw new ArgumentOutOfRangeException(nameof(month), "Month must be between 1 and 12.");
        }

        Year = year;
        Month = month;
    }

    public int Year { get; }

    public int Month { get; }

    public string Value => $"{Year:D4}-{Month:D2}";

    public static MonthKey FromDate(DateOnly date) => new(date.Year, date.Month);

    public static MonthKey Parse(string value)
    {
        if (!TryParse(value, out var result))
        {
            throw new FormatException("Month key must use yyyy-MM format.");
        }

        return result;
    }

    public static bool TryParse(string? value, out MonthKey result)
    {
        result = default;

        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        if (!DateOnly.TryParseExact($"{value}-01", "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
        {
            return false;
        }

        result = FromDate(date);
        return true;
    }

    public MonthKey Previous()
    {
        var date = new DateOnly(Year, Month, 1).AddMonths(-1);
        return FromDate(date);
    }

    public MonthKey Next()
    {
        var date = new DateOnly(Year, Month, 1).AddMonths(1);
        return FromDate(date);
    }

    public override string ToString() => Value;
}
