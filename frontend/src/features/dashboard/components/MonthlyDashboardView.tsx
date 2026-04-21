import { Card } from '../../../components/ui/Card'
import type { MonthlyDashboard } from '../../../services/api/types'
import { CategoryBreakdown } from './CategoryBreakdown'
import { SummaryCards } from './SummaryCards'

type MonthlyDashboardViewProps = {
  dashboard?: MonthlyDashboard
  isLoading: boolean
  isError: boolean
}

export function MonthlyDashboardView({ dashboard, isLoading, isError }: MonthlyDashboardViewProps) {
  if (isLoading) {
    return <Card>Loading dashboard...</Card>
  }

  if (isError || !dashboard) {
    return <Card>Dashboard data could not be loaded.</Card>
  }

  if (!dashboard.hasExpenses) {
    return <Card>No expenses recorded for this month yet.</Card>
  }

  return (
    <div className="space-y-4">
      <SummaryCards expenseCount={dashboard.expenseCount} totalSpent={dashboard.totalSpent} />
      <CategoryBreakdown items={dashboard.categoryBreakdown} />
    </div>
  )
}
