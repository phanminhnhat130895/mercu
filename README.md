# mercu test

# FE Project Setup and Run Guide

This guide will walk you through setting up and running an Angular project on your local machine.

## Prerequisites

Before you begin, ensure you have the following installed:

- [Node.js](https://nodejs.org/): This project requires Node.js version 18.17.1 or later.
- npm: npm is distributed with Node.js.

## Setup

1. **Install Angular CLI**: Angular CLI is a command-line interface tool that you use to initialize, develop, scaffold, and maintain Angular applications. Install it globally using npm:

    ```bash
    npm install -g @angular/cli@16.2.2
    ```

2. **Navigate to Your Project**: Change your working directory to the webapp project:

    ```bash
    cd your-path\mercu\WebApp\webapp
    ```

3. **Install Package**: Install node_modules for the webapp project:

    ```bash
    npm install
    ```

## Run the Project

1. **Development Server**: Use Angular CLI to serve your application locally. This command will start a development server and open your default web browser to `http://localhost:4200/`:

    ```bash
    npm start
    ```

2. **Open in Browser**: Once the development server is running, open your web browser and navigate to `http://localhost:4200/` (or the specified host and port).

# .NET 8 Web API Setup and Migration Guide

This guide provides instructions for setting up and running a .NET 8 Web API project with database migrations.

## Prerequisites

Before you begin, ensure you have the following installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
- [Entity Framework Core Tools](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)

## Setup

1. **Update Connection String in the appsettings.json**:

    Open appsettings.json file and update the section: ConnectionStrings:DefaultConnection

1. **Navigate to WebAPI Project**: 
    
    ```bash
    cd your-path\mercu\WebAPI\WebAPI
    ```

2. **Restore Nuget Packages**: 

    ```bash
    dotnet restore
    ```

3. **Apply Migrations**: 

    ```bash
    dotnet ef database update
    ```

4. **Build Project**: 

    ```bash
    dotnet build
    ```

## Run the Project

1. **Navigate to build folder of WebAPI Project**: 
    
    ```bash
    cd your-path\mercu\WebAPI\WebAPI\bin\Debug\net8.0
    ```

1. **Run the WebAPI Project**: 

    ```bash
    dotnet WebAPI.dll
    ```