import { zodResolver } from '@hookform/resolvers/zod'
import { useForm } from 'react-hook-form'
import { z } from 'zod'
import { Button } from '../../../components/ui/Button'
import { useCategories } from '../api/getCategories'
import { useCreateExpense } from '../api/createExpense'

const expenseSchema = z.object({
  expenseDate: z.string().min(1, 'Expense date is required'),
  amount: z.number().positive('Amount must be greater than zero'),
  categoryCode: z.string().min(1, 'Category is required'),
  note: z.string().max(250, 'Note must be 250 characters or fewer').optional(),
})

type ExpenseFormValues = z.infer<typeof expenseSchema>

type ExpenseFormProps = {
  monthKey: string
  onSubmitted: () => void
}

export function ExpenseForm({ monthKey, onSubmitted }: ExpenseFormProps) {
  const { data: categories = [] } = useCategories()
  const mutation = useCreateExpense(monthKey)
  const form = useForm<ExpenseFormValues>({
    resolver: zodResolver(expenseSchema),
    defaultValues: {
      expenseDate: `${monthKey}-01`,
      amount: 0,
      categoryCode: '',
      note: '',
    },
  })

  const onSubmit = form.handleSubmit(async (values) => {
    await mutation.mutateAsync({
      expenseDate: values.expenseDate,
      amount: values.amount,
      categoryCode: values.categoryCode,
      note: values.note,
    })
    form.reset({ expenseDate: `${monthKey}-01`, amount: 0, categoryCode: '', note: '' })
    onSubmitted()
  })

  return (
    <form className="space-y-4" onSubmit={onSubmit}>
      <div>
        <label className="mb-1 block text-sm font-medium text-stone-700" htmlFor="expenseDate">Expense date</label>
        <input className="w-full rounded-2xl border border-stone-200 px-4 py-3" id="expenseDate" type="date" {...form.register('expenseDate')} />
        {form.formState.errors.expenseDate ? <p className="mt-1 text-sm text-rose-600">{form.formState.errors.expenseDate.message}</p> : null}
      </div>
      <div>
        <label className="mb-1 block text-sm font-medium text-stone-700" htmlFor="amount">Amount</label>
        <input className="w-full rounded-2xl border border-stone-200 px-4 py-3" id="amount" step="0.01" type="number" {...form.register('amount', { valueAsNumber: true })} />
        {form.formState.errors.amount ? <p className="mt-1 text-sm text-rose-600">{form.formState.errors.amount.message}</p> : null}
      </div>
      <div>
        <label className="mb-1 block text-sm font-medium text-stone-700" htmlFor="categoryCode">Category</label>
        <select className="w-full rounded-2xl border border-stone-200 px-4 py-3" id="categoryCode" {...form.register('categoryCode')}>
          <option value="">Choose a category</option>
          {categories.map((category) => (
            <option key={category.code} value={category.code}>{category.name}</option>
          ))}
        </select>
        {form.formState.errors.categoryCode ? <p className="mt-1 text-sm text-rose-600">{form.formState.errors.categoryCode.message}</p> : null}
      </div>
      <div>
        <label className="mb-1 block text-sm font-medium text-stone-700" htmlFor="note">Note</label>
        <textarea className="w-full rounded-2xl border border-stone-200 px-4 py-3" id="note" rows={3} {...form.register('note')} />
      </div>
      {mutation.isError ? <p className="text-sm text-rose-600">Expense could not be saved. Please check the details and try again.</p> : null}
      <Button className="w-full" type="submit">{mutation.isPending ? 'Saving...' : 'Save expense'}</Button>
    </form>
  )
}
