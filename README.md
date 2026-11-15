# RozetkaTests

## Інструкція запуску

**1. Клонуйте проєкт.**

**2. Запустіть тести**

* **Через термінал:**
  ```bash
  dotnet test
  ```

* **Через IDE:**
  Відкрийте файл з рішенням (`RozetkaTests.slnx`), дочекайтесь встановлення заложеностей та запустіть тести через *Test Explorer*.

## Приклад ручного тестування

**Priority:** `very high`

**Assigned to:** `Artem Kushniruk`

**Estimate:** `5m`

**Automation Type:** `Manual`

**Preconditions:**  
* Active user account exists.

**Test Data:**  
* Email: qa.user@example.com, Password: qwerty12345

**Steps to Reproduce** 
1. Open the login page.
2. Enter a valid email address (`qa.user@example.com`).
3. Enter the correct password (`qwerty12345`).
4. Click the **Sign In** button.

**Expected Result**
* User is successfully authenticated and redirected to the dashboard.
