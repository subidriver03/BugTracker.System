# 🧱 Architecture Overview – BugTracker.System

## 🔍 Purpose

This document provides a high-level overview of the BugTracker.System architecture. The solution is built using a clean, layered approach to support separation of concerns, modular development, and test-driven best practices.

---

## 📐 Layered Structure

```
BugTracker.System/
├── BugTracker.Core/       → Domain logic and data models
├── BugTracker.ConsoleUI/  → Console interface for basic interaction
├── BugTracker.Tests/      → Unit and Moq-based test coverage
```

---

## 📦 Project Breakdown

### 🧩 BugTracker.Core

Houses all domain classes, enums, and services that define bug behavior and workflow logic.

**Key Files:**
- `Bug.cs`: The core class. Manages properties like `Title`, `Status`, `Priority`, `EstimatedFixTimeHours`, and enforces lifecycle rules.
- `BugStatus.cs`: Enum defining valid states — Open, InProgress, Pending, Closed.
- `PriorityLevel.cs`: Enum used to classify bugs by severity.
- `IBugService.cs`: Interface to support service abstraction and mocking.
- `BugService.cs`: Business logic for adding and updating bugs in memory.

---

### 🖥️ BugTracker.ConsoleUI

A basic CLI (Command-Line Interface) used for manual input/testing during early development.

**Key File:**
- `Program.cs`: Provides simple menus to add, view, and update bugs using the service layer.

---

### 🧪 BugTracker.Tests

Contains all automated tests using xUnit and Moq.

**Key Files:**
- `BugTests.cs`: Unit tests for `Bug` class. Covers constructor validation, status transitions, exception handling.
- `BugServiceTests.cs`: Moq-powered tests validating service interactions via the `IBugService` interface.

---

## 🧭 Architecture Benefits

- **Separation of Concerns**: Each project handles a specific responsibility.
- **Testability**: Business logic is separated from UI and fully testable using TDD.
- **Scalability**: Can later expand to a web API or GUI by reusing the core service logic.

---

## 📎 Future Expansion Ideas

- Add persistence (e.g., save bugs to JSON or database)
- Implement bug filtering (by status, priority, or assigned developer)
- Build a RESTful API layer for web-based interaction
- Integrate with frontend (Blazor, Angular, or React)

---

## 📘 Related Docs

- [TDD Walkthrough](./tdd-walkthrough.md)
- [Bug Lifecycle Diagram](./bug-lifecycle-diagram.md)
- [Moq Test Guide](./moq-example.md)
