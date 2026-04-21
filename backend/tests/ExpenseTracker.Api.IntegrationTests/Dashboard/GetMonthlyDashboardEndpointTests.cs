using System.Net.Http.Json;
using System.Text.Json;
using ExpenseTracker.Api.Endpoints.Expenses;

namespace ExpenseTracker.Api.IntegrationTests.Dashboard;

public sealed class GetMonthlyDashboardEndpointTests : IClassFixture<ExpenseTrackerApiFactory>
{
    private readonly HttpClient _client;

    public GetMonthlyDashboardEndpointTests(ExpenseTrackerApiFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetMonthlyDashboard_ReturnsAggregatedValues()
    {
        await _client.PostAsJsonAsync("/api/v1/expenses", new PostExpenseEndpoint.CreateExpenseRequest(new DateOnly(2026, 4, 21), 60m, "food", "Dinner"));

        var payload = await _client.GetFromJsonAsync<JsonElement>("/api/v1/months/2026-04/dashboard");

        Assert.Equal(60m, payload.GetProperty("totalSpent").GetDecimal());
        Assert.True(payload.GetProperty("hasExpenses").GetBoolean());
    }
}
