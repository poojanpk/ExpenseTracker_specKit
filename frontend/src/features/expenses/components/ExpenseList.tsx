import { Card } from '../../../components/ui/Card'
import { formatCurrency } from '../../../lib/months'
import type { ExpenseEntry } from '../../../services/api/types'

type ExpenseListProps = {
  items: ExpenseEntry[]
  isLoading: boolean
}

export function ExpenseList({ items, isLoading }: ExpenseListProps) {
  if (isLoading) {
    return <Card>Loading expenses...</Card>
  }

  if (items.length === 0) {
    return <Card>No expenses recorded for this month yet.</Card>
  }

  return (
    <Card>
      <div className="section-title">Monthly expense list</div>
      <div className="mt-5 space-y-4">
        {items.map((item) => (
          <div className="flex items-start justify-between gap-4 border-b border-stone-100 pb-4 last:border-b-0 last:pb-0" key={item.id}>
            <div>
              <div className="font-semibold text-stone-900">{item.categoryName ?? item.categoryCode}</div>
              <div className="text-sm text-stone-500">{item.expenseDate}</div>
              {item.note ? <div className="mt-1 text-sm text-stone-600">{item.note}</div> : null}
            </div>
            <div className="font-semibold text-stone-900">{formatCurrency(item.amount)}</div>
          </div>
        ))}
      </div>
    </Card>
  )
}
