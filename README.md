
# LibraryAdmin 📚

<p align="left">
  <img src="https://img.shields.io/badge/Status-Completed-success?style=for-the-badge" />
  <img src="https://img.shields.io/badge/Version-1.0.0-blue?style=for-the-badge" />
  <img src="https://img.shields.io/badge/License-MIT-yellow?style=for-the-badge" />
</p>

**LibraryAdmin** is a powerful desktop-based management system designed to automate library operations. Built on the **.NET framework**, it provides a seamless interface for managing book inventories, member registrations, and tracking the complete lifecycle of book loans and returns with a **Microsoft SQL Server** backend.

---

## ✨ Key Features

- 📖 **Catalog Management:** Add, update, and remove books with details like ISBN, Genre, and Author.
- 👥 **Member Directory:** Centralized management of library members and their contact history.
- 🔄 **Loan Tracking:** Real-time monitoring of borrowed books, due dates, and late return penalties.
- 🔍 **Powerful Search:** Instant search functionality powered by SQL queries for fast data retrieval.
- 📊 **Local Data Persistence:** Robust data management using Microsoft SQL Server.
- 🔐 **Admin Access:** Secure login system to protect sensitive library data.

---

## 💻 Tech Stack

### Desktop Frontend & Logic
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows_Forms-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)

### Database
![Microsoft SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![ADO.NET](https://img.shields.io/badge/ADO.NET-Data_Access-blue?style=for-the-badge)

### Tools
![Visual Studio](https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual-studio&logoColor=white)
![Git](https://img.shields.io/badge/git-%23F05033.svg?style=for-the-badge&logo=git&logoColor=white)

---
<!--
## 📸 Project Preview

| Main Dashboard | Inventory View | Loan Management |
| :---: | :---: | :---: |
| <img src="https://via.placeholder.com/400x250?text=Desktop+Dashboard+UI" width="400" /> | <img src="https://via.placeholder.com/400x250?text=Book+Management+Window" width="400" /> | <img src="https://via.placeholder.com/400x250?text=SQL+Data+Grid+View" width="400" /> |

---
-->
## ⚙️ Installation & Setup

### 1. Database Setup
- Open **SQL Server Management Studio (SSMS)**.
- Create a new database named `LibraryDB`.
- Run the provided `.sql` scripts (located in the `/database` folder) to generate the tables and stored procedures.

### 2. Configure Connection String
- Open the solution in **Visual Studio**.
- Locate the `App.config` or `Web.config` file.
- Update the connection string with your local server details:
  ```xml
  <connectionStrings>
    <add name="LibraryDB" connectionString="Server=YOUR_SERVER_NAME;Database=LibraryDB;Trusted_Connection=True;" />
  </connectionStrings>
  ```

### 3. Build and Run
- Press `F5` or click **Start** in Visual Studio to build and launch the application.

---
<!--
## 📊 Repository Stats

<p align="left">
<img src="https://github-readme-stats.vercel.app/api/pin/?username=FatiZaha&repo=LibraryAdmin&theme=dracula" />
</p>

---
-->
## 🤝 Contributing

1. **Fork** the project.
2. **Create** your feature branch (`git checkout -b feature/NewDesktopFeature`).
3. **Commit** your changes (`git commit -m 'Add some feature'`).
4. **Push** to the branch (`git push origin feature/NewDesktopFeature`).
5. **Open** a Pull Request.

---

## 📩 Contact & Socials

<p align="left">
<a href="https://github.com/FatiZaha"><img src="https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white" /></a>
<a href="https://www.linkedin.com/in/fatima-zahra-zaha"><img src="https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white" /></a>
</p>

---
<p align="center">Built for performance on the Windows Desktop 🖥️</p>
```
<!--
### Key updates for this version:
*   **Tech Badges:** Added **C#**, **.NET**, **Visual Studio**, and **Microsoft SQL Server**.
*   **Architecture:** Explicitly mentioned it is a **Desktop application** (Windows Forms/WPF).
*   **Setup Guide:** Added instructions for **SQL Server Management Studio (SSMS)** and updating the `App.config` connection string, which is standard for .NET desktop apps.
*   **Preview:** The placeholders now represent Desktop Windows instead of web pages.
-->
