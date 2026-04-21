import { useMutation, useQueryClient } from '@tanstack/react-query'
import { apiRequest } from '../../../services/api/client'
import type { CreateExpensePayload, ExpenseEntry } from '../../../services/api/types'

export function useCreateExpense(monthKey: string) {
  const queryClient = useQueryClient()

  return useMutation({
    mutationFn: (payload: CreateExpensePayload) =>
      apiRequest<ExpenseEntry>('/api/v1/expenses', {
        method: 'POST',
        body: JSON.stringify(payload),
      }),
    onSuccess: async () => {
      await Promise.all([
        queryClient.invalidateQueries({ queryKey: ['monthly-dashboard', monthKey] }),
        queryClient.invalidateQueries({ queryKey: ['monthly-expenses', monthKey] }),
      ])
    },
  })
}
