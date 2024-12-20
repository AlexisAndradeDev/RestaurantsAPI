# RestaurantsAPI

This project is built using ASP.NET Core 8 and follows the Clean Architecture principles. The API is designed to manage restaurant-related data and provides a solid foundation for future enhancements.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Future Features](#future-features)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [Contributing](#contributing)

## Features

- Clean architecture with well-defined layers: Domain, Application, Infrastructure, and Presentation.
- Entity Framework for data access and manipulation.
- Implementation of extensions, seeders, repositories and DTOs.

## Technologies Used

- ASP.NET Core 8
- Entity Framework Core
- SQL Server Express
- C#

## Future Features

The following features are planned for implementation over the course of a few weeks:

- Automapper for DTOs
- CQRS (Command Query Responsibility Segregation)
- Support for subentities
- Authentication and authorization mechanisms
- Results pagination
- Automated testing
- Integration with Azure
- CI/CD pipelines

## Project Structure

The project is organized into the following layers:

- **Domain**: Contains the core business logic and entities.
- **Application**: Holds the application logic that connects the Domain layer with the Infrastructure and Presentation layers.
- **Infrastructure**: Responsible for data access, including repositories and database context.
- **Presentation**: The API layer that exposes endpoints for client interaction.

## Getting Started

To get started with the RestaurantsAPI, follow these steps:

1. **Clone the repository:**

   ```bash
   git clone https://github.com/AlexisAndradeDev/RestaurantsAPI.git
   ```
   
   For SSH:
   
   ```bash
   git clone git@github.com:AlexisAndradeDev/RestaurantsAPI.git
   ```

2. **Install dependencies:**

   Ensure that the .NET SDK is installed. The required packages can be installed using:

   ```bash
   dotnet restore
   ```

3. **Configure SQL Server Express:**

   Ensure that SQL Server Express is installed and running on the machine. Update the connection string in the `appsettings.json` file to point to the SQL Server Express instance.

4. **Run the application:**

   The application can be run using:

   ```bash
   dotnet run
   ```

5. **Access the API:**

   The API will be available at the following URLs based on the launch settings:

   - HTTP: `http://localhost:5120/api/restaurants`
   - HTTPS: `https://localhost:7069/api/restaurants`
