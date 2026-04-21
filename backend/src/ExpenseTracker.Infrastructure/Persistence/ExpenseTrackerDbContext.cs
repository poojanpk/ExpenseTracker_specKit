using ExpenseTracker.Application.Abstractions;
using ExpenseTracker.Domain.Expenses;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Persistence;

public sealed class ExpenseTrackerDbContext(DbContextOptions<ExpenseTrackerDbContext> options)
    : DbContext(options), IExpenseTrackerDbContext
{
    public DbSet<ExpenseEntry> ExpenseEntries => Set<ExpenseEntry>();

    public DbSet<ExpenseCategory> ExpenseCategories => Set<ExpenseCategory>();

    public IQueryable<ExpenseEntry> Expenses => ExpenseEntries.AsQueryable();

    public IQueryable<ExpenseCategory> Categories => ExpenseCategories.AsQueryable();

    public void AddExpense(ExpenseEntry expense) => ExpenseEntries.Add(expense);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExpenseTrackerDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
