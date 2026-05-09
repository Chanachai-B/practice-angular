# Practice

โปรเจคเขียนด้วย .NET + Angular

## Tech Stack

**Backend**
- .NET 10 / ASP.NET Core Web API
- Entity Framework Core 10 + PostgreSQL
- MediatR (CQRS)

**Frontend**
- Angular 21 (Standalone Components)
- PrimeNG 21 (UI Component Library)
- Tailwind CSS v4
- Angular CDK

**Infrastructure**
- Docker (PostgreSQL)

---

## Requirements

| Tool | Version |
|------|---------|
| .NET SDK | 10.0+ |
| Node.js | 20+ |
| Docker Desktop | Latest |

---

## Getting Started

### 1. Clone & เข้า folder

```bash
git clone <repo-url>
cd practice
```

### 2. รัน Database

```bash
docker compose up -d
```

### 3. รัน Backend

```bash
cd API
dotnet run
```

API จะรันที่ `http://localhost:5047`
Swagger UI: `http://localhost:5047/swagger`

> ตอน startup API จะ **migrate database และ seed ข้อมูลตัวอย่าง 25 รายการให้อัตโนมัติ** ไม่ต้องทำอะไรเพิ่ม

### 4. รัน Frontend

```bash
cd Frontend
npm install
ng serve
```

Frontend จะรันที่ `http://localhost:4200`

---

## Project Structure

```
practice/
├── Domain/                  # Entities
├── Application/             # CQRS Handlers, Interfaces, Common
│   ├── Common/              # PaginatedResult, QueryableExtensions, IDbContext
│   └── IT01/                # List, Detail, Create Handlers
├── Infrastructure/          # EF Core, Migrations, Seed Data
├── API/                     # Controllers, Program.cs
├── Frontend/                # Angular Application
│   └── src/app/
│       ├── core/            # Models, Pagination
│       ├── models/          # Interfaces
│       ├── services/        # HTTP Services
│       ├── resolvers/       # Route Resolvers
│       └── features/it01/   # Pages & Components
└── docker-compose.yml
```

---

## Database

```
Host:     localhost:5432
Database: it_practice_db
Username: postgres
Password: password
```