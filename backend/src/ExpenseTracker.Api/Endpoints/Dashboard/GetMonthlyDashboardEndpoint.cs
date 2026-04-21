using ExpenseTracker.Application.Dashboard.GetMonthlyDashboard;

namespace ExpenseTracker.Api.Endpoints.Dashboard;

public static class GetMonthlyDashboardEndpoint
{
    public static IEndpointRouteBuilder MapMonthlyDashboardEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/v1/months/{monthKey}/dashboard", async (string monthKey, GetMonthlyDashboardHandler handler, CancellationToken cancellationToken) =>
            {
                var response = await handler.HandleAsync(new GetMonthlyDashboardQuery(monthKey), cancellationToken);
                return Results.Ok(response);
            })
            .WithName("GetMonthlyDashboard")
            .WithSummary("Get monthly dashboard summary")
            .Produces<MonthlyDashboardDto>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest);

        return endpoints;
    }
}