# WarehouseMVC – Recruitment & Onboarding System

> Despite its historical project name, WarehouseMVC is an internal **recruitment and employee onboarding system**. I built it while working in HR & payroll to replace e-mail threads and spreadsheets with one application backed by **Microsoft SQL Server**.

The app follows a candidate from the first application to the final payroll sign-off. Every department along the way approves or rejects the hire in the same system.

---

## ✨ Features

**Candidate pipeline**
- Candidate records with contact data, attached documents, target company and group leader
- Multi-step hiring approval: **Recruitment → Controlling → CFO → Payroll**. Each step can accept or deny, and a rejection reason is stored
- Employment details: start date and contract type (employment contract, B2B, civil-law contract)
- Search and server-side paging on every list

**Onboarding questionnaire**
- HR sends the new hire a personalised link by e-mail, with documents attached
- The candidate fills in a personal data questionnaire online. It replaces the paper form used for medical referrals and tax documents

**Inbound contact form**
- Public form with file attachments. The message is forwarded to the HR mailbox and saved in the database

**Client registry**
- Clients with tax ID (NIP), REGON, CEO, logo and addresses
- Contact details normalised into `ContactDetail` / `ContactDetailType` tables instead of fixed columns
- Soft delete (`IsActive`), so history stays consistent
- In-browser document preview (GroupDocs.Viewer)

**Security & operations**
- ASP.NET Core Identity with **role-based access** (`Admin`, `Recruitment`, `Controlling`, `Manager`, `Payroll`) and claims-based policies
- File logging with Serilog

---

## 🏗️ Architecture

The solution uses a layered (onion-style) architecture:

```
WarehouseMVC.Domain          → entities, enums, repository interfaces
WarehouseMVC.Application     → services, view models, AutoMapper profiles, FluentValidation
WarehouseMVC.Infrastructure  → EF Core DbContext, repositories, migrations
WarehouseMVC.Web             → ASP.NET Core MVC (controllers, Razor views, Identity UI)
WarehouseMVC.Tests           → xUnit test project
```

## 🗄️ Database

- **Microsoft SQL Server** with **Entity Framework Core** (code-first)
- 13 domain tables plus the ASP.NET Identity schema
- Relationships configured with Fluent API (e.g. one-to-one `Customer` ↔ `CustomerContactInformation`) and one-to-many links for companies, group leaders, addresses and contact details
- Schema history kept in EF Core migrations (Nov 2020 – Mar 2021)

## 🧰 Tech stack

| Area | Technology |
|---|---|
| Framework | .NET Core 3.1, ASP.NET Core MVC, Razor |
| Data | SQL Server, Entity Framework Core 3.1, Fluent API, Migrations |
| Auth | ASP.NET Core Identity, roles & claims policies |
| Libraries | AutoMapper, FluentValidation, ReflectionIT.Mvc.Paging, Serilog, GroupDocs.Viewer, Bogus |
| UI | Bootstrap 4, jQuery |
| Tests | xUnit |

---

## 🚀 Running locally

**Prerequisites:** .NET Core 3.1 SDK, SQL Server (LocalDB or full instance), `dotnet-ef` tool.

1. Copy `WarehouseMVC.Web/appsettings.example.json` to `WarehouseMVC.Web/appsettings.json` and set your SQL Server connection string.
2. Keep the SMTP password out of files:
   ```bash
   dotnet user-secrets set "Outlook:Password" "<your-password>" --project WarehouseMVC.Web
   ```
3. Create the database:
   ```bash
   dotnet ef database update --project WarehouseMVC.Infrastructure --startup-project WarehouseMVC.Web
   ```
4. Run the app:
   ```bash
   dotnet run --project WarehouseMVC.Web
   ```
5. Register a user and assign roles (`Admin`, `Recruitment`, `Controlling`, `Manager`, `Payroll`) in the `AspNetRoles` / `AspNetUserRoles` tables.

> Configuration files with credentials are intentionally not committed (see `.gitignore`).

## 🗺️ Possible next steps

- Upgrade to a current LTS version of .NET
- Cover the approval workflow with unit and integration tests
- Move reporting queries (hiring funnel, time-to-hire) into SQL views or stored procedures
