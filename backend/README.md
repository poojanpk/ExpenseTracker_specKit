# ExpenseTracker Backend

ASP.NET Core Web API backend for tracking expenses, listing monthly expenses, and generating monthly dashboard summaries.

## Created with Spec-Kit

This backend was scaffolded and evolved using a Spec-Kit workflow.

- Specification folder: `specs/001-monthly-expense-dashboard`
- Active feature branch: `001-monthly-expense-dashboard`

## Tech Stack

- `.NET 10`
- ASP.NET Core Minimal APIs
- Entity Framework Core
- SQLite (`expense-tracker.db`)
- FluentValidation
- OpenAPI (in Development)

## Solution Structure

- `src/ExpenseTracker.Api` — API host, endpoint mapping, middleware
- `src/ExpenseTracker.Application` — use-case handlers, DTOs, validation
- `src/ExpenseTracker.Domain` — domain entities and value objects
- `src/ExpenseTracker.Infrastructure` — EF Core persistence, migrations, seed data
- `tests/ExpenseTracker.Domain.UnitTests` — domain unit tests
- `tests/ExpenseTracker.Application.UnitTests` — application unit tests
- `tests/ExpenseTracker.Api.IntegrationTests` — API integration tests

## Functional Scope

- Predefined expense categories
- Create expense entries
- List expenses by month
- Monthly dashboard summary with category breakdown

## API Endpoints

- `GET /` — health/status
- `GET /api/v1/categories` — list predefined categories
- `POST /api/v1/expenses` — create expense entry
- `GET /api/v1/months/{monthKey}/expenses` — list monthly expenses
- `GET /api/v1/months/{monthKey}/dashboard` — monthly totals and category summary

### `POST /api/v1/expenses` request body

```json
{
  "expenseDate": "2026-04-21",
  "amount": 42.50,
  "categoryCode": "food",
  "note": "Lunch"
}
```

## Important Rules

- `monthKey` format: `yyyy-MM` (example: `2026-04`)
- Supported `monthKey` year range: `2000` to `2100`
- `amount` must be greater than `0`
- `categoryCode` is required (max length `50`)
- `note` max length `250`

## Seeded Categories

- `housing`
- `food`
- `transport`
- `utilities`
- `health`
- `shopping`
- `entertainment`
- `other`

## Prerequisites

- .NET SDK `10.0+`

## Local Development

### Build

```bash
dotnet build
```

### Run API

```bash
dotnet run --project src/ExpenseTracker.Api
```

### OpenAPI (Development only)

After running locally, OpenAPI is available from the app's OpenAPI route.

### Run Tests

```bash
dotnet test
```

## Notes

- SQLite database file is configured via `ConnectionStrings:ExpenseTracker` in `src/ExpenseTracker.Api/appsettings.json`.
- EF Core migrations are applied automatically on startup.
