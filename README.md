# Library Management System

## Table of Contents
1. [Overview](#overview)
2. [Technologies Used](#technologies-used)
3. [Features](#features)
4. [User Roles and Permissions](#user-roles-and-permissions)
5. [Project Structure](#project-structure)
6. [Setup and Installation](#setup-and-installation)
7. [How to Use](#how-to-use)
8. [Database Initialization](#database-initialization)
9. [Soft Delete Mechanism](#soft-delete-mechanism)
10. [Screenshots](#screenshots)
11. [API Documentation](#api-documentation)
12. [Error Handling](#error-handling)
13. [License](#license)

---

## Overview
The **Library Management System** is a web-based MVC project developed using **ASP.NET Core MVC** with cookie-based authentication and Identity management. The project allows for managing books and users with specific roles (Admin, Librarian, and Member). Soft delete and audit fields like `created date`, `updated date`, and `isDeleted` are implemented using a base entity class.

---

## Technologies Used
- **ASP.NET Core MVC**
- **Entity Framework Core**
- **ASP.NET Identity** (Cookie-based Authentication)
- **Repository Pattern**
- **Unit of Work Pattern**
- **DataTables** for data display
- **Toastr** for notifications
- **AutoMapper** for DTO mapping
- **SQL Server**

---

## Features
- User authentication with **ASP.NET Identity**
- Role-based access control for Admin, Librarian, and Member
- CRUD operations for books and users
- Soft delete functionality
- Logging `CreatedDate`, `UpdatedDate`, and `IsDeleted` for entities
- Datatable integration for displaying records
- Toastr notifications for user feedback
- Database initialization with seed data
- Structured **API endpoints** for managing users and books
- Global exception handling for consistent error management

---

## User Roles and Permissions
| Role       | Permissions                      |
|------------|----------------------------------|
| **Admin**  | Manage books (CRUD), manage users, assign roles |
| **Librarian** | Manage books (CRUD)             |
| **Member** | View books                       |

---

## Project Structure
```plaintext
LibraryManagementSystem/
|-- Models/
|   |-- BaseEntity.cs
|   |-- Books/
|       |-- Book.cs
|   |-- AppUsers/
|       |-- AppUser.cs
|
|-- Services/
|   |-- Books/
|       |-- BookService.cs
|   |-- AppUsers/
|       |-- AppUserService.cs
|   |-- ExceptionHandlers/
|       |-- GlobalExceptionHandler.cs
|
|-- Data/
|   |-- Configurations/
|   |-- Repositories/
|   |-- DbInitializer.cs
|-- Controllers/
|-- Views/
|-- Areas/
|-- wwwroot/
|-- appsettings.json
|-- Program.cs
|-- Startup.cs
```

---

## Setup and Installation
Follow the steps below to run the project locally:

1. **Clone the Repository**
   ```bash
   git clone https://github.com/yourusername/library-management-system.git
   cd library-management-system
   ```

2. **Setup SQL Server Database**
   - Update the connection string in `appsettings.json`:
     ```json
     "ConnectionStrings": {
         "DefaultConnection": "Server=YOUR_SERVER;Database=LibraryDb;Trusted_Connection=True;"
     }
     ```

3. **Run Migrations**
   Run the following command to apply database migrations:
   ```bash
   dotnet ef database update
   ```

4. **Run the Application**
   Start the project using the following command:
   ```bash
   dotnet run
   ```

5. **Access the Application**
   Open the application in a web browser at:
   ```
   http://localhost:5000
   ```

---

## How to Use
- **Register & Login**: Users can register and log in via the `/Account/Register` and `/Account/Login` pages.
- **Admin Panel**: Admin can manage books, users, and roles.
- **Librarian Panel**: Librarians can add, edit, and delete books.
- **Member Dashboard**: Members can view books.

---

## Database Initialization
The database can be initialized using the `DbInitializer` class. When the project runs for the first time, seed data for roles and admin users will be created.

To re-initialize the database:
1. Delete the existing database.
2. Re-run the project to trigger `DbInitializer`.

---

## Soft Delete Mechanism
The project uses a **soft delete** mechanism implemented in the `BaseEntity` class:
```csharp
public class BaseEntity {
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; } = false;
}
```
- Entities are not deleted from the database; instead, `IsDeleted` is set to `true`.
- Queries exclude soft-deleted records using LINQ filters.

---

## API Documentation
### User Endpoints
- `GET /api/users` - Retrieve all users
- `POST /api/users` - Add a new user
- `PUT /api/users/{id}` - Update a specific user
- `DELETE /api/users/{id}` - Soft delete a user

### Book Endpoints
- `GET /api/books` - Retrieve all books
- `POST /api/books` - Add a new book
- `PUT /api/books/{id}` - Update a specific book
- `DELETE /api/books/{id}` - Soft delete a book

---

## Error Handling
Global exception handling is implemented to ensure consistent error responses. Exceptions are caught in `GlobalExceptionHandler` and returned as:
```json
{
    "StatusCode": 500,
    "Message": "An unexpected error occurred. Please try again later."
}
```
Custom exceptions like `NotFoundException` are also included for cleaner error responses.

---

## Screenshots

### Dropdown Example
![Dropdown](wwwroot/screenshoots/Dropdown.png)

### Book Detail Page
![Book Detail](wwwroot/screenshoots/book_detail.png)

### Book List Page
![Book List](wwwroot/screenshoots/book_list.png)

### Create Book Page
![Create Book](wwwroot/screenshoots/create_book.png)

### Create User for Admin Page
![Create User for Admin](wwwroot/screenshoots/create_user_for_admin.png)

### Database Screenshot
![Database](wwwroot/screenshoots/database.png)

### Home Page
![Home Page](wwwroot/screenshoots/home_page.png)

### Login Page
![Login Page](wwwroot/screenshoots/log_in.png)

### Manage User Role Page
![Manage User Role](wwwroot/screenshoots/manage_user_role.png)

### Register Page
![Register Page](wwwroot/screenshoots/register.png)

### Role List Page
![Role List](wwwroot/screenshoots/role_list.png)

### Update Book Page
![Update Book](wwwroot/screenshoots/update_book.png)

### Update Role Page
![Update Role](wwwroot/screenshoots/update_role.png)

### User List Page
![User List](wwwroot/screenshoots/user_list.png)

---

## License
This project is licensed under the MIT License.

---

**Happy Coding!** 🚀
