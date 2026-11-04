# WarehouseMVC

ASP.NET Core MVC application built with a layered (onion-style) architecture and **Microsoft SQL Server** as the data store.

## Tech stack
- ASP.NET Core MVC, ASP.NET Core Identity
- Entity Framework Core (code-first, SQL Server, migrations)
- Layers: `Domain` · `Application` · `Infrastructure` · `Web` · `Tests`

## Running locally
1. Copy `WarehouseMVC.Web/appsettings.example.json` to `appsettings.json` and set your SQL Server connection string. Keep the SMTP password out of files: `dotnet user-secrets set "Outlook:Password" "..." --project WarehouseMVC.Web`.
2. Apply migrations: `dotnet ef database update --project WarehouseMVC.Infrastructure --startup-project WarehouseMVC.Web`
3. Run: `dotnet run --project WarehouseMVC.Web`

> Configuration files with credentials are intentionally not committed.
