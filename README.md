# Bulky Book Website - ASP.NET Core Project

Welcome to the Bulky Book Website ASP.NET Core project! This project showcases the development of a comprehensive e-commerce website where customers can browse, order products, and administrators can manage orders and transactions. Whether you're a beginner or an experienced developer, this project provides valuable insights into building real-world ASP.NET Core applications.

## Project Overview

The Bulky Book Website is a feature-rich e-commerce platform built using ASP.NET Core. The main functionalities of the project include:

- Browsing Products: Customers can explore a wide range of products available on the platform.

- Adding to Cart: Users can add products to their cart for purchasing.

- Order Placement: Customers can proceed to checkout and place orders using their credit cards.

- Order Management: Administrators have the ability to view, process, and manage orders.

- Authentication and Authorization: Secure user registration and login processes are implemented, and role-based authorization ensures appropriate access.

- Email Notifications: Users receive email notifications for order confirmation and other important updates.

- Social Logins: Google and Facebook login options provide convenient access for users.

- Payment Processing: Payments are accepted using the Stripe payment gateway.

- User Sessions: Sessions are managed to provide a seamless user experience.

## Getting Started

To get started with the Bulky Book Website project, follow these steps:

1. Clone this repository to your local machine.

2. Open the project in your preferred development environment (e.g., Visual Studio, Visual Studio Code).

3. Configure App Settings: Update the app settings with your database connection string, Stripe API keys, and other relevant configurations.

4. Set Up Database: Run Entity Framework migrations to set up the database schema.

5. Install Dependencies: Restore NuGet packages and ensure all dependencies are installed.

6. Run the Application: Build and run the application. Access it through your browser.

## Technologies Used

- ASP.NET Core: A powerful and flexible framework for building web applications.

- Entity Framework Core: An Object-Relational Mapping (ORM) tool for database operations.

- Identity Framework: Provides authentication and authorization capabilities.

- Stripe: A popular payment gateway for processing online payments.

## Project Structure

The project follows a structured architecture to ensure maintainability and scalability:

- **Controllers**: Handle user requests and manage application flow.

- **Views**: Render HTML templates to display the user interface.

- **Models**: Define data entities and business logic.

- **Data**: Contains database context and migration files.

- **Services**: Implement business logic and interactions with external services.
