using ExpenseTracker.Domain.ValueObjects;

namespace ExpenseTracker.Application.Dashboard.GetMonthlyDashboard;

public sealed record GetMonthlyDashboardQuery(string MonthKey)
{
    public MonthKey ParsedMonthKey => global::ExpenseTracker.Domain.ValueObjects.MonthKey.Parse(MonthKey);
}

public sealed record MonthlyDashboardDto(
    string MonthKey,
    decimal TotalSpent,
    int ExpenseCount,
    bool HasExpenses,
    IReadOnlyList<CategorySummaryDto> CategoryBreakdown);

public sealed record CategorySummaryDto(
    string CategoryCode,
    string CategoryName,
    decimal TotalSpent,
    int ExpenseCount,
    string ColorToken);
