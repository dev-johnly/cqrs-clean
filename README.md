
# CQRS Clean Architecture API Template

[![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-5C2D91?style=for-the-badge&logo=dotnet&logoColor=white)](https://learn.microsoft.com/en-us/aspnet/core/)
[![MediatR](https://img.shields.io/badge/MediatR-003366?style=for-the-badge&logo=.net&logoColor=white)](https://github.com/jbogard/MediatR)
[![Mapster](https://img.shields.io/badge/Mapster-4B8BBE?style=for-the-badge&logo=mapbox&logoColor=white)](https://github.com/MapsterMapper/Mapster)
[![Entity Framework](https://img.shields.io/badge/EF_Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://learn.microsoft.com/en-us/ef/core/)
[![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)](https://swagger.io/)
[![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)](https://www.microsoft.com/en-us/sql-server/)
[![BCrypt](https://img.shields.io/badge/BCrypt.Net--Next-222222?style=for-the-badge&logo=lock&logoColor=white)](https://github.com/BcryptNet/bcrypt.net)

A clean and modular ASP.NET Core Web API template following the **Clean Architecture** and **CQRS (Command Query Responsibility Segregation)** patterns. This template uses **MediatR**, **Mapster**, and **EF Core**, and is ready for scalable enterprise-grade APIs.

---

## Features

- ✅ Clean Architecture structure (Domain, Application, Infrastructure, API)
- ✅ CQRS implementation using MediatR
- ✅ BCrypt password hashing for secure authentication
- ✅ Mapster for fast and lightweight object mapping
- ✅ EF Core + SQL Server as the default database provider
- ✅ Swagger support out of the box
- ✅ SOLID principles & separation of concerns

---

## Technologies Used

| Tool              | Description                                 |
|-------------------|---------------------------------------------|
| [ASP.NET Core]    | Web framework for building modern APIs      |
| [MediatR]         | CQRS with in-process messaging              |
| [Mapster]         | Lightweight object-to-object mapper         |
| [BCrypt.Net-Next] | Password hashing                            |
| [EF Core]         | ORM for database access                     |
| [Swagger]         | API documentation and testing UI            |
| [SQL Server]      | Relational database for persistence         |

## Getting Started

### 1. Clone the Repository
git clone https://github.com/yourusername/clean-architecture-api.git
cd clean-architecture-api

### 2. Update the connection string in appsettings.json.

### 3. Run database migrations:
dotnet ef database update

## Project Structure

```text
src/
├── Application/        - Application logic, CQRS handlers
├── Domain/             - Domain entities and interfaces
├── Infrastructure/     - Data access, external integrations
├── API/                - API endpoints and configuration
```

#### API Documentation
https://localhost:{port}/swagger

#### Contributing
Contributions are welcome. Fork the repo and submit a pull request.

### License
This project is licensed under the MIT License.
