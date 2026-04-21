namespace ExpenseTracker.Application.Expenses.CreateExpense;

public sealed record CreateExpenseCommand(DateOnly ExpenseDate, decimal Amount, string CategoryCode, string? Note)
{
    public static CreateExpenseCommand Create(DateOnly expenseDate, decimal amount, string categoryCode, string? note)
        => new(expenseDate, amount, categoryCode, note);
}

public sealed record ExpenseEntryDto(
    Guid Id,
    DateOnly ExpenseDate,
    string MonthKey,
    decimal Amount,
    string CategoryCode,
    string? Note,
    DateTimeOffset CreatedAt);
