# Implementation Plan: Monthly Expense Dashboard

**Branch**: `[001-monthly-expense-dashboard]` | **Date**: 2026-04-21 | **Spec**: [spec.md](./spec.md)
**Input**: Feature specification from `/specs/001-monthly-expense-dashboard/spec.md`

## Summary

Build a responsive monthly expense tracker as a web application with a .NET 10 layered API backend and a React frontend. The backend will expose contract-first REST endpoints for categories, monthly expense creation, monthly expense retrieval, and dashboard summaries. The frontend will emphasize an attractive, highly usable dashboard-first experience with Tailwind CSS, accessible form patterns, clear empty states, and fast month-to-month navigation.

## Technical Context

**Language/Version**: C# with .NET 10, TypeScript 5.x, React 19.x  
**Primary Dependencies**: ASP.NET Core 10 Web API, EF Core 10, SQLite, React, Vite, Tailwind CSS 4, React Router, TanStack Query, React Hook Form  
**Storage**: SQLite with EF Core migrations for the initial single-user MVP  
**Testing**: xUnit + integration tests with `Microsoft.AspNetCore.Mvc.Testing`; Vitest + React Testing Library; Playwright smoke coverage for core flows  
**Target Platform**: Responsive web app for modern desktop and mobile browsers  
**Project Type**: Full-stack web application  
**Performance Goals**: Month switch and dashboard refresh complete within 2 seconds for 95% of requests; expense submission completes in under 1 second server time under normal single-user load  
**Constraints**: Must remain easy to use, visually attractive, accessible, and responsive; must use thin API controllers, server-authoritative validation, fixed predefined categories, and no hardcoded secrets  
**Scale/Scope**: Initial release targets a single personal-user dataset, up to 10,000 expense records, monthly views across multiple years, and one dashboard experience plus one expense entry flow

## Constitution Check

*GATE: Must pass before Phase 0 research. Re-check after Phase 1 design.*

- `PASS` Layered architecture preserved by splitting backend into API, Application, Domain, and Infrastructure projects.
- `PASS` API contract-first approach satisfied through an explicit OpenAPI contract under `contracts/openapi.yaml` before implementation.
- `PASS` Quality gates covered through planned backend unit/integration tests, frontend component tests, and end-to-end smoke verification.
- `PASS` Security and validation handled through server-side validation, client-side assistive validation, problem-details error responses, and structured backend logging.
- `PASS` Simplicity maintained by choosing a modular monolith with SQLite for MVP instead of premature distributed services or multi-tenant complexity.

## Research Summary

- Use a modular monolith backend in .NET 10 to satisfy architectural boundaries without unnecessary infrastructure overhead.
- Use SQLite for the first release because the feature scope is single-user, low-concurrency, and migration-friendly.
- Use React + TypeScript + Tailwind CSS for a fast, modern, accessible UI with strong control over visual polish.
- Use TanStack Query for predictable server-state synchronization across month changes and form submissions.
- Keep categories fixed and predefined in the API so the frontend can render a stable set of category options and dashboard colors.

## Phase 1 Design Decisions

### Backend Design

- Expose REST endpoints for category lookup, expense creation, month expense listing, and month dashboard summary retrieval.
- Keep controllers thin by delegating to application services or handlers.
- Persist expense entries with a normalized expense table and a seeded category lookup table.
- Standardize validation and error responses with `application/problem+json` payloads.

### Frontend Design

- Build a dashboard-first layout with a summary header, month switcher, category summary cards, and an expense list.
- Use Tailwind CSS tokens and reusable UI primitives to achieve an attractive, consistent, and mobile-friendly interface.
- Prioritize simple navigation: current month by default, one-click previous/next month movement, prominent add-expense action, and visible empty states.
- Keep business rules out of components by centralizing API calls, query logic, and form normalization in feature services/hooks.

### Validation and Testing Strategy

- Validate required fields and basic formatting in the client for fast feedback.
- Re-validate all inputs in the API before persistence.
- Cover domain and application logic with unit tests.
- Cover contract and persistence behavior with integration tests.
- Cover dashboard rendering and month switching with frontend behavior tests and one end-to-end smoke path.

## Project Structure

### Documentation (this feature)

```text
specs/001-monthly-expense-dashboard/
├── plan.md
├── research.md
├── data-model.md
├── quickstart.md
├── contracts/
│   └── openapi.yaml
└── tasks.md
```

### Source Code (repository root)

```text
backend/
├── src/
│   ├── ExpenseTracker.Api/
│   ├── ExpenseTracker.Application/
│   ├── ExpenseTracker.Domain/
│   └── ExpenseTracker.Infrastructure/
└── tests/
    ├── ExpenseTracker.Api.IntegrationTests/
    ├── ExpenseTracker.Application.UnitTests/
    └── ExpenseTracker.Domain.UnitTests/

frontend/
├── src/
│   ├── app/
│   ├── components/
│   ├── features/
│   │   ├── dashboard/
│   │   ├── expenses/
│   │   └── month-selector/
│   ├── lib/
│   ├── routes/
│   └── services/
└── tests/
    ├── component/
    └── e2e/
```

**Structure Decision**: Use a two-application repository with a layered .NET backend and a React frontend. This fits the constitution requirement for clear backend/frontend separation while keeping the feature implementation in a single cohesive codebase.

## Implementation Notes for Tasks

- Seed predefined categories in the backend and expose them through a read-only endpoint.
- Use a `yyyy-MM` month key consistently across API contracts, persistence queries, and frontend routing/query state.
- Build the UI with a visually distinctive but clean design system using Tailwind CSS, emphasizing spacing, clear typography, and color-coded categories without sacrificing accessibility.
- Support empty, loading, validation-error, and server-error states explicitly in both dashboard and expense-entry views.
- Ensure the initial dashboard and expense form remain fully usable on mobile widths.

## Complexity Tracking

No constitution violations identified. No additional complexity justification required.
