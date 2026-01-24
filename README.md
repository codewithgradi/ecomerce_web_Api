🛒 E-Commerce Web API
A robust, scalable RESTful API built with ASP.NET Core designed to power modern e-commerce platforms. This API handles everything from product catalogs and shopping carts to secure checkout and order management.

✨ Features
Product Management: CRUD operations, category filtering, and inventory tracking.

Shopping Cart: Persistent cart management for authenticated and guest users.

Order Processing: Secure checkout flow with status tracking (Pending, Shipped, Delivered).

Identity & Security: JWT-based authentication with Role-Based Access Control (RBAC).

Search & Filtering: Advanced filtering by price, brand, and rating.

Payment Integration: Mock integration for Stripe/PayPal (easily extensible).

🛠 Tech Stack
Framework: ASP.NET Core 10.0 (Web API)

Database: SQL Server / PostgreSQL

ORM: Entity Framework Core

Authentication: JWT (JSON Web Tokens) & ASP.NET Core Identity

Mapping: AutoMapper

Documentation: Swagger (OpenAPI)

Testing: xUnit & Moq

🏗 Architecture
This project follows Repository Architecture principles to ensure maintainability and separation of concerns:


API: Controllers, Middlewares, and Configurations.

🚀 Getting Started
Prerequisites
.NET 8.0 SDK

SQL Server or Docker

An IDE (Visual Studio 2022, VS Code, or JetBrains Rider)
