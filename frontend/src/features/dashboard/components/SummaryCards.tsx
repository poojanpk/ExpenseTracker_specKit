import { Card } from '../../../components/ui/Card'
import { formatCurrency } from '../../../lib/months'

type SummaryCardsProps = {
  totalSpent: number
  expenseCount: number
}

export function SummaryCards({ totalSpent, expenseCount }: SummaryCardsProps) {
  return (
    <div className="grid gap-4 md:grid-cols-2">
      <Card className="bg-stone-900 text-white">
        <div className="section-title text-white/70">Total spent</div>
        <div className="mt-4 text-4xl font-semibold">{formatCurrency(totalSpent)}</div>
      </Card>
      <Card>
        <div className="section-title">Expenses logged</div>
        <div className="mt-4 text-4xl font-semibold text-stone-900">{expenseCount}</div>
      </Card>
    </div>
  )
}
