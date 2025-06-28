# Recruiter Platform - Development Environment

A modern, internal-use recruiter platform built with React + Vite frontend and ASP.NET 9 Minimal APIs backend, following Clean Architecture principles.

## 🚀 Technology Stack

| Component | Technology | Version |
|-----------|------------|---------|
| **Frontend** | React 18 + Vite 5 + TypeScript 5 | Latest |
| **Styling** | Tailwind CSS + Headless UI | Latest |
| **State Management** | TanStack Query + Zustand | Latest |
| **Backend** | ASP.NET 9 Minimal APIs | 9.0.203 |
| **Database** | PostgreSQL 16 | Latest |
| **Caching** | Redis 7 | Latest |
| **Containerization** | Docker + Docker Compose | Latest |
| **Node.js** | Node.js 22 | 22.17.0 |

## 📋 Prerequisites

All dependencies have been installed and configured:

- ✅ **.NET 9 SDK** (9.0.203)
- ✅ **Node.js 22** (22.17.0)
- ✅ **Docker & Docker Compose**
- ✅ **PostgreSQL 16** (running in Docker)
- ✅ **Redis 7** (running in Docker)
- ✅ **Git, curl, wget, unzip**

## 🏗️ Architecture Overview

```
┌─────────────────┐    HTTPS    ┌─────────────────┐
│   React SPA     │ ←→ ASP.NET  │   Domain + App  │
│   (Vite)        │   (BFF)     │   (Core, Services)
└─────────────────┘             └─────────────────┘
                                         ↕
                                 Infrastructure
                                         ↕
                         PostgreSQL ─ Redis
```

### Clean Architecture Rings

```
┌─────────┐   Entities / VOs           (Core)
│  Core   │
├─────────┤   Application Services     (Use‑Cases)
│  App    │
├─────────┤   Adapters & Gateways      (Infra)
│ Infra   │
└─────────┘   Framework & Drivers      (Web/API)
```

## 🐳 Database Services

The following services are running via Docker Compose:

- **PostgreSQL 16**: `localhost:5432`
  - Database: `recruiter_platform`
  - User: `recruiter`
  - Password: `recruiter_password`

- **Redis 7**: `localhost:6379`

### Managing Services

```bash
# Start services
sudo docker compose up -d

# Stop services
sudo docker compose down

# View logs
sudo docker compose logs -f

# Check status
sudo docker ps
```

## 🎨 Design System

The platform implements a modern glassmorphism + neumorphism design inspired by Apple's Liquid Glass aesthetic:

- **Glassmorphism**: Translucent backgrounds with backdrop blur
- **Neumorphism**: Soft extrusion for interactive surfaces
- **Responsive**: Mobile-first 4pt baseline grid
- **Accessible**: WCAG AA compliance with motion preferences

### Color Palette

| Token | Light | Dark | Usage |
|-------|-------|------|-------|
| `--c-primary` | #5E9BFF | #3A6EFF | CTAs, accent icons |
| `--c-surface` | #F5F7FA | #111418 | Card backgrounds |
| `--c-text` | #0A0C10 | #F2F5F9 | Body copy |

## 🚀 Next Steps

### 1. Frontend Setup

```bash
# Create React + Vite project
npm create vite@latest frontend -- --template react-ts
cd frontend

# Install dependencies
npm install @tanstack/react-query @tanstack/react-router
npm install tailwindcss @tailwindcss/forms @headlessui/react
npm install framer-motion zustand zod react-hook-form
npm install -D @types/node autoprefixer postcss

# Initialize Tailwind CSS
npx tailwindcss init -p
```

### 2. Backend Setup

```bash
# Create ASP.NET 9 Minimal API project
dotnet new web -n RecruiterPlatform.Api
cd RecruiterPlatform.Api

# Install packages
dotnet add package MediatR
dotnet add package AutoMapper
dotnet add package FluentValidation
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package StackExchange.Redis
dotnet add package Serilog.AspNetCore
dotnet add package Swashbuckle.AspNetCore
```

### 3. Project Structure

```
playground-app-recruitment/
├── frontend/                 # React + Vite SPA
│   ├── src/
│   │   ├── app/             # TanStack Router routes
│   │   │   ├── jobs/        # Job postings
│   │   │   ├── candidates/  # Candidate database
│   │   │   └── notes/       # Notes & comments
│   │   └── shared/          # Shared components
│   └── package.json
├── backend/                  # ASP.NET 9 API
│   ├── src/
│   │   ├── Core/            # Domain entities
│   │   ├── Application/     # Use cases & DTOs
│   │   ├── Infrastructure/  # EF Core & Redis
│   │   └── Web/             # Minimal APIs
│   └── RecruiterPlatform.Api.csproj
├── docker-compose.yml        # Database services
└── README.md
```

## 🧪 Testing Strategy

| Level | Framework | Target |
|-------|-----------|--------|
| **Unit** | Vitest / xUnit | Pure functions, domain logic |
| **Integration** | Playwright Component / TestContainers | API + DB contracts |
| **E2E** | Playwright | Critical user journeys |
| **Load** | k6 | Performance testing |

## 🔒 Security & Compliance

- **Authentication**: Organization SSO integration
- **Data Protection**: AES-256 encryption at rest
- **API Security**: HTTPS/TLS 1.3, secure headers
- **Audit Trail**: Domain events for compliance
- **Static Analysis**: Dependabot, security scanning

## 📊 Monitoring & Observability

- **Tracing**: OpenTelemetry with W3C TraceContext
- **Metrics**: Prometheus exporter with Grafana dashboards
- **Logging**: Serilog → Loki, frontend → Sentry
- **Health Checks**: `/healthz` & `/ready` endpoints

## 🎯 Quality Attributes

| Attribute | Target |
|-----------|--------|
| **Performance** | < 200ms P95 API latency, < 2s TTI on 4G |
| **Scalability** | 10x traffic growth without code changes |
| **Maintainability** | ≤ 25% cyclomatic complexity, < 5min build |
| **Availability** | 99.9% monthly uptime |
| **Security** | OWASP ASVS L2 compliance |

## 🤝 Contributing

1. Follow Clean Architecture principles
2. Maintain ≤ 20 lines per function
3. Use descriptive naming conventions
4. Write tests for critical paths
5. Follow the established design patterns

## 📚 Resources

- [Clean Architecture by Uncle Bob](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [Domain-Driven Design](https://martinfowler.com/bliki/DomainDrivenDesign.html)
- [React + Vite Documentation](https://vitejs.dev/guide/)
- [ASP.NET 9 Minimal APIs](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis)

---

**Coding Vision**: *"Deliver recruiter-centric experiences through code that is simple to read, effortless to change, and architecturally robust."* 