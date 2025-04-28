# POS System API

A robust Point of Sale (POS) system built with .NET 8, designed to manage sales, inventory, and customer data efficiently. This project is modular, leveraging clean architecture principles for scalability and maintainability.

## Features

- **Authentication**: Secure user authentication using JWT Bearer tokens.
- **Entity Framework Core**: Database management with support for SQL Server.
- **API Documentation**: Integrated Swagger UI for API exploration and testing.
- **Dependency Injection**: Simplified service management with MediatR and AutoMapper.

## Project Structure

- **POS.API**: The entry point of the application, hosting the web API.
- **POS.Application**: Contains business logic and application services.
- **POS.Infrastructure**: Handles external integrations and infrastructure concerns.
- **POS.Persistence**: Manages database context and migrations.
- **POS.Domain**: Defines core domain models and business rules.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (for database)
