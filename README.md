# 📡 Web Application: Global Communications

**This project is a role-based telecommunications management system developed using the MVC (Model-View-Controller) architecture. It supports multiple user roles including Clients, Administrators, and Sellers.**

> ℹ️ This project is not open source and does not grant any usage rights.
> For usage terms and legal information, see [Code Ownership & Usage Terms](#-code-ownership--usage-terms).

## 📖 Overview

Global Communications is a web-based platform designed to simulate the operations of a telecommunications provider. It allows users to manage mobile programs, client accounts, call histories, and payments through a structured and secure interface. The system is modular, scalable, and built with maintainability in mind.

## 🌐 Features

### 🔐 Authentication
- Secure login system for Clients, Administrators, and Sellers
- Role-based access control with dynamic navigation

### 👤 Client Functionality
- View account details and billing history
- Access call history with timestamps and durations
- Make online payments via card
- View and manage subscribed mobile programs

### ⚙️ Administrator Functionality
- Manage mobile programs (create, edit, delete)
- Oversee sales and seller accounts
- Create and manage user accounts

### 💼 Seller Functionality
- Register new clients
- Schedule and manage sales activities
- Assign mobile programs to clients

## 🛠️ Technologies Used

- ASP.NET MVC Framework
- C# for the Businnes Logic
- HTML5
- SQL Server for data persistence
- Bootstrap for responsive UI

## 🎯 Purpose

The purpose of this application is to provide a complete and functional web solution for managing telecommunications services. It enables administrators to oversee mobile programs and user accounts, sellers to onboard clients and assign plans, and clients to view their billing history, call records, and make payments. The project demonstrates a practical implementation of role-based access control, data-driven interfaces, and secure transaction handling within a modern MVC framework. **It is developed solely for academic and research purposes.**

## 🧰 Prerequisites

To run this project locally, you will need:

- **Windows 10 version 1809 or later** (Windows 11 recommended)
- **Visual Studio 2022** (version 17.1 or newer)
- **SQL Server Express** and optionally **SQL Server Management Studio (SSMS)**
- **Access to a database schema compatible with the application** (the database schema is provided)
- **.NET SDK** (version 8)
- **Developer Mode** enabled in Windows

## 📦 Installation

To set up the project locally:

1. **Clone the repository**
   ```bash
   git clone https://github.com/kpavlis/telco-web-app.git
   cd telco-web-app
2. **Open the project in Visual Studio 2022** using the `.sln` file
3. **Confirm that the following NuGet packages are installed:**
    - Microsoft.EntityFrameworkCore.SqlServer (version **9.0.9**)
    - Microsoft.EntityFrameworkCore.Tools (version **9.0.9**)
    - Microsoft.VisualStudio.Web.CodeGeneration.Design (version **9.0.0**)
    - X.PagedList.Mvc.Core (version **10.5.x**)
4. **Verify Target Framework**
     In your `.csproj` file, ensure the framework is set correctly:
   
     ```xml
     <TargetFramework>net8.0</TargetFramework>

5. **Install** SQL Server Express and optionally SQL Server Management Studio (SSMS)
   - Update the connection string in `appsettings.json` and `LabDBContext.cs (Models folder)` to match your local SQL Server instance
   - Run the provided SQL script `database_schema.sql` to initialize the schema and seed data

6. **Run** the web application from  Visual Studio

## 📷 Screenshots / Video

**_App Screens:_**  
> <img width="250" height="160" alt="Telco_Web_1" src="https://github.com/user-attachments/assets/1fb6045e-c3cf-4463-961f-3176fa65a1a0" />
> <img width="250" height="160" alt="Telco_Web_2" src="https://github.com/user-attachments/assets/3eaf3324-9b27-439e-b215-3f6e0755db76" />
> <img width="250" height="160" alt="Telco_Web_3" src="https://github.com/user-attachments/assets/7c2703de-514f-4880-8f60-cf3890268ee8" />
> <img width="250" height="160" alt="Telco_Web_4" src="https://github.com/user-attachments/assets/07fe1245-e36f-44e1-bffb-b9af9071db2c" />
> <img width="250" height="160" alt="Telco_Web_5" src="https://github.com/user-attachments/assets/e2fca18b-336d-4bc9-8511-8198e8269b13" />
> <img width="250" height="160" alt="Telco_Web_6" src="https://github.com/user-attachments/assets/b7515985-eff7-482b-90ec-59b6e184d091" />

**_Demo Video:_**

> (Coming soon...)

# 🔒 Code Ownership & Usage Terms

This project was created and maintained by:

- Konstantinos Pavlis (@kpavlis)
- Theofanis Tzoumakas (@theofanistzoumakas)
- Michael-Panagiotis Kapetanios (@KapetaniosMP)

🚫 **Unauthorized use is strictly prohibited.**  
No part of this codebase may be copied, reproduced, modified, distributed, or used in any form without **explicit written permission** from the owners.

Any attempt to use, republish, or incorporate this code into other projects—whether commercial or non-commercial—without prior consent may result in legal action.

For licensing inquiries or collaboration requests, please contact via email: konstantinos1125 _at_ gmail.com .

© 2025 Konstantinos Pavlis, Theofanis Tzoumakas, Michael-Panagiotis Kapetanios. All rights reserved.
