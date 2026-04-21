import { render, screen } from '@testing-library/react'
import userEvent from '@testing-library/user-event'
import { ExpenseList } from '../../../src/features/expenses/components/ExpenseList'
import { MonthSelector } from '../../../src/features/month-selector/components/MonthSelector'

describe('MonthSelector', () => {
  it('invokes navigation callbacks', async () => {
    const onPrevious = vi.fn()
    const onNext = vi.fn()
    const onReset = vi.fn()

    render(<MonthSelector monthKey="2026-04" onNext={onNext} onPrevious={onPrevious} onReset={onReset} />)

    await userEvent.click(screen.getByRole('button', { name: /previous/i }))
    await userEvent.click(screen.getByRole('button', { name: /next/i }))

    expect(onPrevious).toHaveBeenCalledTimes(1)
    expect(onNext).toHaveBeenCalledTimes(1)
  })

  it('renders a monthly expense list', () => {
    render(
      <ExpenseList
        isLoading={false}
        items={[
          { id: '1', expenseDate: '2026-04-21', monthKey: '2026-04', amount: 24, categoryCode: 'food', categoryName: 'Food', note: 'Lunch', createdAt: new Date().toISOString() },
        ]}
      />,
    )

    expect(screen.getByText('Food')).toBeInTheDocument()
    expect(screen.getByText('Lunch')).toBeInTheDocument()
  })
})
