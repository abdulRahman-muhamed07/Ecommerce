# Ecommerce Architecture

This solution follows a pragmatic Clean Architecture structure suitable for a mid-level production-style .NET backend.

## Dependency direction

`Api -> Application -> Domain`

`Infrastructure -> Application + Domain`

The Domain does not reference EF Core, ASP.NET Core, Identity, SQL Server, or external providers.

## Solution structure

```text
src/
├── Ecommerce.Domain/
│   ├── Common/
│   │   └── BaseEntity.cs
│   ├── Entities/
│   │   ├── Catalog/
│   │   ├── Commerce/
│   │   ├── Operations/
│   │   ├── Marketing/
│   │   └── CustomerExperience/
│   └── Enums/
│
├── Ecommerce.Application/
│   ├── Abstractions/
│   │   └── Persistence/
│   └── Features/              # use cases are added here by feature
│
├── Ecommerce.Infrastructure/
│   ├── Identity/
│   ├── Persistence/
│   │   ├── Configurations/
│   │   ├── Repositories/
│   │   └── ApplicationDbContext.cs
│   └── Services/              # external integrations and technical services
│
└── Ecommerce.Api/
    ├── Controllers/
    ├── Middleware/
    └── Extensions/
```

## Domain rule

Each database table has one Domain entity file. Related entities are grouped only by business area, not merged into large files.

## EF Core

Entity mappings live under `Infrastructure/Persistence/Configurations` and implement `IEntityTypeConfiguration<T>`. `ApplicationDbContext` only composes those configurations with `ApplyConfigurationsFromAssembly`.

## Identity

ASP.NET Core Identity owns authentication and authorization through `ApplicationUser : IdentityUser`. Business entities reference `AspNetUsers.Id` instead of creating a second user system.

## Feature growth

Application code is organized by use case/feature (for example `Catalog/Products` or `Orders`) rather than mirroring the database tables. A feature may contain Commands, Queries, DTOs, Validators and Handlers as it grows.
