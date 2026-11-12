# ASP.NET Core Identity & Clean Architecture

A hands-on project exploring ASP.NET Core Identity and its integration with Clean Architecture, focusing on framework internals, separation of concerns, and practical design patterns.

## Key Concepts

- **ASP.NET Core Identity:** UserManager, RoleManager, PasswordHasher, Claims, and JWT authentication.
- **Clean Architecture:** Separation into Domain, Application, Infrastructure, and API layers.
- **Design Patterns:**
  - **Factory Method:** Used in `AuthResult` to control success and failure result creation.
  - **Facade Pattern:** `AuthFacade` provides a unified entry point while delegating authentication and role management to specialized services.

## Tech Stack

- .NET 10
- ASP.NET Core Identity
- Entity Framework Core
- SQLite
- JWT Bearer Authentication
- Swagger / OpenAPI

## Getting Started

1. Clone the repository.
2. Restore dependencies:

   `dotnet restore`

3. Apply database migrations:

   `dotnet ef database update --project src/IdentitySystem.Infrastructure --startup-project src/IdentitySystem.API`

4. Run the API:

   `dotnet run --project src/IdentitySystem.API`

## Implementation Notes

- The first registered user is automatically assigned the `Admin` role.
- SQLite is used as the database provider for simplicity.
- Refresh token support and advanced production-oriented features are outside the scope of this project.
