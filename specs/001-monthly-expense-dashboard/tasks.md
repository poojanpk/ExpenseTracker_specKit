# Tasks: Monthly Expense Dashboard

**Input**: Design documents from `/specs/001-monthly-expense-dashboard/`
**Prerequisites**: plan.md, spec.md, research.md, data-model.md, contracts/openapi.yaml, quickstart.md

**Tests**: Included because the constitution and plan require automated backend and frontend verification for every completed change.

**Organization**: Tasks are grouped by user story so each story can be implemented, tested, and validated independently.

## Format: `[ID] [P?] [Story] Description`

- **[P]**: Can run in parallel when dependencies are satisfied
- **[Story]**: Identifies user story ownership for traceability
- Every task includes exact target file paths

## Phase 1: Setup (Shared Infrastructure)

**Purpose**: Initialize the backend and frontend workspaces, toolchains, and local developer configuration.

- [ ] T001 Create the backend solution and project skeleton in backend/ExpenseTracker.sln
- [ ] T002 Create the frontend application bootstrap in frontend/package.json and frontend/src/main.tsx
- [ ] T003 [P] Configure backend shared build, formatting, and analyzer settings in backend/Directory.Build.props
- [ ] T004 [P] Configure frontend linting, Vitest, Vite, and Tailwind in frontend/eslint.config.js, frontend/vitest.config.ts, frontend/vite.config.ts, and frontend/tailwind.config.ts
- [ ] T005 [P] Add local environment templates in backend/src/ExpenseTracker.Api/appsettings.Development.json and frontend/.env.example

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Establish the core architecture, persistence, shared frontend shell, and cross-cutting infrastructure before user story work begins.

**⚠️ CRITICAL**: No user story work should start until this phase is complete.

- [ ] T006 Define backend composition root and project dependency registration in backend/src/ExpenseTracker.Api/Program.cs and backend/src/ExpenseTracker.Application/DependencyInjection.cs
- [ ] T007 [P] Create core domain entities and month value object in backend/src/ExpenseTracker.Domain/Expenses/ExpenseEntry.cs, backend/src/ExpenseTracker.Domain/Expenses/ExpenseCategory.cs, and backend/src/ExpenseTracker.Domain/ValueObjects/MonthKey.cs
- [ ] T008 [P] Configure SQLite persistence and entity mappings in backend/src/ExpenseTracker.Infrastructure/Persistence/ExpenseTrackerDbContext.cs, backend/src/ExpenseTracker.Infrastructure/Persistence/Configurations/ExpenseEntryConfiguration.cs, and backend/src/ExpenseTracker.Infrastructure/Persistence/Configurations/ExpenseCategoryConfiguration.cs
- [ ] T009 [P] Add the initial EF Core migration and predefined category seed data in backend/src/ExpenseTracker.Infrastructure/Persistence/Migrations/InitialCreate.cs and backend/src/ExpenseTracker.Infrastructure/Persistence/Seed/CategorySeedData.cs
- [ ] T010 [P] Implement API exception handling, problem details, and request logging in backend/src/ExpenseTracker.Api/Middleware/ExceptionHandlingMiddleware.cs and backend/src/ExpenseTracker.Api/Extensions/ProblemDetailsExtensions.cs
- [ ] T011 [P] Build the shared frontend app shell, router, and query client in frontend/src/app/App.tsx, frontend/src/app/router.tsx, and frontend/src/app/queryClient.ts
- [ ] T012 [P] Create shared UI primitives and design tokens in frontend/src/app/styles.css, frontend/src/components/ui/Button.tsx, and frontend/src/components/ui/Card.tsx
- [ ] T013 [P] Implement the shared API client and month utility helpers in frontend/src/services/api/client.ts and frontend/src/lib/months.ts
- [ ] T014 [P] Expose the read-only categories query and endpoint in backend/src/ExpenseTracker.Application/Categories/ListCategories/ListCategoriesQuery.cs, backend/src/ExpenseTracker.Application/Categories/ListCategories/ListCategoriesHandler.cs, and backend/src/ExpenseTracker.Api/Endpoints/Categories/GetCategoriesEndpoint.cs

**Checkpoint**: Foundation ready. User stories can now be implemented in priority order or in parallel if staffing allows.

---

## Phase 3: User Story 1 - Record Monthly Expenses (Priority: P1) 🎯 MVP

**Goal**: Let the user add an expense for the selected month with clear validation and immediate feedback.

**Independent Test**: Start the app, open the add-expense flow, submit a valid expense, and confirm it is saved successfully for the selected month while invalid submissions show validation errors.

### Tests for User Story 1

- [ ] T015 [P] [US1] Add application unit tests for create-expense validation and handling in backend/tests/ExpenseTracker.Application.UnitTests/Expenses/CreateExpenseHandlerTests.cs
- [ ] T016 [P] [US1] Add API integration tests for POST /api/v1/expenses in backend/tests/ExpenseTracker.Api.IntegrationTests/Expenses/PostExpenseEndpointTests.cs
- [ ] T017 [P] [US1] Add frontend component tests for expense form validation and submission in frontend/tests/component/expenses/ExpenseForm.test.tsx

### Implementation for User Story 1

- [ ] T018 [P] [US1] Create the create-expense command, validator, and request mapping in backend/src/ExpenseTracker.Application/Expenses/CreateExpense/CreateExpenseCommand.cs and backend/src/ExpenseTracker.Application/Expenses/CreateExpense/CreateExpenseValidator.cs
- [ ] T019 [US1] Implement the create-expense handler in backend/src/ExpenseTracker.Application/Expenses/CreateExpense/CreateExpenseHandler.cs
- [ ] T020 [US1] Implement the POST expense endpoint in backend/src/ExpenseTracker.Api/Endpoints/Expenses/PostExpenseEndpoint.cs
- [ ] T021 [P] [US1] Implement category loading and expense submission API services in frontend/src/features/expenses/api/getCategories.ts and frontend/src/features/expenses/api/createExpense.ts
- [ ] T022 [P] [US1] Build the add-expense button and expense form UI in frontend/src/features/expenses/components/AddExpenseButton.tsx and frontend/src/features/expenses/components/ExpenseForm.tsx
- [ ] T023 [US1] Integrate the expense creation workflow into the dashboard route in frontend/src/routes/DashboardPage.tsx

**Checkpoint**: User Story 1 should now be independently functional and demoable as the MVP.

---

## Phase 4: User Story 2 - View Monthly Dashboard Summary (Priority: P2)

**Goal**: Show the selected month’s total spending, expense count, and category breakdown in an attractive dashboard.

**Independent Test**: Seed or create expenses for a month, open the dashboard for that month, and confirm the summary totals, category breakdown, and empty-state behavior are correct.

### Tests for User Story 2

- [ ] T024 [P] [US2] Add application unit tests for monthly dashboard aggregation in backend/tests/ExpenseTracker.Application.UnitTests/Dashboard/GetMonthlyDashboardHandlerTests.cs
- [ ] T025 [P] [US2] Add API integration tests for GET /api/v1/months/{monthKey}/dashboard in backend/tests/ExpenseTracker.Api.IntegrationTests/Dashboard/GetMonthlyDashboardEndpointTests.cs
- [ ] T026 [P] [US2] Add frontend component tests for dashboard summary, empty state, and error state rendering in frontend/tests/component/dashboard/MonthlyDashboardView.test.tsx

### Implementation for User Story 2

- [ ] T027 [P] [US2] Create the monthly dashboard query and DTOs in backend/src/ExpenseTracker.Application/Dashboard/GetMonthlyDashboard/GetMonthlyDashboardQuery.cs and backend/src/ExpenseTracker.Application/Dashboard/GetMonthlyDashboard/MonthlyDashboardDto.cs
- [ ] T028 [US2] Implement the monthly dashboard aggregation handler in backend/src/ExpenseTracker.Application/Dashboard/GetMonthlyDashboard/GetMonthlyDashboardHandler.cs
- [ ] T029 [US2] Implement the GET monthly dashboard endpoint in backend/src/ExpenseTracker.Api/Endpoints/Dashboard/GetMonthlyDashboardEndpoint.cs
- [ ] T030 [P] [US2] Build dashboard summary card and category breakdown components in frontend/src/features/dashboard/components/SummaryCards.tsx and frontend/src/features/dashboard/components/CategoryBreakdown.tsx
- [ ] T031 [P] [US2] Implement the dashboard query hook and view container in frontend/src/features/dashboard/api/getMonthlyDashboard.ts and frontend/src/features/dashboard/components/MonthlyDashboardView.tsx
- [ ] T032 [US2] Compose the attractive dashboard hero and summary layout in frontend/src/routes/DashboardPage.tsx

**Checkpoint**: User Story 2 should now work independently and provide clear monthly spending insight.

---

## Phase 5: User Story 3 - Change Monthly View (Priority: P3)

**Goal**: Let the user move between the current month and previous months while refreshing the dashboard and expense list correctly.

**Independent Test**: Load expenses across multiple months, switch months in the UI, and confirm both the list and dashboard update to the selected month without mixing data.

### Tests for User Story 3

- [ ] T033 [P] [US3] Add application unit tests for month-based expense retrieval in backend/tests/ExpenseTracker.Application.UnitTests/Expenses/GetMonthlyExpensesHandlerTests.cs
- [ ] T034 [P] [US3] Add API integration tests for GET /api/v1/months/{monthKey}/expenses in backend/tests/ExpenseTracker.Api.IntegrationTests/Expenses/GetMonthlyExpensesEndpointTests.cs
- [ ] T035 [P] [US3] Add frontend component tests for month switching and expense list refresh in frontend/tests/component/month-selector/MonthSelector.test.tsx and frontend/tests/component/expenses/ExpenseList.test.tsx

### Implementation for User Story 3

- [ ] T036 [P] [US3] Create the monthly expenses query and DTOs in backend/src/ExpenseTracker.Application/Expenses/GetMonthlyExpenses/GetMonthlyExpensesQuery.cs and backend/src/ExpenseTracker.Application/Expenses/GetMonthlyExpenses/MonthlyExpenseListDto.cs
- [ ] T037 [US3] Implement the monthly expenses retrieval handler in backend/src/ExpenseTracker.Application/Expenses/GetMonthlyExpenses/GetMonthlyExpensesHandler.cs
- [ ] T038 [US3] Implement the GET monthly expenses endpoint in backend/src/ExpenseTracker.Api/Endpoints/Expenses/GetMonthlyExpensesEndpoint.cs
- [ ] T039 [P] [US3] Build the month selector and expense list components in frontend/src/features/month-selector/components/MonthSelector.tsx and frontend/src/features/expenses/components/ExpenseList.tsx
- [ ] T040 [P] [US3] Implement month-aware dashboard and expense list state hooks in frontend/src/features/dashboard/api/useSelectedMonth.ts and frontend/src/features/expenses/api/getMonthlyExpenses.ts
- [ ] T041 [US3] Wire month selector state into route-level refresh behavior in frontend/src/routes/DashboardPage.tsx

**Checkpoint**: User Story 3 should now be independently functional, with accurate month switching and history review.

---

## Phase 6: Polish & Cross-Cutting Concerns

**Purpose**: Finish cross-story quality, presentation, and final verification work.

- [ ] T042 [P] Create the end-to-end smoke test for expense creation and month switching in frontend/tests/e2e/monthly-expense-dashboard.spec.ts
- [ ] T043 [P] Polish responsive layout, empty states, and accessible focus styling in frontend/src/app/styles.css and frontend/src/routes/DashboardPage.tsx
- [ ] T044 [P] Finalize structured logging and configuration defaults in backend/src/ExpenseTracker.Api/Program.cs and backend/src/ExpenseTracker.Api/appsettings.json
- [ ] T045 Run the full quickstart validation flow and update verification notes in specs/001-monthly-expense-dashboard/quickstart.md

---

## Dependencies & Execution Order

### Phase Dependencies

- **Phase 1: Setup** has no dependencies and starts immediately.
- **Phase 2: Foundational** depends on Setup and blocks all user story implementation.
- **Phase 3: User Story 1** depends on Foundational and defines the MVP slice.
- **Phase 4: User Story 2** depends on Foundational and can begin after or alongside User Story 1 once shared data access is stable.
- **Phase 5: User Story 3** depends on Foundational and integrates with the expense and dashboard flows.
- **Phase 6: Polish** depends on all desired user stories being complete.

### User Story Dependencies

- **User Story 1 (P1)**: No dependency on other user stories after Phase 2.
- **User Story 2 (P2)**: Can start after Phase 2 but benefits from the expense creation path being available for realistic data validation.
- **User Story 3 (P3)**: Can start after Phase 2 but relies on the list and dashboard APIs created in prior story phases for full end-to-end behavior.

### Within Each User Story

- Automated tests should be written before or alongside implementation and must fail before the corresponding implementation is considered complete.
- Application contracts and handlers come before API endpoint wiring.
- Frontend data hooks come before route-level integration.
- Each story is complete only when its independent test passes.

### Parallel Opportunities

- Setup tasks marked `[P]` can run in parallel after T001 and T002 establish the workspaces.
- Foundational tasks T007 through T014 can be split across backend and frontend contributors once T006 defines composition.
- Within each story phase, test tasks marked `[P]` can be written together.
- Backend application tasks and frontend UI tasks marked `[P]` can proceed in parallel once their shared dependencies are complete.

---

## Parallel Example: User Story 1

```text
Task: T015 Add application unit tests for create-expense validation and handling in backend/tests/ExpenseTracker.Application.UnitTests/Expenses/CreateExpenseHandlerTests.cs
Task: T016 Add API integration tests for POST /api/v1/expenses in backend/tests/ExpenseTracker.Api.IntegrationTests/Expenses/PostExpenseEndpointTests.cs
Task: T017 Add frontend component tests for expense form validation and submission in frontend/tests/component/expenses/ExpenseForm.test.tsx
```

```text
Task: T021 Implement category loading and expense submission API services in frontend/src/features/expenses/api/getCategories.ts and frontend/src/features/expenses/api/createExpense.ts
Task: T022 Build the add-expense button and expense form UI in frontend/src/features/expenses/components/AddExpenseButton.tsx and frontend/src/features/expenses/components/ExpenseForm.tsx
```

---

## Parallel Example: User Story 2

```text
Task: T024 Add application unit tests for monthly dashboard aggregation in backend/tests/ExpenseTracker.Application.UnitTests/Dashboard/GetMonthlyDashboardHandlerTests.cs
Task: T025 Add API integration tests for GET /api/v1/months/{monthKey}/dashboard in backend/tests/ExpenseTracker.Api.IntegrationTests/Dashboard/GetMonthlyDashboardEndpointTests.cs
Task: T026 Add frontend component tests for dashboard summary, empty state, and error state rendering in frontend/tests/component/dashboard/MonthlyDashboardView.test.tsx
```

```text
Task: T030 Build dashboard summary card and category breakdown components in frontend/src/features/dashboard/components/SummaryCards.tsx and frontend/src/features/dashboard/components/CategoryBreakdown.tsx
Task: T031 Implement the dashboard query hook and view container in frontend/src/features/dashboard/api/getMonthlyDashboard.ts and frontend/src/features/dashboard/components/MonthlyDashboardView.tsx
```

---

## Parallel Example: User Story 3

```text
Task: T033 Add application unit tests for month-based expense retrieval in backend/tests/ExpenseTracker.Application.UnitTests/Expenses/GetMonthlyExpensesHandlerTests.cs
Task: T034 Add API integration tests for GET /api/v1/months/{monthKey}/expenses in backend/tests/ExpenseTracker.Api.IntegrationTests/Expenses/GetMonthlyExpensesEndpointTests.cs
Task: T035 Add frontend component tests for month switching and expense list refresh in frontend/tests/component/month-selector/MonthSelector.test.tsx and frontend/tests/component/expenses/ExpenseList.test.tsx
```

```text
Task: T039 Build the month selector and expense list components in frontend/src/features/month-selector/components/MonthSelector.tsx and frontend/src/features/expenses/components/ExpenseList.tsx
Task: T040 Implement month-aware dashboard and expense list state hooks in frontend/src/features/dashboard/api/useSelectedMonth.ts and frontend/src/features/expenses/api/getMonthlyExpenses.ts
```

---

## Implementation Strategy

### MVP First

1. Complete Phase 1 and Phase 2.
2. Complete Phase 3 for User Story 1.
3. Validate the expense entry flow independently.
4. Stop and review before expanding to dashboard summary and month switching.

### Incremental Delivery

1. Deliver User Story 1 as the first usable slice.
2. Add User Story 2 to turn recorded data into a dashboard experience.
3. Add User Story 3 to unlock prior-month navigation and historical review.
4. Finish with cross-cutting polish, responsive refinement, and smoke validation.

### Parallel Team Strategy

1. One developer focuses on backend foundations while another establishes the frontend shell in Phase 2.
2. After Phase 2, backend and frontend work inside each story can proceed in parallel on the `[P]` tasks.
3. Final route integration and smoke testing happen after both sides of each story are complete.

---

## Notes

- `[P]` means the task can run in parallel once dependencies are satisfied.
- `[US1]`, `[US2]`, and `[US3]` map directly to the user stories in the specification.
- Every task points to concrete file paths so implementation can start without further breakdown.
- The suggested MVP scope is **User Story 1 only** after Setup and Foundational phases.