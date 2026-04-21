import { useSearchParams } from 'react-router-dom'
import { getCurrentMonthKey, shiftMonth } from '../../../lib/months'

export function useSelectedMonth() {
  const [searchParams, setSearchParams] = useSearchParams()
  const monthKey = searchParams.get('month') ?? getCurrentMonthKey()

  const setMonthKey = (nextMonthKey: string) => {
    const nextParams = new URLSearchParams(searchParams)
    nextParams.set('month', nextMonthKey)
    setSearchParams(nextParams)
  }

  return {
    monthKey,
    setMonthKey,
    goToPreviousMonth: () => setMonthKey(shiftMonth(monthKey, -1)),
    goToNextMonth: () => setMonthKey(shiftMonth(monthKey, 1)),
    resetToCurrentMonth: () => setMonthKey(getCurrentMonthKey()),
  }
}
