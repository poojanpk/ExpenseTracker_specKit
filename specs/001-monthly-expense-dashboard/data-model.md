# Data Model: Monthly Expense Dashboard

## Overview

The feature centers on a personal monthly expense ledger with read-only predefined categories and a derived monthly dashboard summary.

## Entities

### ExpenseEntry

- **Purpose**: Represents one recorded expense.
- **Fields**:
  - `id`: Unique identifier.
  - `expenseDate`: Calendar date of the expense.
  - `monthKey`: Canonical month string in `yyyy-MM` format derived from `expenseDate`.
  - `amount`: Decimal monetary amount greater than zero.
  - `categoryCode`: Required reference to a predefined category.
  - `note`: Optional user-entered text note.
  - `createdAt`: Timestamp for audit and sorting.
- **Validation rules**:
  - `expenseDate` is required.
  - `amount` must be greater than zero.
  - `categoryCode` must match an existing predefined category.
  - `note` is optional but trimmed and length-limited.
- **Relationships**:
  - Many expense entries belong to one expense category.

### ExpenseCategory

- **Purpose**: Defines the fixed selectable categories available in v1.
- **Fields**:
  - `code`: Stable identifier used by API and persistence.
  - `name`: User-facing label.
  - `displayOrder`: Numeric ordering for form and dashboard display.
  - `colorToken`: Visual token used by the dashboard UI.
- **Validation rules**:
  - Category records are seeded and read-only in v1.
  - `code` must be unique and stable.

### MonthlyDashboard

- **Purpose**: Represents the derived summary for the selected month.
- **Fields**:
  - `monthKey`: Selected month in `yyyy-MM` format.
  - `totalSpent`: Sum of all expense amounts for the month.
  - `expenseCount`: Number of expense entries in the month.
  - `categoryBreakdown`: Collection of category summary rows.
  - `hasExpenses`: Boolean flag for empty-state rendering.
- **Relationships**:
  - Derived from zero or more expense entries in the selected month.

### CategorySummary

- **Purpose**: Represents one line in the monthly category breakdown.
- **Fields**:
  - `categoryCode`: Category identifier.
  - `categoryName`: User-facing label.
  - `totalSpent`: Total amount spent in that category for the month.
  - `expenseCount`: Number of expense entries in that category.
  - `colorToken`: Dashboard visual token.

## Derived Rules

- `monthKey` is always computed from `expenseDate`; it is never independently entered by the user.
- If a month has no matching expense entries, `MonthlyDashboard` returns zero values and an empty breakdown.
- Dashboard summaries must include only entries from the currently selected month.

## State Notes

- Expense entries are created in this feature scope.
- Edit and delete behavior is out of scope for this release.
- Categories remain read-only and are maintained by seeded system data.