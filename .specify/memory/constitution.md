# Expense Tracker Constitution

## Core Principles

### I. Domain-Driven, Layered Architecture
The system MUST be implemented as a clear split between a .NET 10 Web API backend and a React frontend using the latest stable React release available at implementation time. The backend MUST separate API, application, domain, and infrastructure concerns. Business rules for expenses, categories, budgets, summaries, and reporting MUST live outside controllers and UI components. Shared contracts MUST be explicit and versioned so the frontend never depends on backend implementation details.

### II. API Contract First
Every backend capability MUST start from a documented HTTP contract that defines routes, request and response models, validation rules, error shapes, authorization expectations, and pagination or filtering behavior where applicable. Breaking contract changes REQUIRE corresponding spec, plan, and consumer updates in the same delivery unit. APIs MUST be consistent in naming, status codes, validation handling, and problem details formatting.

### III. Quality Gates Are Non-Negotiable
Code is not complete without automated verification. Backend changes MUST include unit tests for domain and application logic plus integration tests for API endpoints and persistence boundaries when behavior changes. Frontend changes MUST include component or behavior tests for critical user flows and state transitions. Every change MUST pass formatting, linting, build, and test checks before it is considered review-ready.

### IV. Security, Validation, and Observability by Default
All input MUST be validated at system boundaries. Sensitive data handling, authentication state, authorization rules, and error exposure MUST follow least-privilege and fail-safe defaults. The API MUST emit structured logs for operationally important events and failures. Diagnostics MUST help trace requests, validation failures, and persistence issues without leaking secrets or personally sensitive information.

### V. Simplicity, Maintainability, and Consistency
The codebase MUST prefer simple, readable solutions over premature abstraction. New dependencies REQUIRE justification. Naming MUST be explicit, code duplication SHOULD be removed when it creates real maintenance cost, and dead code MUST not be kept. Public behavior, coding style, validation patterns, and error handling MUST remain consistent across backend and frontend. All work MUST align with established coding standards, including formatting, static analysis, and reviewability.

## Technology Standards

The required platform for this project is:

- Backend: .NET 10 Web API, C#, RESTful HTTP endpoints, dependency injection, configuration by environment, and a persistence approach selected in planning with migrations and testability in mind.
- Frontend: React latest stable version, TypeScript preferred, component-driven UI, accessible forms, predictable state management, and API integration through typed client boundaries.
- Data: Expense data models MUST support categories, transaction dates, amounts, notes, and user-centric reporting use cases. Data access MUST be abstracted behind interfaces or well-defined infrastructure seams.
- Tooling: Formatters, linters, and test runners MUST be part of the default workflow. CI-ready commands for build, lint, and test MUST exist before implementation is considered complete.

Implementation constraints:

- Controllers MUST remain thin and delegate business logic to application services or handlers.
- React components MUST avoid embedding business rules that belong in domain or service layers.
- Validation MUST exist on both client and server where it improves correctness or user experience; server validation remains authoritative.
- Configuration secrets MUST never be hardcoded.
- Any third-party package added to either stack MUST be actively maintained and justified by clear value.

## Development Workflow and Review Gates

Every feature MUST proceed through Spec Kit artifacts in order: constitution alignment, specification, implementation plan, tasks, implementation, and review. Plans MUST identify architecture, contracts, data changes, test strategy, and operational concerns before code is written. Tasks MUST be small enough to verify independently.

Review and delivery requirements:

- Each pull request or review unit MUST describe the user-visible change, affected contracts, data model impact, and verification evidence.
- Backend changes affecting data storage MUST include migration strategy and rollback considerations.
- Frontend changes affecting forms or dashboards MUST include responsive and accessibility checks.
- Bug fixes MUST include regression coverage where feasible.
- If a requested shortcut conflicts with this constitution, the constitution prevails unless it is formally amended.

## Governance

This constitution governs all project specifications, plans, tasks, and implementation decisions for the expense tracker application. Any artifact that conflicts with these rules is invalid until corrected.

Amendments REQUIRE:

- a documented reason for the change,
- an explanation of the impact on existing specifications or implementation plans,
- and an update to dependent templates or guidance when the rule changes developer behavior.

Compliance reviews MUST explicitly verify architecture boundaries, API contract integrity, test coverage expectations, security handling, and coding-standard adherence.

**Version**: 1.0.0 | **Ratified**: 2026-04-21 | **Last Amended**: 2026-04-21
