# 🧪 Moq Service Test Example

This guide demonstrates how Moq was used in `BugServiceTests.cs` to verify service behavior using a mocked implementation of `IBugService`.

---

## 🔧 Example Test

```csharp
[Fact]
public void AddBug_Should_Call_Create_Method()
{
    // Arrange
    var mockService = new Mock<IBugService>();
    var bug = new Bug("Test Bug", "Sample description");

    // Act
    mockService.Object.AddBug(bug);

    // Assert
    mockService.Verify(service =>
        service.AddBug(It.Is<Bug>(b => b.Title == "Test Bug")),
        Times.Once);
}
```

---

## 🧠 What This Verifies

- That the `AddBug()` method was called on the mock object.
- That it was called with a `Bug` object that has the correct `Title`.
- That it was called exactly once.

---

## 🛠 Why Use Moq?

- **Isolation**: You can test logic without executing real methods.
- **Verification**: You can ensure that methods are called as expected.
- **Control**: Easily simulate different behaviors (e.g., return values, exceptions).

---

## 🧪 Potential Extensions

- Mock return values using `.Returns(...)`
- Simulate exceptions using `.Throws(...)`
- Use `Setup()` to define expected behavior of a service method

---

## 📘 Related Docs

- [TDD Walkthrough](./tdd-walkthrough.md)
- [Architecture Overview](./architecture.md)
