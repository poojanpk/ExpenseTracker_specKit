using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using ExpenseTracker.Api.Endpoints.Expenses;

namespace ExpenseTracker.Api.IntegrationTests.Expenses;

public sealed class PostExpenseEndpointTests : IClassFixture<ExpenseTrackerApiFactory>
{
    private readonly HttpClient _client;

    public PostExpenseEndpointTests(ExpenseTrackerApiFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task PostExpense_ReturnsCreatedExpense()
    {
        var response = await _client.PostAsJsonAsync("/api/v1/expenses", new PostExpenseEndpoint.CreateExpenseRequest(new DateOnly(2026, 4, 21), 89.99m, "food", "Lunch"));

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var payload = await response.Content.ReadFromJsonAsync<JsonElement>();
        Assert.Equal("2026-04", payload.GetProperty("monthKey").GetString());
    }
}
