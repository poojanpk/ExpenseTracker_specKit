export type ExpenseCategory = {
  code: string
  name: string
  displayOrder: number
  colorToken: string
}

export type ExpenseEntry = {
  id: string
  expenseDate: string
  monthKey: string
  amount: number
  categoryCode: string
  categoryName?: string
  note?: string | null
  createdAt: string
}

export type MonthlyExpensesResponse = {
  monthKey: string
  items: ExpenseEntry[]
}

export type CategorySummary = {
  categoryCode: string
  categoryName: string
  totalSpent: number
  expenseCount: number
  colorToken: string
}

export type MonthlyDashboard = {
  monthKey: string
  totalSpent: number
  expenseCount: number
  hasExpenses: boolean
  categoryBreakdown: CategorySummary[]
}

export type CreateExpensePayload = {
  expenseDate: string
  amount: number
  categoryCode: string
  note?: string
}
