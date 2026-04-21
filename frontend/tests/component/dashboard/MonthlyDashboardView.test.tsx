import { render, screen } from '@testing-library/react'
import { MonthlyDashboardView } from '../../../src/features/dashboard/components/MonthlyDashboardView'

describe('MonthlyDashboardView', () => {
  it('renders an empty state', () => {
    render(<MonthlyDashboardView dashboard={{ monthKey: '2026-04', totalSpent: 0, expenseCount: 0, hasExpenses: false, categoryBreakdown: [] }} isError={false} isLoading={false} />)

    expect(screen.getByText(/no expenses recorded/i)).toBeInTheDocument()
  })

  it('renders dashboard totals and categories', () => {
    render(
      <MonthlyDashboardView
        dashboard={{
          monthKey: '2026-04',
          totalSpent: 140,
          expenseCount: 2,
          hasExpenses: true,
          categoryBreakdown: [
            { categoryCode: 'food', categoryName: 'Food', totalSpent: 100, expenseCount: 1, colorToken: 'amber' },
          ],
        }}
        isError={false}
        isLoading={false}
      />,
    )

    expect(screen.getByText(/total spent/i)).toBeInTheDocument()
    expect(screen.getByText('Food')).toBeInTheDocument()
  })
})
