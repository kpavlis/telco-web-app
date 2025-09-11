# 📡 Web Application: Telekom Communications

**This project is a role-based telecommunications management system developed using the MVC (Model-View-Controller) architecture. It supports multiple user roles including Clients, Administrators, and Sellers.**

> ℹ️ This project is not open source and does not grant any usage rights.
> For usage terms and legal information, see [Code Ownership & Usage Terms](#-code-ownership--usage-terms).

## 📖 Overview

Telekom Communications is a web-based platform designed to simulate the operations of a telecommunications provider. It allows users to manage mobile programs, client accounts, call histories, and payments through a structured and secure interface. The system is modular, scalable, and built with maintainability in mind.

## 🌐 Features

### 🔐 Authentication
- Secure login system for Clients, Administrators, and Sellers
- Role-based access control with dynamic navigation

### 👤 Client Functionality
- View account details and billing history
- Access call history with timestamps and durations
- Make online payments via card
- View and manage subscribed mobile programs

### 🛠️ Administrator Functionality
- Manage mobile programs (create, edit, delete)
- Oversee sales and seller accounts
- Create and manage user accounts

### 💼 Seller Functionality
- Register new clients
- Schedule and manage sales activities
- Assign mobile programs to clients

## 🧰 Technologies Used

- ASP.NET MVC Framework
- C#
- HTML5, CSS3, JavaScript
- SQL Server (for data persistence)
- Bootstrap (for responsive UI)

## 🎯 Purpose

The purpose of this application is to provide a complete and functional web solution for managing telecommunications services. It enables administrators to oversee mobile programs and user accounts, sellers to onboard clients and assign plans, and clients to view their billing history, call records, and make payments. The project demonstrates a practical implementation of role-based access control, data-driven interfaces, and secure transaction handling within a modern MVC framework. **It is developed solely for academic and research purposes.**

## 🧰 Prerequisites

To run this project locally, you will need:

- Visual Studio 2019 or later with ASP.NET MVC support
- .NET Framework 4.7.2 or newer
- SQL Server Express or SQL Server Management Studio (SSMS)
- A configured local IIS Express environment
- Access to a database schema compatible with the application (SQL scripts provided if applicable)

## 📦 Installation

To set up the project locally:

1. **Clone the repository**
   ```bash
   git clone https://github.com/kpavlis/telco-web-app.git

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
