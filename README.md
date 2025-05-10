 Backend API – .NET Clean Architecture

A scalable and maintainable *.NET Core Web API* project built using *Clean Architecture principles*.  
Designed with a focus on modularity, testability, and separation of concerns.

Key Features

Clean Architecture* – Separation of concerns between layers (API, Application, Domain, Infrastructure)
 *MediatR* – Implements CQRS pattern for handling commands and queries
*FluentValidation* – Declarative request validation
*Repository Pattern + Unit of Work* – Clean data access logic
*Custom Middlewares* – Centralized error handling, logging, authentication
*Fast Endpoints / Controllers* – Fastend points
*Pagination* – Built-in support for paginated responses


src/
├── API
│ ├──  API endpoints
│ ├── Middlewares/
│ └── Program.cs
│
├── Application/ // Business logic layer
│ ├── Features/ // CQRS: Commands and Queries
│ ├── DTOs/ // Data transfer objects
│ ├── Interfaces/ // Service contracts
│ └── Validations/ // FluentValidation rules
│
├── Domain/ // Core business entities and interfaces
│ ├── Entities/
│ ├── Enums/
│ └── Interfaces/
|
├── Persistence/ // EF Core DbContext & Unit of Work & Implementation of domain
│ └── ApplicationDbContext.cs
| ├── Repositories
│
└── Shared
