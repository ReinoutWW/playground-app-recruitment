import { useState } from 'react'
import './App.css'

function GlassCard({ children }: { children: React.ReactNode }) {
  return (
    <div
      className="rounded-glass border border-c-primary-α20 bg-c-primary-α20 backdrop-blur-xl shadow-glass-inner p-8 max-w-md mx-auto mt-16"
      style={{ boxShadow: 'inset 0 1px 0 rgba(255,255,255,.35)' }}
    >
      {children}
    </div>
  )
}

export default function App() {
  const [theme, setTheme] = useState<'light' | 'dark'>(
    window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light'
  )

  // Apply theme to root
  document.documentElement.setAttribute('data-theme', theme)

  return (
    <div className="min-h-screen bg-c-surface flex flex-col items-center justify-center transition-colors">
      <button
        className="mb-8 px-4 py-2 rounded-neumorph shadow-neumorph bg-c-surface-alt border border-c-stroke text-c-text hover:brightness-105 transition"
        onClick={() => setTheme(theme === 'light' ? 'dark' : 'light')}
      >
        Switch to {theme === 'light' ? 'Dark' : 'Light'} Mode
      </button>
      <GlassCard>
        <h1 className="text-3xl font-bold text-c-primary mb-2">Recruiter Platform</h1>
        <p className="text-c-text mb-4">Modern glassmorphism + neumorphism foundation</p>
        <div className="text-c-muted text-sm">Frontend and backend are ready for development.</div>
      </GlassCard>
    </div>
  )
}
