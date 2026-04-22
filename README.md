# Bulky Book — ASP.NET Core E-Commerce Platform

ASP.NET Core e-commerce application demonstrating full-stack architecture with authentication, role-based authorization, payment processing, and admin-driven order management.

---

## Overview

Bulky Book is a server-rendered e-commerce platform built with ASP.NET Core. It focuses on building a production-style architecture for managing products, user sessions, orders, and payments.

Core focus areas:
- Full-stack ASP.NET MVC architecture
- Secure authentication and authorization
- Order lifecycle management
- Payment integration with Stripe
- Admin vs customer role separation

---

## Key Features

- Product browsing and catalog management  
- Shopping cart and checkout flow  
- Stripe-based payment processing  
- Order creation and admin order management  
- Role-based authentication (Admin / Customer)  
- User registration and secure login system  
- Email notifications for order events  
- Session-based cart persistence  
- Social login integration (Google, Facebook)  

---

## Technical Stack

- ASP.NET Core MVC  
- C#  
- Entity Framework Core  
- SQL Server  
- ASP.NET Identity  
- Stripe API  

---

## Architecture Overview

The application follows a layered MVC structure:

- **Controllers** — Request handling and application flow  
- **Views** — Razor UI rendering layer  
- **Models** — Domain entities and data contracts  
- **Data Layer** — DbContext and migrations (Entity Framework Core)  
- **Services Layer** — Business logic and external service integrations  

This separation supports maintainability and scalable feature extension.

---

## Key Engineering Decisions

- Used ASP.NET Identity for secure authentication and role-based authorization  
- Structured order processing to separate cart state from finalized orders  
- Integrated Stripe to handle external payment workflows securely  
- Designed session-based cart handling for stateless HTTP compatibility  

---

## What This Project Demonstrates

- Full-stack ASP.NET Core MVC application design  
- Authentication and authorization system implementation  
- Payment gateway integration (Stripe)  
- Database-driven application architecture using EF Core  
- Separation of concerns in backend system design  

---

## Getting Started

To run locally:

1. Clone repository  
2. Open in Visual Studio or compatible IDE  
3. Configure `appsettings.json` (database + Stripe keys)  
4. Run Entity Framework migrations  
5. Restore dependencies  
6. Run application  

---

## Context

This project was built as a practical exercise in full-stack .NET development, focusing on real-world patterns such as authentication flows, payment processing, and layered architecture design.
