# ✅ Test-Driven Development (TDD) Walkthrough

## 🧪 TDD Workflow Used

This project followed the standard Red-Green-Refactor cycle:

1. **Write a failing test**
2. **Run and verify failure** (Red)
3. **Write the minimal code required to pass** (Green)
4. **Run test again and verify success**
5. **Refactor for clarity or structure, not behavior** (Refactor)

---

## 🔍 Applied Example: Prevent Status Change After Closed

We needed to ensure a bug could not be modified once it reached `Closed`. Using TDD, we built the feature **only because the test required it**.

---

### 🧪 Step 1: Write Failing Test

```csharp
[Fact]
public void UpdateStatus_Throws_When_Bug_Is_Closed()
{
    // Arrange
    var bug = new Bug("Closed test", "Trying to reopen a closed bug");
    bug.UpdateStatus(BugStatus.InProgress);
    bug.UpdateStatus(BugStatus.Closed);

    // Act & Assert
    Assert.Throws<InvalidOperationException>(() =>
        bug.UpdateStatus(BugStatus.Pending));
}
```

---

### 🔴 Step 2: Run Test and Confirm Failure

Initially, this test failed because `Bug.cs` allowed status changes after `Closed`.

---

### ✅ Step 3: Write Production Code to Pass

In `Bug.cs`, we added:

```csharp
if (Status == BugStatus.Closed)
    throw new InvalidOperationException("Cannot change status once it is Closed.");
```

---

### 🟢 Step 4: Re-run Tests

All tests now pass, confirming the new rule works correctly and doesn't break existing logic.

---

### 🛠️ Step 5: Refactor (if needed)

We cleaned up the method to make sure logic flows in priority order and used clear exception messages.

---

## 💡 Why This Matters

TDD ensures features evolve only when tests demand them. This minimizes bugs, forces focus on edge cases, and leads to cleaner, more maintainable code over time.

---

## 📎 Related Tests

- `UpdateStatus_DoesNotAllowTransitionFromClosedToPending()`
- `UpdateStatus_DoesNotChangeToSameStatus()`
