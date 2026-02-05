🎓 Student Management REST API – ASP.NET Core

A professional ASP.NET Core Web API project demonstrating clean architecture, Entity Framework Core integration, DTO-based data transfer, and structured logging with Serilog.
This project is built as a practice + reference implementation for real-world backend development.

📌 Project Overview

The Student Management API provides a complete RESTful backend for managing student records.
It follows industry best practices such as:

Layered architecture (Controller → Service → Data)

DTO pattern to avoid entity exposure

Entity Framework Core with SQL Server

Structured logging using Serilog

Dependency Injection

Asynchronous programming

🛠️ Tech Stack
Technology	Purpose
ASP.NET Core Web API	Backend framework
Entity Framework Core	ORM & database access
SQL Server	Relational database
Serilog	Structured logging
Swagger / OpenAPI	API documentation
Dependency Injection	Loose coupling
LINQ	Data querying
🧱 Project Architecture
Dotnet_API_05
│
├── Controllers
│   └── StudentController.cs
│
├── Services
│   ├── IStudentService.cs
│   └── StudentService.cs
│
├── Data
│   └── StudentDbContext.cs
│
├── Entities
│   ├── Models
│   │   └── Student.cs
│   └── Dtos
│       ├── CreateStudentDto.cs
│       ├── UpdateStudentDto.cs
│       ├── GetAllStudentDto.cs
│       └── GetStudentByIdDto.cs
│
├── Logs
│   └── app-.log
│
├── appsettings.json
├── Program.cs
└── Dotnet_API_05.http

🚀 Features

✅ Create Student

✅ Get All Students

✅ Get Student By ID

✅ Update Student

✅ Delete Student

✅ Structured logging (Console + File)

✅ Clean DTO mapping

✅ Async database operations

🔄 API Endpoints
Method	Endpoint	Description
GET	/api/students	Get all students
GET	/api/students/{id}	Get student by ID
POST	/api/students	Create new student
PUT	/api/students/{id}	Update student
DELETE	/api/students/{id}	Delete student
📄 Logging (Serilog)

The project uses Serilog for structured logging.

Logs are written to:

🖥 Console

📁 File: Logs/app-<date>.log

Logged events include:

API requests

Database queries

Create / Update / Delete operations

Error and validation scenarios

Example:

_logger.LogInformation("Student created with Id {StudentId}", studentId);

⚙️ Configuration
Database Connection (appsettings.json)
"ConnectionStrings": {
  "DefaultConnection": "server=YOUR_SERVER;database=StudentDb;Trusted_Connection=True;"
}

Logging Level
"Logging": {
  "LogLevel": {
    "Default": "Information",
    "Microsoft": "Warning"
  }
}

🧪 How to Run the Project

Clone the repository

git clone https://github.com/your-username/DotNet_API_05.git


Restore packages

dotnet restore


Apply migrations

Add-Migration InitialCreate
Update-Database


Run the application

dotnet run


Open Swagger UI

https://localhost:<port>/swagger

🧠 Key Learnings from This Project

Clean separation of concerns

Real-world service layer usage

Proper logging strategy

EF Core best practices

DTO-driven API design

Debugging build & migration issues

📈 Future Enhancements

Authentication & Authorization (JWT)

Global exception middleware

Pagination & filtering

Fluent Validation

Unit & integration tests

Repository + Unit of Work pattern

👨‍💻 Author

Tapan Ray
Software Engineer | .NET Backend Developer

This project is built for learning, interviews, and real-world backend reference.
