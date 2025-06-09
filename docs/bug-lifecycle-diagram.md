# 🔁 Bug Lifecycle Diagram

A bug in this system transitions through a strict, rule-driven state machine. This ensures lifecycle integrity and prevents improper updates or regressions.

---

## ✅ Valid Transitions

```
[Open] 
   ↓
[InProgress]
   ↓       ↘
[Pending]  [Closed]
   ↓
[Closed]
```

- `Open` → `InProgress`
- `InProgress` → `Pending` or `Closed`
- `Pending` → `InProgress` or `Closed`

---

## ⛔ Invalid Transitions

- `Closed` → any other state (no reopening)
- `Pending` → `Open`
- Reassigning the same status (e.g., `Open` → `Open`)

These rules are enforced using `InvalidOperationException` inside the `UpdateStatus()` method.

---

## 💡 Notes

- Once a bug is marked **Closed**, it becomes immutable.
- The system follows a linear-but-flexible flow from `Open` to resolution.
- `Pending` acts as a temporary state (e.g., blocked, waiting for response).
