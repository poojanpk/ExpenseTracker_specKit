import { useQuery } from '@tanstack/react-query'
import { apiRequest } from '../../../services/api/client'
import type { MonthlyExpensesResponse } from '../../../services/api/types'

export function useMonthlyExpenses(monthKey: string) {
  return useQuery({
    queryKey: ['monthly-expenses', monthKey],
    queryFn: () => apiRequest<MonthlyExpensesResponse>(`/api/v1/months/${monthKey}/expenses`),
  })
}
