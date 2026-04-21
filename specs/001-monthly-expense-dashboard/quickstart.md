# Quickstart: Monthly Expense Dashboard

## Prerequisites

- .NET 10 SDK
- Node.js 22+ and npm
- Git

## Planned Repository Layout

- `backend/` for the .NET 10 Web API solution
- `frontend/` for the React + TypeScript application

## Backend Setup

```powershell
cd backend
dotnet restore
dotnet build
dotnet test
```

## Frontend Setup

```powershell
cd frontend
npm install
npm run build
npm run test
```

## Database Setup

```powershell
cd backend
dotnet ef database update
```

## Run the Application

Start the backend:

```powershell
cd backend
dotnet run --project .\src\ExpenseTracker.Api
```

Start the frontend in a second terminal:

```powershell
cd frontend
npm run dev
```

## Expected User Flow

1. Open the application to the current month dashboard.
2. Use the month selector to move between current and previous months.
3. Add a new expense from the primary action area.
4. Confirm the expense appears in the selected month list and updates the dashboard totals.

## Quality Checks

Backend:

```powershell
cd backend
dotnet format
dotnet test
```

Frontend:

```powershell
cd frontend
npm run lint
npm run test
npm run test:e2e
```