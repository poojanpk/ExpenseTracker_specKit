using ExpenseTracker.Application.Categories.ListCategories;

namespace ExpenseTracker.Api.Endpoints.Categories;

public static class GetCategoriesEndpoint
{
    public static IEndpointRouteBuilder MapCategoryEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/v1/categories", async (ListCategoriesHandler handler, CancellationToken cancellationToken) =>
            {
                var items = await handler.HandleAsync(new ListCategoriesQuery(), cancellationToken);
                return Results.Ok(new { items });
            })
            .WithName("ListCategories")
            .WithSummary("List predefined expense categories")
            .Produces(StatusCodes.Status200OK);

        return endpoints;
    }
}
