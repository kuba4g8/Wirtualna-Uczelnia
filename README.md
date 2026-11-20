# Wirtualna Uczelnia (Virtual University Desktop System)

A desktop academic management platform developed in **C# (.NET Windows Forms)** backed by a **MySQL** relational database. Built collaboratively by a 6-person student engineering team, the application provides role-based interfaces for **Students**, **Teachers**, and **Administrators**.

---

## Key Features

### Role-Based Access & Security
* **Authentication & Session Management:** Secure user login, password hashing (`Hasher.cs`), session tracking (`SesionControl.cs`, `TempLoggedUser.cs`), security management (`SecMenager.cs`), and password reset functionality (`formResetPassword`).
* **Role Separation:** Dedicated views and permissions for Students (`StronaGlowna`), Academic Staff (`TeacherPanel`), and System Administrators (`AdminPanel`).

### Student & Academic Modules
* **Grades & Assessments:** Viewing and managing academic grades (`Oceny`, `OcenyPanel`, `OcenyPanelEditSelector`).
* **Class Schedule & Calendar:** Interactive timetable viewer (`FormPlanLekcji`, `PlanLekcjiUserControl`) and academic calendar with custom event handling (`FormKalendarz`, `CalendarEvent`).
* **Course Registration & Documents:** Student course enrollment (`Rejestracja`) and academic document management (`Dokumenty`).
* **Communication:** Built-in real-time/internal messaging (`ChatForm`) and staff contact directory (`FormKontaktPracownicy`, `ContactUserControl`).

### Teacher & Administrator Panels
* **Teacher Tools:** Dedicated educator dashboard (`TeacherPanel`) with calendar and event editing capabilities (`TeacherCalendarEditor`).
* **Admin Tools:** System-wide user registration (`RegisterUser`) and schedule modification tools (`FormChangePlan`, `FormEdytujPlanLekcji`).

### Localization & UI
* **Multi-Language Support:** Built-in internationalization engine (`LangMenager.cs`) with JSON language packs (`englishLang.json`).
* **Custom Desktop UI:** Custom graphical assets, buttons, and layout styling (`.sprites/`, `Resources.resx`).

---

## Tech Stack
* **Language & Framework:** C# / .NET (Windows Forms)
* **Database:** MySQL (deployed locally via XAMPP / phpMyAdmin)
* **Data & Configuration:** JSON serialization (`jsonMenager.cs`, `config.json`, `englishLang.json`)
* **Deployment & Packaging:** Visual Studio Solution with ClickOnce publish profiles
* **Version Control:** Git & GitHub

---

## Project Structure
```text
Wirtualna-Uczelnia/
├── BazaDanych/
│   └── wirtualna_uczelnia Kopia zapasowa.sql   # MySQL database schema and initial data
└── Wirtualna-Uczelnia-Rozwiazanie/
    ├── Wirtualna-Uczelnia.sln                  # Visual Studio solution
    ├── Wirtualna-Uczelnia.csproj               # Project configuration
    ├── Program.cs                              # Application entry point
    ├── config/
    │   └── config.json                         # Database connection & app configuration
    ├── .formy/                                 # Windows Forms UI & UserControls
    │   ├── AdminForms/                         # Admin panel, user registration, schedule editors
    │   ├── StronaGlowna/                       # Main dashboard sub-views (grades, schedule, docs)
    │   └── UserControls/                       # Reusable UI components
    ├── .klasy/                                 # Business logic, security, session & DB managers
    │   ├── sqlMenager.cs                       # MySQL database communication layer
    │   ├── LoginMenager.cs                     # Authentication logic
    │   ├── Hasher.cs & SecMenager.cs           # Password hashing & security utilities
    │   ├── SesionControl.cs                    # Active user session management
    │   └── CalendarEvent.cs                    # Calendar data models
    ├── .translations/                          # Localization manager & JSON dictionaries
    ├── .sprites/ & Resources/                  # Custom UI icons, buttons, and graphic assets
    └── Properties/                             # Application resources & ClickOnce profiles
```

---

## Team & Git Workflow
The project was engineered by a **6-person development team** split into **Front-End / UI** (3 developers) and **Back-End / Database** (3 developers) sub-teams:
* **Branching Strategy:** Development was isolated on `Front-End` and `Back-End` branches, keeping `main` protected from direct pushes.
* **Code Review:** Merging into `main` required a **Pull Request** approved by at least **2 team members**.

---

## Local Setup & Installation

### 1. Database Configuration
1. Launch **XAMPP** (or any standalone MySQL instance) and start the **Apache** and **MySQL** modules.
2. Open **phpMyAdmin** (`http://localhost/phpmyadmin`).
3. Create a new database named `wirtualna_uczelnia`.
4. Import the schema from `BazaDanych/wirtualna_uczelnia Kopia zapasowa.sql`.

### 2. Running the Application
1. Clone the repository:
   ```bash
   git clone https://github.com/kuba4g8/Wirtualna-Uczelnia.git
   ```
2. Open `Wirtualna-Uczelnia-Rozwiazanie/Wirtualna-Uczelnia.sln` in **Visual Studio**.
3. Check `Wirtualna-Uczelnia-Rozwiazanie/config/config.json` to ensure database credentials match your local MySQL setup.
4. Build and run the project (`F5`).
