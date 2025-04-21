ENG VERSION:

**Bitwise OR(`|`) * * is an operator that performs a comparison on each individual bit of two numbers. At its core, it compares two bits at the same position and returns `1` if **at least one** of them is `1`. If both bits are `0`, the result is `0`.

---

### Example with Bitwise OR:

Let’s take two numbers in binary:

```
a = 5->  0101 (in binary)
b = 3->  0011(in binary)
```

Using** bitwise OR** (`|`), we get:

```
a | b = 0111(in binary)-> 7(in decimal)
```

Here's how it works:
- 1st bit of `a` (0) and `b` (0) → result is 0  
- 2nd bit of `a` (1) and `b` (0) → result is 1  
- 3rd bit of `a` (0) and `b` (1) → result is 1  
- 4th bit of `a` (1) and `b` (1) → result is 1  

So the final result is `7` in decimal (`0111` in binary).

---

### Bitwise Operators in C#:
- **`&`** – Bitwise AND  
- **`|`** – Bitwise OR  
- **`^`** – Bitwise XOR (exclusive OR)  
- **`~`** – Bitwise NOT (inversion)  
- **`<<`** – Bitwise left shift  
- **`>>`** – Bitwise right shift  

---

### Why NOT to Use Bitwise OR in Logical Conditions:
When working with **boolean values (`true`/`false`)** and checking multiple conditions, you should use the **logical OR** (`||`) instead of the **bitwise OR** (`|`). Logical OR is made to evaluate whether *at least one* of the conditions is `true`, and it **stops early** if the first condition is already `true` (known as **short-circuiting**).

Bitwise OR, on the other hand, **evaluates both sides fully** and performs the operation on each bit, which is inefficient and potentially problematic in logical expressions.

---

### When to Use Bitwise OR:
Bitwise OR is very useful when working with **bit flags** or **bit masks**, for example:

```csharp
int flag = 0b0101;  // 4-bit flag (5 in decimal)
int mask = 0b0011;  // Mask to check the first 2 bits

int result = flag | mask;  // Result: 0111 (7 in decimal)
```

Here, bitwise OR is used to **combine flags** effectively.

---

### In Summary:
- **Bitwise OR (`|`)** works on individual bits of numbers and is ideal for handling flag/mask operations.
- **Logical OR (`||`)** is used for boolean logic and is the correct choice for conditional checks like `if` statements.






BG VERSION :

**Побитово ИЛИ * *(познато като** bitwise OR**) е оператор, който извършва операция върху отделни битове на числата. 
 В основата си, той сравнява два бита от съответните числа и ако поне един от тях е `1`, тогава резултатът е `1`. Ако и двата са `0`, тогава резултатът е `0`.

### Пример с побитово ИЛИ:

Нека имаме две числа в бинарен формат:

```
a = 5->  0101(в двоична форма)
b = 3->  0011(в двоична форма)
```

Ако използваме **побитово ИЛИ** (`|`), ще получим:

```
a | b = 0111(в двоична форма)-> 7(в десетична форма)
```

Това означава, че:
-Първият бит на `a` (0) и първият бит на `b` (0) -> резултатът е 0
- Вторият бит на `a` (1) и вторият бит на `b` (0) -> резултатът е 1
- Третият бит на `a` (0) и третият бит на `b` (1) -> резултатът е 1
- Четвъртият бит на `a` (1) и четвъртият бит на `b` (1) -> резултатът е 1

И така, резултатът е 7 в десетичен формат (0111 в двоичен).

### Побитови оператори в C#:
- **`&`** – Побитово И (bitwise AND)
- **`|`** – Побитово ИЛИ (bitwise OR)
- **`^`** – Побитово изключващо ИЛИ (bitwise XOR)
- **`~`** – Побитово отрицание (bitwise NOT)
- **`<<`** – Побитово изместване наляво (left shift)
- **`>>`** – Побитово изместване надясно (right shift)

### Защо да не използваш побитово ИЛИ в логическите условия?
Когато работиш с **булеви стойности (true/false)** и проверяваш няколко условия, трябва да използваш **логическо ИЛИ** (`||`) вместо **побитово ИЛИ** (`|`).
Логическото ИЛИ е предназначено да проверява дали поне едно от условията е вярно, като спира веднага, ако първото условие е изпълнено (познато като **short-circuiting**).
Побитово ИЛИ, от друга страна, извършва операция върху всеки бит в числата и не спира в процеса.

---

### Кога да използваш побитово ИЛИ:
Побитово ИЛИ е полезно, когато работиш с **битови флагове** или **маски**, като например:

```csharp
int flag = 0b0101;  // Флаг с 4 бита (5 в десетичен)
int mask = 0b0011;   // Маска, която проверява първите 2 бита

int result = flag | mask;  // Резултат: 0111 (7 в десетичен)
```

Тук може да се използва побитово ИЛИ за да комбинираш различни флагове.

---

### В заключение:
- **Побитово ИЛИ (|)** работи с отделни битове на числа и се използва за работа с битови флагове.
- **Логическо ИЛИ (||)** се използва за сравнение на булеви стойности и е правилният избор за условия в код, които проверяват дали някое от дадените условия е вярно.