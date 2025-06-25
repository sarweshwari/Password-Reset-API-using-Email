🔐 Password Reset API using Email
This project is a simple ASP.NET Core Web API that allows users to reset their passwords by receiving a reset token via email.

📌 Features
Request password reset via email
Securely generate and send a reset token
Validate token and set a new password
Uses .NET 8.0
Email functionality built-in (SMTP-based)

🛠️ Technologies Used
ASP.NET Core 8
Entity Framework Core
SMTP for email service
MSSQL (or any compatible DB)
RESTful API

📩 Password Reset Workflow
User forgets password
User requests reset – submits their email
API sends a reset email with a unique token (reset code)
User receives the email, clicks the link or enters token
User submits new password along with the token
API validates the token and updates the password

Password-Reset-API-using-Email/
│
├── Controllers/             # API endpoints
├── DTOs/                    # Data Transfer Objects
├── Data/                    # Database context
├── Migrations/              # EF Core migrations
├── Models/                  # Entity models
├── Repository/              # DB access logic
├── Services/                # Business logic
├── Properties/              # LaunchSettings
├── Program.cs               # App entry point
├── appsettings.json         # Config settings
└── README.md                # This file

