# ASP.NET Core Web API

This repository contains two Web API projects built with ASP.NET Core:

1. **Todo API** - A simple Todo API using in-memory storage.
2. **Bookstore API** - A bookstore API using MongoDB as the database.

## Prerequisites

Before running the project, ensure you have the following installed:

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download)
- [MongoDB](https://www.mongodb.com/try/download/community) (for the Bookstore API)
- MongoDB Compass (optional, for database visualization)

## Getting Started

### Todo API

The Todo API is a basic implementation of a task management system. It uses in-memory storage, meaning that all data will be lost when the application stops.

#### Features:
- Create, Read, Update, and Delete (CRUD) operations for managing tasks
- In-memory data store

### Bookstore API

The Bookstore API allows you to manage a collection of books. It uses MongoDB for data persistence.

#### Features:
- CRUD operations for books
- MongoDB as the database

## Project Structure

```plaintext
├── TodoApi/               # ToDo API project folder
├── BookstoreApi/           # Bookstore API project folder
└── README.md               # Project documentation
