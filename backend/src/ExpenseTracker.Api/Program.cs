using ExpenseTracker.Api.Endpoints.Categories;
using ExpenseTracker.Api.Endpoints.Dashboard;
using ExpenseTracker.Api.Endpoints.Expenses;
using ExpenseTracker.Api.Middleware;
using ExpenseTracker.Application;
using ExpenseTracker.Infrastructure;
using ExpenseTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddProblemDetails();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials(); // only if using cookies/auth
        });
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseCors("AllowFrontend");
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

await using (var scope = app.Services.CreateAsyncScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ExpenseTrackerDbContext>();
    await dbContext.Database.MigrateAsync();
}

app.MapGet("/", () => Results.Ok(new { status = "ok", service = "expense-tracker-api" }));
app.MapCategoryEndpoints();
app.MapPostExpenseEndpoint();
app.MapMonthlyExpensesEndpoint();
app.MapMonthlyDashboardEndpoint();

app.Run();

public partial class Program;
