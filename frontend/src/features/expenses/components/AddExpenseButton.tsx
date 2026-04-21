import { useState } from 'react'
import { Button } from '../../../components/ui/Button'
import { Card } from '../../../components/ui/Card'
import { ExpenseForm } from './ExpenseForm'

type AddExpenseButtonProps = {
  monthKey: string
}

export function AddExpenseButton({ monthKey }: AddExpenseButtonProps) {
  const [open, setOpen] = useState(false)

  return (
    <Card className="space-y-4">
      <div className="flex items-center justify-between gap-4">
        <div>
          <div className="section-title">Add expense</div>
          <h2 className="mt-2 text-2xl font-semibold text-stone-900">Log spending in seconds</h2>
        </div>
        <Button onClick={() => setOpen((value) => !value)} type="button" variant={open ? 'secondary' : 'primary'}>
          {open ? 'Close' : 'Add expense'}
        </Button>
      </div>
      {open ? <ExpenseForm monthKey={monthKey} onSubmitted={() => setOpen(false)} /> : <p className="text-sm text-stone-600">Keep your dashboard current by capturing spending as it happens.</p>}
    </Card>
  )
}
