import { Outlet } from 'react-router-dom'

export function App() {
  return (
    <div className="min-h-screen bg-[radial-gradient(circle_at_top,_rgba(225,88,88,0.18),_transparent_28%),linear-gradient(180deg,_#f8f0df_0%,_#f4efe6_45%,_#efe7d6_100%)] text-stone-900">
      <Outlet />
    </div>
  )
}
