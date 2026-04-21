# Research: Monthly Expense Dashboard

## Decision 1: Use a layered modular monolith for the backend

- **Decision**: Implement the backend as a .NET 10 modular monolith with separate API, Application, Domain, and Infrastructure projects.
- **Rationale**: This satisfies the constitution requirement for explicit architectural boundaries while keeping the MVP straightforward to build, test, and deploy.
- **Alternatives considered**:
  - Single Web API project with all logic together: rejected because it would blur business rules and transport concerns.
  - Microservices: rejected because the feature scope is too small to justify distributed complexity.

## Decision 2: Use SQLite for initial persistence

- **Decision**: Store expense data in SQLite through EF Core 10 migrations.
- **Rationale**: The feature targets a single-user MVP with low write concurrency and simple deployment needs. SQLite keeps local setup fast and reduces operational overhead while preserving migration support.
- **Alternatives considered**:
  - PostgreSQL: rejected for the MVP because it adds infrastructure overhead without clear user value at this scope.
  - Flat files: rejected because queryability, validation, and migration control would be weaker.

## Decision 3: Use React, TypeScript, and Tailwind CSS for the frontend

- **Decision**: Build the frontend with React 19.x, TypeScript, Vite, and Tailwind CSS 4.
- **Rationale**: This combination supports a polished, responsive, and maintainable UI. Tailwind CSS is appropriate here because the user explicitly requested it and it allows fast iteration on an attractive interface while keeping styles consistent.
- **Alternatives considered**:
  - Plain CSS modules: rejected because design iteration would be slower for the intended polished dashboard UI.
  - A heavyweight component framework: rejected to avoid excessive visual sameness and dependency cost.

## Decision 4: Use TanStack Query for month-driven server state

- **Decision**: Use TanStack Query to manage API-backed state for the selected month, expense lists, dashboard summaries, and category lookup.
- **Rationale**: The core UX depends on frequent month changes and immediate UI refresh after expense creation. TanStack Query reduces manual cache management and keeps loading, refetching, and invalidation predictable.
- **Alternatives considered**:
  - Custom fetch state in components: rejected because it would spread async state handling across the UI.
  - Global client state for all server data: rejected because server-state tools are a better fit for this pattern.

## Decision 5: Keep categories predefined and read-only in v1

- **Decision**: Seed a fixed set of categories in the backend and expose them as read-only options to the client.
- **Rationale**: This aligns with the clarification outcome and limits the scope to the main value: entering and reviewing expenses. It also simplifies reporting, validation, and dashboard styling.
- **Alternatives considered**:
  - User-defined categories: rejected because it would add management flows and broaden the data model.
  - Hybrid default plus custom categories: rejected because it complicates reporting and UX for the first release.

## Decision 6: Use REST contracts with `yyyy-MM` month keys

- **Decision**: Expose REST endpoints using a `yyyy-MM` month path parameter for monthly dashboard and expense listing operations.
- **Rationale**: The feature is organized around monthly views. A canonical month key is easy to validate, easy to reason about, and straightforward to share between frontend and backend.
- **Alternatives considered**:
  - Start/end date query parameters everywhere: rejected because the user experience and reporting scope are explicitly month-centric.
  - GraphQL: rejected because the API surface is small and predictable.

## Decision 7: Use mixed automated testing by layer

- **Decision**: Use xUnit unit and integration tests for the backend, Vitest with React Testing Library for frontend behavior, and Playwright for one end-to-end smoke flow.
- **Rationale**: This satisfies constitution quality gates while keeping the test pyramid balanced. It also verifies the highest-risk user behavior: entering an expense and seeing it reflected in the selected month dashboard.
- **Alternatives considered**:
  - End-to-end tests only: rejected because diagnosis and feedback speed would be poor.
  - Unit tests only: rejected because API contracts and cross-layer behavior would remain under-verified.