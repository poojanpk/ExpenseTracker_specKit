using ExpenseTracker.Application.Categories.ListCategories;
using ExpenseTracker.Application.Dashboard.GetMonthlyDashboard;
using ExpenseTracker.Application.Expenses.CreateExpense;
using ExpenseTracker.Application.Expenses.GetMonthlyExpenses;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTracker.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreateExpenseValidator>();

        services.AddScoped<ListCategoriesHandler>();
        services.AddScoped<CreateExpenseHandler>();
        services.AddScoped<GetMonthlyDashboardHandler>();
        services.AddScoped<GetMonthlyExpensesHandler>();

        return services;
    }
}
