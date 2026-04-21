using ExpenseTracker.Domain.ValueObjects;

namespace ExpenseTracker.Domain.Expenses;

public sealed class ExpenseEntry
{
    private ExpenseEntry()
    {
    }

    private ExpenseEntry(Guid id, DateOnly expenseDate, decimal amount, string categoryCode, string? note, DateTimeOffset createdAt)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than zero.");
        }

        if (string.IsNullOrWhiteSpace(categoryCode))
        {
            throw new ArgumentException("Category code is required.", nameof(categoryCode));
        }

        Id = id;
        ExpenseDate = expenseDate;
        MonthKey = ValueObjects.MonthKey.FromDate(expenseDate).Value;
        Amount = decimal.Round(amount, 2, MidpointRounding.AwayFromZero);
        CategoryCode = categoryCode.Trim();
        Note = string.IsNullOrWhiteSpace(note) ? null : note.Trim();
        CreatedAt = createdAt;
    }

    public Guid Id { get; private set; }

    public DateOnly ExpenseDate { get; private set; }

    public string MonthKey { get; private set; } = string.Empty;

    public decimal Amount { get; private set; }

    public string CategoryCode { get; private set; } = string.Empty;

    public string? Note { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }

    public static ExpenseEntry Create(DateOnly expenseDate, decimal amount, string categoryCode, string? note, DateTimeOffset? createdAt = null)
        => new(Guid.CreateVersion7(), expenseDate, amount, categoryCode, note, createdAt ?? DateTimeOffset.UtcNow);
}
