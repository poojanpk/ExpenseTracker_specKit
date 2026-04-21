using ExpenseTracker.Application.Abstractions;
using ExpenseTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTracker.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ExpenseTracker") ?? "Data Source=expense-tracker.db";

        services.AddDbContext<ExpenseTrackerDbContext>(options => options.UseSqlite(connectionString));
        services.AddScoped<IExpenseTrackerDbContext>(provider => provider.GetRequiredService<ExpenseTrackerDbContext>());

        return services;
    }
}
