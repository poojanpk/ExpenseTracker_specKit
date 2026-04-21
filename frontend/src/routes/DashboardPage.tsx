import { AddExpenseButton } from '../features/expenses/components/AddExpenseButton'
import { ExpenseList } from '../features/expenses/components/ExpenseList'
import { useMonthlyExpenses } from '../features/expenses/api/getMonthlyExpenses'
import { useMonthlyDashboard } from '../features/dashboard/api/getMonthlyDashboard'
import { useSelectedMonth } from '../features/dashboard/api/useSelectedMonth'
import { MonthlyDashboardView } from '../features/dashboard/components/MonthlyDashboardView'
import { MonthSelector } from '../features/month-selector/components/MonthSelector'
import { formatMonthLabel } from '../lib/months'

export function DashboardPage() {
  const { monthKey, goToNextMonth, goToPreviousMonth, resetToCurrentMonth } = useSelectedMonth()
  const dashboardQuery = useMonthlyDashboard(monthKey)
  const expensesQuery = useMonthlyExpenses(monthKey)

  return (
    <main className="mx-auto flex min-h-screen w-full max-w-7xl flex-col gap-8 px-4 py-6 md:px-8 lg:px-12">
      <section className="glass-panel overflow-hidden p-8">
        <div className="grid gap-8 lg:grid-cols-[1.4fr_1fr]">
          <div className="rounded-[32px] bg-stone-900 px-8 py-10 text-white">
            <p className="section-title text-white/70">Monthly expense dashboard</p>
            <h1 className="mt-4 max-w-xl text-5xl font-semibold tracking-tight">A polished, easy way to understand where your money goes every month.</h1>
            <p className="mt-4 max-w-2xl text-base text-white/80">Review {formatMonthLabel(monthKey)}, capture new spending quickly, and move through previous months without losing context.</p>
            <div className="mt-8">
              <MonthSelector monthKey={monthKey} onNext={goToNextMonth} onPrevious={goToPreviousMonth} onReset={resetToCurrentMonth} />
            </div>
          </div>
          <AddExpenseButton monthKey={monthKey} />
        </div>
      </section>

      <section className="grid gap-6 lg:grid-cols-[1.1fr_0.9fr]">
        <MonthlyDashboardView dashboard={dashboardQuery.data} isError={dashboardQuery.isError} isLoading={dashboardQuery.isLoading} />
        <ExpenseList isLoading={expensesQuery.isLoading} items={expensesQuery.data?.items ?? []} />
      </section>
    </main>
  )
}
