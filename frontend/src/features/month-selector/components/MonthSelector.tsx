import { Button } from '../../../components/ui/Button'
import { formatMonthLabel, getCurrentMonthKey } from '../../../lib/months'

type MonthSelectorProps = {
  monthKey: string
  onPrevious: () => void
  onNext: () => void
  onReset: () => void
}

export function MonthSelector({ monthKey, onPrevious, onNext, onReset }: MonthSelectorProps) {
  const isCurrentMonth = monthKey === getCurrentMonthKey()

  return (
    <div className="flex items-center gap-3 rounded-full bg-stone-900/90 px-3 py-2 text-white shadow-lg shadow-stone-900/10">
      <Button variant="ghost" className="text-white hover:bg-white/10" onClick={onPrevious} type="button">
        Previous
      </Button>
      <div className="min-w-32 text-center text-sm font-semibold">{formatMonthLabel(monthKey)}</div>
      <Button variant="ghost" className="text-white hover:bg-white/10" onClick={onNext} type="button">
        Next
      </Button>
      <Button variant="secondary" className="ml-2" disabled={isCurrentMonth} onClick={onReset} type="button">
        Current month
      </Button>
    </div>
  )
}
