/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}"
  ],
  theme: {
    extend: {
      colors: {
        'c-primary': 'var(--c-primary)',
        'c-primary-α20': 'var(--c-primary-α20)',
        'c-surface': 'var(--c-surface)',
        'c-surface-alt': 'var(--c-surface-alt)',
        'c-stroke': 'var(--c-stroke)',
        'c-text': 'var(--c-text)',
        'c-muted': 'var(--c-muted)',
      },
      borderRadius: {
        '3xl': '1.5rem',
        'glass': '24px',
      },
      boxShadow: {
        'glass-inner': 'inset 0 1px 0 rgba(255,255,255,.35)',
        'neumorph': '4px 4px 8px rgba(0,0,0,0.08), -4px -4px 8px rgba(255,255,255,0.6)',
      },
    },
  },
  plugins: [require('@tailwindcss/forms')],
}; 