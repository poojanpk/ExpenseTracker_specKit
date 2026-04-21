using System.Net.Http.Json;
using System.Text.Json;
using ExpenseTracker.Api.Endpoints.Expenses;

namespace ExpenseTracker.Api.IntegrationTests.Expenses;

public sealed class GetMonthlyExpensesEndpointTests : IClassFixture<ExpenseTrackerApiFactory>
{
    private readonly HttpClient _client;

    public GetMonthlyExpensesEndpointTests(ExpenseTrackerApiFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetMonthlyExpenses_ReturnsOnlyRequestedMonth()
    {
        await _client.PostAsJsonAsync("/api/v1/expenses", new PostExpenseEndpoint.CreateExpenseRequest(new DateOnly(2026, 4, 1), 10m, "food", null));
        await _client.PostAsJsonAsync("/api/v1/expenses", new PostExpenseEndpoint.CreateExpenseRequest(new DateOnly(2026, 3, 1), 20m, "food", null));

        var payload = await _client.GetFromJsonAsync<JsonElement>("/api/v1/months/2026-04/expenses");

        Assert.Equal("2026-04", payload.GetProperty("monthKey").GetString());
        Assert.Single(payload.GetProperty("items").EnumerateArray());
    }
}