import clsx from 'clsx'
import type { ButtonHTMLAttributes, PropsWithChildren } from 'react'

type ButtonProps = PropsWithChildren<ButtonHTMLAttributes<HTMLButtonElement>> & {
  variant?: 'primary' | 'secondary' | 'ghost'
}

export function Button({ children, className, variant = 'primary', ...props }: ButtonProps) {
  return (
    <button
      className={clsx(
        'inline-flex items-center justify-center rounded-full px-4 py-2 text-sm font-semibold transition duration-200',
        variant === 'primary' && 'bg-stone-900 text-white hover:bg-stone-800',
        variant === 'secondary' && 'bg-white text-stone-900 ring-1 ring-stone-200 hover:bg-stone-50',
        variant === 'ghost' && 'bg-transparent text-stone-700 hover:bg-white/60',
        className,
      )}
      {...props}
    >
      {children}
    </button>
  )
}
