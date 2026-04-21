using ExpenseTracker.Application.Expenses.GetMonthlyExpenses;

namespace ExpenseTracker.Api.Endpoints.Expenses;

public static class GetMonthlyExpensesEndpoint
{
    public static IEndpointRouteBuilder MapMonthlyExpensesEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/v1/months/{monthKey}/expenses", async (string monthKey, GetMonthlyExpensesHandler handler, CancellationToken cancellationToken) =>
            {
                var response = await handler.HandleAsync(new GetMonthlyExpensesQuery(monthKey), cancellationToken);
                return Results.Ok(response);
            })
            .WithName("GetMonthlyExpenses")
            .WithSummary("List expenses for a selected month")
            .Produces<MonthlyExpenseListDto>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest);

        return endpoints;
    }
}
