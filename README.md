# OnBudget — E-Commerce Backend API

A RESTful backend API for an e-commerce platform built with **ASP.NET Core 7.0** and **Entity Framework Core**, following a clean 3-layer architecture.

## Features

- 🛒 **Order Management** — Create and manage customer orders with product quantities
- 📦 **Product Catalog** — Products with pictures, categories, and supplier associations
- 👤 **Customer & Supplier Accounts** — Registration, login, and profile management
- 🚚 **Shipper Management** — Manage shipping companies and their supplier associations
- 🔐 **JWT Authentication** — Secure token-based auth with BCrypt password hashing
- 🗂️ **Category Browsing** — Browse products by category with full product details

## Tech Stack

- **ASP.NET Core 7.0** — Web API framework
- **Entity Framework Core** — ORM with SQL Server
- **BCrypt.Net** — Password hashing
- **JWT Bearer Tokens** — Authentication
- **Swagger / OpenAPI** — API documentation

## Project Structure
```
OnBudget/          → API layer (Controllers, Program.cs)
OnBudget.BL/       → Business logic (Services, DTOs)
OnBudget.DA/       → Data access (Repositories, Entities, Migrations)
```

## Getting Started

1. Update the connection string in `appsettings.json`
2. Run migrations:
```bash
   dotnet ef database update --project OnBudget.DA --startup-project OnBudget
```
3. Run the API:
```bash
   dotnet run --project OnBudget
```
4. Open Swagger at `https://localhost:{port}/swagger`

## API Endpoints

| Resource | Endpoints |
|----------|-----------|
| Auth | `POST /api/login`, `POST /api/registration/customer`, `POST /api/registration/supplier` |
| Products | `GET /api/product`, `POST /api/product`, `PUT /api/product/{id}`, `DELETE /api/product/{id}` |
| Orders | `GET /api/order`, `POST /api/order`, `PUT /api/order/{id}`, `DELETE /api/order/{id}` |
| Categories | `GET /api/category`, `POST /api/category` |
| Customers | `GET /api/customer/{id}`, `PUT /api/customer/{id}` |
| Suppliers | `GET /api/supplier/{handle}`, `PUT /api/supplier/{handle}` |
| Shippers | `GET /api/shipper`, `POST /api/shipper`, `PUT /api/shipper/{id}` |
