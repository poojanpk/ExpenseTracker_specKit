# Expense Tracker

A full-stack expense tracking application built with .NET and React, allowing users to record monthly expenses and view dashboard summaries across different time periods.

## 🚀 Project Overview

Expense Tracker helps users manage their monthly spending by:
- Recording expense entries with amounts, dates, categories, and notes
- Viewing monthly dashboard summaries with category breakdowns
- Navigating between months to review historical spending patterns

This project was built using a **Spec-Kit workflow**, with specifications driving development through structured feature planning and iterative implementation.

## 🏗️ Architecture

This is a monorepo containing three main components:

```
specDemo/
├── backend/          # .NET 10 Web API
├── frontend/         # React + TypeScript + Vite
└── specs/            # Feature specifications and planning
```

### Backend Stack

- **.NET 10** - ASP.NET Core Minimal APIs
- **Entity Framework Core** - ORM with SQLite database
- **FluentValidation** - Request validation
- **Clean Architecture** - Domain, Application, Infrastructure, API layers
- **OpenAPI** - API documentation (development mode)

### Frontend Stack

- **React 18** - UI framework
- **TypeScript** - Type-safe development
- **Vite** - Fast build tooling
- **Tailwind CSS** - Utility-first styling
- **React Query (TanStack Query)** - Data fetching and caching
- **Vitest** - Component testing
- **Playwright** - End-to-end testing

## 📋 Features

### Current Functionality (v1)

- ✅ Predefined expense categories (housing, food, transport, utilities, health, shopping, entertainment, other)
- ✅ Create expense entries with amount, date, category, and optional notes
- ✅ List expenses filtered by month
- ✅ Monthly dashboard with total spending and category breakdowns
- ✅ Month navigation to view current and previous months
- ✅ Form validation and error handling

## 🚦 Getting Started

### Prerequisites

- [.NET SDK 10.0+](https://dotnet.microsoft.com/download)
- [Node.js 18+](https://nodejs.org/)
- [npm](https://www.npmjs.com/) or [yarn](https://yarnpkg.com/)

### Quick Start

#### 1. Clone the repository

```bash
git clone <repository-url>
cd specDemo
```

#### 2. Start the Backend

```bash
cd backend
dotnet restore
dotnet build
dotnet run --project src/ExpenseTracker.Api
```

The API will be available at `https://localhost:7001` (or `http://localhost:5000`)

#### 3. Start the Frontend

In a new terminal:

```bash
cd frontend
npm install
npm run dev
```

The application will be available at `http://localhost:5173`

### Database Setup

The SQLite database (`expense-tracker.db`) is automatically created and seeded with categories on first run. No manual migration is required for local development.

#### Running Migrations Manually

If you need to manage migrations:

```bash
cd backend
dotnet ef migrations add <MigrationName> --project src/ExpenseTracker.Infrastructure --startup-project src/ExpenseTracker.Api
dotnet ef database update --project src/ExpenseTracker.Infrastructure --startup-project src/ExpenseTracker.Api
```

> **Note**: EF Core tools are installed as a local dotnet tool. The manifest is in `backend/dotnet-tools.json`.

## 🧪 Testing

### Backend Tests

```bash
cd backend

# Run all tests
dotnet test

# Run specific test project
dotnet test tests/ExpenseTracker.Domain.UnitTests
dotnet test tests/ExpenseTracker.Application.UnitTests
dotnet test tests/ExpenseTracker.Api.IntegrationTests
```

Test categories:
- **Domain Unit Tests** - Entity and value object validation
- **Application Unit Tests** - Use case handler logic
- **API Integration Tests** - End-to-end API workflow testing

### Frontend Tests

```bash
cd frontend

# Run component tests
npm run test

# Run component tests in watch mode
npm run test:watch

# Run e2e tests
npm run test:e2e

# Run e2e tests in UI mode
npm run test:e2e:ui
```

Test structure:
- **Component Tests** (`tests/component/`) - Vitest + React Testing Library
- **E2E Tests** (`tests/e2e/`) - Playwright browser automation

> **Note**: E2E tests are excluded from Vitest configuration and run separately with Playwright.

## 📁 Project Structure

### Backend (`backend/`)

```
backend/
├── src/
│   ├── ExpenseTracker.Api/              # API host, endpoints, middleware
│   ├── ExpenseTracker.Application/      # Use cases, DTOs, validation
│   ├── ExpenseTracker.Domain/           # Entities and value objects
│   └── ExpenseTracker.Infrastructure/   # EF Core, persistence, migrations
└── tests/
    ├── ExpenseTracker.Domain.UnitTests/
    ├── ExpenseTracker.Application.UnitTests/
    └── ExpenseTracker.Api.IntegrationTests/
```

### Frontend (`frontend/`)

```
frontend/
├── src/
│   ├── app/                  # App configuration, router, query client
│   ├── components/           # Reusable UI components
│   ├── features/             # Feature-specific components
│   │   ├── dashboard/
│   │   ├── expenses/
│   │   └── month-selector/
│   ├── lib/                  # Utilities
│   ├── routes/               # Route components
│   └── services/             # API client
└── tests/
    ├── component/            # Component tests
    └── e2e/                  # End-to-end tests
```

### Specifications (`specs/`)

```
specs/
└── 001-monthly-expense-dashboard/
    ├── spec.md              # Feature specification
    ├── plan.md              # Implementation plan
    ├── tasks.md             # Task breakdown
    ├── contracts/           # API contracts
    ├── checklists/          # QA checklists
    └── ...
```

## 🔌 API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/` | Health check |
| `GET` | `/api/v1/categories` | List all expense categories |
| `POST` | `/api/v1/expenses` | Create a new expense entry |
| `GET` | `/api/v1/months/{monthKey}/expenses` | Get expenses for a specific month |
| `GET` | `/api/v1/months/{monthKey}/dashboard` | Get dashboard summary for a month |

### Example: Create Expense

```bash
POST /api/v1/expenses
Content-Type: application/json

{
  "expenseDate": "2026-04-21",
  "amount": 42.50,
  "categoryCode": "food",
  "note": "Lunch at downtown café"
}
```

**Month Key Format**: `yyyy-MM` (e.g., `2026-04`)  
**Supported Range**: Years 2000-2100

## 🛠️ Development Workflow

This project follows a **Spec-Kit workflow**:

1. **Specification** - Feature requirements documented in `specs/`
2. **Planning** - Implementation plan with tasks and contracts
3. **Development** - Iterative implementation guided by specs
4. **Testing** - Unit, integration, and e2e tests validate requirements
5. **Review** - Checklists ensure completeness

### Working with Specs

Each feature has its own folder in `specs/` containing:
- `spec.md` - User stories, requirements, success criteria
- `plan.md` - Technical implementation approach
- `tasks.md` - Actionable development tasks
- `contracts/` - API request/response examples
- `checklists/` - Testing and completion verification

## 🔑 Key Conventions

### Backend

- Solution file format: `ExpenseTracker.slnx` (modern slim solution format)
- Database: SQLite with file `expense-tracker.db`
- CORS enabled for `http://localhost:5173`
- OpenAPI available in development mode only
- Categories are predefined and seeded at startup

### Frontend

- Month keys use `yyyy-MM` format for API communication
- Local date handling to ensure correct month assignment
- React Query for caching and data synchronization
- Tailwind CSS with custom design tokens

## 📝 Environment Variables

### Backend

Configure in `appsettings.json` or `appsettings.Development.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=expense-tracker.db"
  }
}
```

### Frontend

Create `.env` file in `frontend/` directory:

```env
VITE_API_BASE_URL=http://localhost:5000
```

## 🤝 Contributing

1. Check the `specs/` folder for planned features
2. Create a feature branch from `main`
3. Follow the existing code structure and conventions
4. Add/update tests for new functionality
5. Ensure all tests pass before submitting
6. Update relevant documentation

## 📄 License

[Add your license here]

## 🙏 Acknowledgments

Built with the Spec-Kit methodology for specification-driven development.

---

**Current Version**: 1.0  
**Last Updated**: April 2026
