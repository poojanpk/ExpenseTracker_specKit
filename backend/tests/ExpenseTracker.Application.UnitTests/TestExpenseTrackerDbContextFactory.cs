using ExpenseTracker.Infrastructure.Persistence;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Application.UnitTests;

internal static class TestExpenseTrackerDbContextFactory
{
    public static ExpenseTrackerDbContext CreateContext()
    {
        var connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<ExpenseTrackerDbContext>()
            .UseSqlite(connection)
            .Options;

        var context = new ExpenseTrackerDbContext(options);
        context.Database.EnsureCreated();
        return context;
    }
}
