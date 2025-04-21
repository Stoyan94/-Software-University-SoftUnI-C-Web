ENG VERSION:


---

## 🔵 1. **Original Entity – EF Tracking**

```csharp
var employees = context.Employees
    .Where(...) // some filter
    .ToList(); // fetches the actual EF Core-managed entities
```

### What happens here:
- EF Core **pulls the entire entity from the database**
- The objects are **tracked** – EF monitors all changes to them (like `Salary`, `FirstName`, etc.)
- When you call `context.SaveChanges()`, EF knows what to update

### Example:
```csharp
employees[0].Salary *= 1.12M;
context.SaveChanges(); // updates this specific employee in the DB
```

✅ **Advantages:**
- Changes are auto-tracked and saved
- Perfect for `UPDATE` operations

❌ **Drawbacks:**
- Retrieves **all columns** from the table
- Can consume a lot of memory if the table is large

---

## 🟢 2. **`new Employee` in `.Select()` – Detached Entity**

```csharp
.Select(e => new Employee
{
    EmployeeId = e.EmployeeId,
    Salary = e.Salary,
    FirstName = e.FirstName
})
```

### What happens here:
- You're creating a **brand-new object**
- **Not tracked by EF Core** – no change tracking
- Even if it has an `EmployeeId`, EF doesn’t treat it as a DB record

### If you try this:
```csharp
emp.Salary *= 1.12M;
context.SaveChanges(); // ❌ Nothing will be saved
```

⚠️ EF might even treat it as a **new entry** and throw a duplicate key exception

✅ **Advantages:**
- You fetch only the needed data
- No EF tracking – great for "read-only" scenarios

❌ **Drawbacks:**
- Changes **won’t be saved**
- Risky if you *think* you're updating a tracked entity – but you're not

---

## 🟡 3. **DTO Class – Best for Read-Only Scenarios**

```csharp
public class EmployeeSalaryDto
{
    public int EmployeeId { get; set; }
    public decimal Salary { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
```

```csharp
.Select(e => new EmployeeSalaryDto
{
    EmployeeId = e.EmployeeId,
    Salary = e.Salary,
    FirstName = e.FirstName,
    LastName = e.LastName
})
```

### What happens here:
- You’re creating a separate, clean object just for the needed data
- It’s used for display, business logic, or validation
- **No side effects** with EF Core

✅ **Advantages:**
- Clean separation – no extra DB baggage
- Ideal for APIs, ViewModels, and read-only logic

❌ **Drawbacks:**
- If you want to update, you need to **explicitly map** the DTO back to an entity:
```csharp
var employee = context.Employees.First(e => e.EmployeeId == dto.EmployeeId);
employee.Salary = dto.Salary;
context.SaveChanges();
```

---

## 🧠 TL;DR Table

| Approach                          | EF Tracking | Good for UPDATE | Memory Efficient | EF-Aware |
|----------------------------------|-------------|------------------|------------------|----------|
| `ToList()` on `Employee`         | ✅ Yes       | ✅ Yes           | ❌ No            | ✅ Yes   |
| `Select(...) => new Employee`    | ❌ No        | ❌ No            | ✅ Yes           | ❌ No    |
| `Select(...) => DTO`             | ❌ No        | ⚠️ Only with mapping | ✅ Yes      | ✅ Yes   |

---








BG VERISON:

*много подробно** обяснение на разликата между това да използваш:

1. 🔵 **Оригиналното `Employee` entity от EF Core**  
2. 🟢 **Създадено копие чрез `new Employee`**  
3. 🟡 **DTO (Data Transfer Object)**

---

## 🔵 1. **Оригиналното Entity – EF Tracking**

```csharp
var employees = context.Employees
    .Where(...) // някакъв филтър
    .ToList(); // взима директно обектите, които EF Core управлява
```

### Какво става тук:
- EF Core **дърпа цялото entity от базата**
- Обектите са **tracked** – EF следи всички промени по тях (включително `Salary`, `FirstName` и т.н.)
- Когато извикаш `context.SaveChanges()`, EF знае какво да update-не

### Пример:
```csharp
employees[0].Salary *= 1.12M;
context.SaveChanges(); // ще се ъпдейтне точно този служител в базата
```

✅ **Предимства:**
- Промени се записват автоматично
- Перфектно за `UPDATE` операции

❌ **Недостатъци:**
- Взима **всички колони** от таблицата
- Ако таблицата има много колони или записи, може да натовари паметта

---

## 🟢 2. **`new Employee` в `.Select()` – Detached Entity**

```csharp
.Select(e => new Employee
{
    EmployeeId = e.EmployeeId,
    Salary = e.Salary,
    FirstName = e.FirstName
})
```

### Какво става тук:
- Създаваш **чисто нов обект**
- **НЕ е свързан с EF Core** – няма tracking
- Дори да има `EmployeeId`, EF не го възприема като "запис от базата"

### Ако опиташ:
```csharp
emp.Salary *= 1.12M;
context.SaveChanges(); // ❌ Нищо няма да се запише
```

⚠️ Може дори EF да го третира като **нов запис** и да хвърли грешка за дублиран ключ

✅ **Предимства:**
- Взимаш само нужните данни
- Не държиш връзка с контекста – подходящо за "read-only" операции

❌ **Недостатъци:**
- Промените **не се записват**
- Опасно, ако мислиш че работиш с tracked entity – а реално не е

---

## 🟡 3. **DTO клас – Най-добрият подход за четене**

```csharp
public class EmployeeSalaryDto
{
    public int EmployeeId { get; set; }
    public decimal Salary { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
```

```csharp
.Select(e => new EmployeeSalaryDto
{
    EmployeeId = e.EmployeeId,
    Salary = e.Salary,
    FirstName = e.FirstName,
    LastName = e.LastName
})
```

### Какво става тук:
- Създаваш независим обект само за нужната информация
- Използваш го за визуализация, бизнес логика, или валидиране
- **Няма side effects** с EF Core

✅ **Предимства:**
- Чист separation – не носиш с теб излишни неща от базата
- Много добър за API, ViewModel-и, и "read-only" логика

❌ **Недостатъци:**
- Ако искаш да ъпдейтваш, трябва **изрично** да мапнеш DTO обратно към entity:
```csharp
var employee = context.Employees.First(e => e.EmployeeId == dto.EmployeeId);
employee.Salary = dto.Salary;
context.SaveChanges();
```

---

## 🧠 TL;DR Таблица

| Подход                        |EF Tracking     | Подходящ за UPDATE     | Оптимален по памет  | Прозрачен за EF |
|-------------------------------|----------------|------------------------|---------------------|-------------|
| `ToList()` на `Employee`      | ✅ Да          | ✅ Да                 | ❌ Не               | ✅ Да       |
| `Select(...) => new Employee` | ❌ Не          | ❌ Не                 | ✅ Да               | ❌ Не       |
| `Select(...) => DTO`          | ❌ Не          | ⚠️ Само с mapping     | ✅ Да               | ✅ Да       |

---