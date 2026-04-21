using ExpenseTracker.Application.Expenses.CreateExpense;

namespace ExpenseTracker.Api.Endpoints.Expenses;

public static class PostExpenseEndpoint
{
    public sealed record CreateExpenseRequest(DateOnly ExpenseDate, decimal Amount, string CategoryCode, string? Note);

    public static IEndpointRouteBuilder MapPostExpenseEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/api/v1/expenses", async (CreateExpenseRequest request, CreateExpenseHandler handler, CancellationToken cancellationToken) =>
            {
                var command = CreateExpenseCommand.Create(request.ExpenseDate, request.Amount, request.CategoryCode, request.Note);
                var expense = await handler.HandleAsync(command, cancellationToken);
                return Results.Created($"/api/v1/months/{expense.MonthKey}/expenses", expense);
            })
            .WithName("CreateExpense")
            .WithSummary("Create a new expense entry")
            .Produces<ExpenseEntryDto>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest);

        return endpoints;
    }
}
