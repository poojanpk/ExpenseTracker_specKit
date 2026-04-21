import { test, expect } from '@playwright/test'

test('dashboard page renders expense tracker shell', async ({ page }) => {
  await page.goto('/')

  await expect(page.getByText(/monthly expense dashboard/i)).toBeVisible()
  await expect(page.getByRole('button', { name: /add expense/i })).toBeVisible()
})
