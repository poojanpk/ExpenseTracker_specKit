import clsx from 'clsx'
import type { HTMLAttributes, PropsWithChildren } from 'react'

export function Card({ children, className, ...props }: PropsWithChildren<HTMLAttributes<HTMLDivElement>>) {
  return (
    <div className={clsx('glass-panel p-6', className)} {...props}>
      {children}
    </div>
  )
}
