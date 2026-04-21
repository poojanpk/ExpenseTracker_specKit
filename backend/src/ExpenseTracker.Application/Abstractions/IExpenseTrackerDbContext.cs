using ExpenseTracker.Domain.Expenses;

namespace ExpenseTracker.Application.Abstractions;

public interface IExpenseTrackerDbContext
{
    IQueryable<ExpenseEntry> Expenses { get; }

    IQueryable<ExpenseCategory> Categories { get; }

    void AddExpense(ExpenseEntry expense);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
