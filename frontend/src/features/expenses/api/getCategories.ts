import { useQuery } from '@tanstack/react-query'
import { apiRequest } from '../../../services/api/client'
import type { ExpenseCategory } from '../../../services/api/types'

type CategoriesResponse = {
  items: ExpenseCategory[]
}

export function useCategories() {
  return useQuery({
    queryKey: ['categories'],
    queryFn: async () => {
      const response = await apiRequest<CategoriesResponse>('/api/v1/categories')
      return response.items
    },
  })
}
