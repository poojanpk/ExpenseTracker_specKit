import { useQuery } from '@tanstack/react-query'
import { apiRequest } from '../../../services/api/client'
import type { MonthlyDashboard } from '../../../services/api/types'

export function useMonthlyDashboard(monthKey: string) {
  return useQuery({
    queryKey: ['monthly-dashboard', monthKey],
    queryFn: () => apiRequest<MonthlyDashboard>(`/api/v1/months/${monthKey}/dashboard`),
  })
}
