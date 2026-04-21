using ExpenseTracker.Domain.ValueObjects;

namespace ExpenseTracker.Application.Expenses.GetMonthlyExpenses;

public sealed record GetMonthlyExpensesQuery(string MonthKey)
{
    public MonthKey ParsedMonthKey => global::ExpenseTracker.Domain.ValueObjects.MonthKey.Parse(MonthKey);
}

public sealed record MonthlyExpenseListDto(string MonthKey, IReadOnlyList<MonthlyExpenseItemDto> Items);

public sealed record MonthlyExpenseItemDto(
    Guid Id,
    DateOnly ExpenseDate,
    string MonthKey,
    decimal Amount,
    string CategoryCode,
    string CategoryName,
    string? Note,
    DateTimeOffset CreatedAt);
