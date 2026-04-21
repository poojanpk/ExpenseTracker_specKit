import { Card } from '../../../components/ui/Card'
import { formatCurrency } from '../../../lib/months'
import type { CategorySummary } from '../../../services/api/types'

const colorMap: Record<string, string> = {
  rose: 'bg-rose-400',
  amber: 'bg-amber-400',
  sky: 'bg-sky-400',
  emerald: 'bg-emerald-400',
  violet: 'bg-violet-400',
  fuchsia: 'bg-fuchsia-400',
  orange: 'bg-orange-400',
  slate: 'bg-slate-400',
}

type CategoryBreakdownProps = {
  items: CategorySummary[]
}

export function CategoryBreakdown({ items }: CategoryBreakdownProps) {
  return (
    <Card>
      <div className="section-title">Category breakdown</div>
      <div className="mt-5 space-y-4">
        {items.map((item) => (
          <div className="flex items-center justify-between gap-4" key={item.categoryCode}>
            <div className="flex items-center gap-3">
              <span className={`h-3 w-3 rounded-full ${colorMap[item.colorToken] ?? 'bg-stone-400'}`} />
              <div>
                <div className="font-semibold text-stone-900">{item.categoryName}</div>
                <div className="text-sm text-stone-500">{item.expenseCount} expenses</div>
              </div>
            </div>
            <div className="text-sm font-semibold text-stone-800">{formatCurrency(item.totalSpent)}</div>
          </div>
        ))}
      </div>
    </Card>
  )
}
