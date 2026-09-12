# Ecommerce Architecture

## Solution structure

- `Ecommerce.Domain`: business entities, enums and domain rules. No EF Core, ASP.NET Core or external service dependencies.
- `Ecommerce.Application`: use-case contracts, repository abstractions, DTOs/commands/queries and application business orchestration.
- `Ecommerce.Infrastructure`: EF Core, SQL Server, ASP.NET Core Identity, repositories and external integrations.
- `Ecommerce.Api`: HTTP boundary, controllers, middleware, authentication/authorization configuration and composition root.

## Domain organization

The Domain entities are grouped by business module instead of keeping one large flat `Entities` folder:

- `Entities/Catalog`: products, variants, categories, brands and product attributes/images.
- `Entities/Commerce`: addresses, carts, wishlists and orders.
- `Entities/Operations`: inventory, payments, refunds and shipping.
- `Entities/Marketing`: coupons, promotions and flash sales.
- `Entities/CustomerExperience`: loyalty, returns, reviews, product Q&A, notifications and audit logs.

This is an organizational boundary inside the Domain layer; the entities remain free of infrastructure concerns.

## Identity

Authentication and role management use ASP.NET Core Identity through `ApplicationUser : IdentityUser`. The business tables reference `AspNetUsers.Id` rather than implementing a second user system.

## Main domain areas

Catalog, inventory, carts, orders, payments, shipping, coupons, promotions, flash sales, loyalty points, returns, reviews, product Q&A, notifications and audit logging.

## Local database

The default development connection points to SQL Server LocalDB using database `EcommerceDb`. Generate migrations from `Ecommerce.Infrastructure` after restoring packages.
