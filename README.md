# 🐞 BugTracker.System — A Test-Driven Bug Tracking Solution

Welcome to **BugTracker.System**, a modular and test-driven console application designed to simulate real-world bug reporting and status tracking. Built with Agile principles and refactored through multiple sprints, this project highlights version control, CI/CD workflows, meaningful unit testing, and solid class design.

---

## 🧱 Project Overview

**Purpose:**  
Track, categorize, and manage software bugs through lifecycle states like `Open`, `InProgress`, `Pending`, and `Closed`. This project simulates the iterative nature of real-world software development, evolving through scoped assignments and QA practices.

**Scope:**  
Built in sprints, the project includes:

- A robust `Bug` model with business rule enforcement
- A `BugStatus` enum for lifecycle control
- A `BugService` layer to manage bugs
- xUnit test suite with TDD methodology
- New features like `AssignedToDeveloper`, `EstimatedFixTimeHours`, and `PriorityLevel`
- Moq-powered service mocking

---

## 🛠️ Technologies Used

- **.NET 9.0** (C#)
- **xUnit** (Unit testing)
- **Moq** (Service mocking)
- **Visual Studio 2022**
- **GitHub Projects & Actions** (CI)
- **Test Explorer** (for test suite validation)

---

## 🧪 Testing and QA Highlights

Test-driven development was followed throughout. Each logic update was preceded by failing tests, then corrected through targeted refactors. Highlights include:

✅ Valid status transitions  
✅ Rejection of invalid transitions  
✅ Exception handling for same-status updates  
✅ Guard rails for Closed bug behavior  
✅ Unit tests for all new properties: `PriorityLevel`, `EstimatedFixTimeHours`, `AssignedToDeveloper`  
✅ Moq test for verifying service method calls

---

### 🧨 Example: Exception Enforcement in `Bug.cs`

```csharp
if (Status == newStatus)
    throw new InvalidOperationException("Bug is already in the requested status.");

if (Status == BugStatus.Closed)
    throw new InvalidOperationException("Cannot change status once it is Closed.");
