import { QueryClient, QueryClientProvider } from '@tanstack/react-query'
import { render, screen, waitFor } from '@testing-library/react'
import userEvent from '@testing-library/user-event'
import { ExpenseForm } from '../../../src/features/expenses/components/ExpenseForm'

function renderForm() {
  const queryClient = new QueryClient()
  return render(
    <QueryClientProvider client={queryClient}>
      <ExpenseForm monthKey="2026-04" onSubmitted={() => undefined} />
    </QueryClientProvider>,
  )
}

describe('ExpenseForm', () => {
  afterEach(() => {
    vi.restoreAllMocks()
  })

  it('shows validation errors for invalid submission', async () => {
    vi.spyOn(global, 'fetch').mockResolvedValueOnce(new Response(JSON.stringify({ items: [] }), { status: 200 }))

    renderForm()
    await userEvent.click(screen.getByRole('button', { name: /save expense/i }))

    expect(await screen.findByText(/amount must be greater than zero/i)).toBeInTheDocument()
  })

  it('submits a valid expense', async () => {
    vi.spyOn(global, 'fetch')
      .mockResolvedValueOnce(new Response(JSON.stringify({ items: [{ code: 'food', name: 'Food', displayOrder: 1, colorToken: 'amber' }] }), { status: 200 }))
      .mockResolvedValueOnce(new Response(JSON.stringify({ id: '1', monthKey: '2026-04', amount: 45, expenseDate: '2026-04-21', categoryCode: 'food', note: 'Lunch', createdAt: new Date().toISOString() }), { status: 200 }))

    renderForm()

    await waitFor(() => expect(screen.getByRole('option', { name: 'Food' })).toBeInTheDocument())
    await userEvent.clear(screen.getByLabelText(/amount/i))
    await userEvent.type(screen.getByLabelText(/amount/i), '45')
    await userEvent.selectOptions(screen.getByLabelText(/category/i), 'food')
    await userEvent.type(screen.getByLabelText(/note/i), 'Lunch')
    await userEvent.click(screen.getByRole('button', { name: /save expense/i }))

    await waitFor(() => expect(global.fetch).toHaveBeenCalledTimes(2))
  })
})
