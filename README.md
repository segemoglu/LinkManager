# LinkManager

A central link portal for company employees: every intranet service, external
site and reporting screen people use daily, collected on one searchable page and
managed by admins from the browser.

Built during my software engineering internship at **Ferre (Femaş Metal A.Ş.)**
in February 2026 and deployed to the company's IIS server.

## Features

- **Card-based home page** — each link is a card with a title, description,
  category badge, Font Awesome icon and colour; clicking a card opens the site in
  a new tab
- **Live search** — filters links by title or category as you type
- **Admin panel** — cookie-based login; only signed-in admins see the add, edit
  and delete actions, and the add/edit pages are protected with `[Authorize]`
- **Safe editing** — required-field validation on forms and a SweetAlert2
  confirmation before deleting a link
- **Dark / light theme** toggle

## Tech stack

ASP.NET Core 8 · Blazor Web App (Interactive Server) · Entity Framework Core
(SQL Server, Code-First migrations) · MediatR · Bootstrap 5 · Font Awesome ·
SweetAlert2

## Architecture

The app follows a **Vertical Slice Architecture** with **CQRS**: every
operation is a separate MediatR request with its own handler, grouped by
feature instead of by technical layer.

```
LinkManager/
├── Feature/Links/
│   ├── Commands/        CreateLink · UpdateLink · DeleteLink
│   └── Queries/         GetLinks · GetLinkById
├── Domain/              LinkItem · User
├── Infrastructure/      AppDbContext (EF Core)
├── Controllers/         LoginController (cookie sign-in / sign-out)
├── Components/          Blazor pages (Home, LinkEkle, LinkDuzenle, Login) and layout
└── Migrations/          EF Core Code-First migrations
```

Blazor pages never touch the database directly; they send commands and queries
through MediatR, e.g. `await Mediator.Send(new DeleteLinkCommand(link.Id))`.

## Getting started

Requirements: .NET 8 SDK and SQL Server (LocalDB works for development).

1. Set the connection string in `LinkManager/appsettings.json`
   (`ConnectionStrings:DefaultConnection`). The default points to LocalDB.
2. Create the database from the migrations:

   ```bash
   dotnet tool install --global dotnet-ef
   dotnet ef database update --project LinkManager
   ```

3. Add an admin account to the `Users` table (`Username`, `Password`, `FullName`).
4. Run the app:

   ```bash
   dotnet run --project LinkManager
   ```

## Next steps

- Hash admin passwords (e.g. ASP.NET Core Identity's `PasswordHasher`) instead
  of storing them in plain text
- Remember the selected theme between visits
