# ISA Platform Backend Development Project

## Overview

This repository serves as the codebase for the ISA Platform Backend Development project, providing essential information and guidance.

## Project Description

The ISA Platform Backend Development project focuses on creating a robust RESTful API to support Integrated Systems Architecture (ISA) operations. It facilitates the management of products and maintenance activities within the ISA Platform ecosystem. The API is developed using C#, .NET 7, and ASP.NET Core Framework, with data storage managed in a MySQL database.

## Endpoints

### Products Endpoint:

- **Operations**: 
  - POST (Add Product)
  - GET (Retrieve Product by ID)
- **URL**: `/api/v1/products`

### Maintenance Activities Endpoint:

- **Operation**: 
  - POST (Add Maintenance Activity)
- **URL**: `/api/v1/maintenance-activities`

## Technologies

- Programming Languages: C#, .NET 7
- Framework: ASP.NET Core
- Design Patterns: Domain-Driven Design (DDD)
- Database: MySQL (Schema: 'isa')
