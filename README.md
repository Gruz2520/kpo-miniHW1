## **Проект "Зоопарк"**
### by Егор Грузинцев 234
### **Описание проекта**
Проект представляет собой консольное приложение, моделирующее работу зоопарка. В зоопарке можно:
- Добавлять животных и вещи.
- Просматривать общее потребление еды всеми животными.
- Просматривать список животных, доступных для контактного зоопарка.
- Проводить инвентаризацию животных и вещей.

Проект реализован с использованием принципов **SOLID**, паттернов проектирования (например, **Factory**), а также внедрения зависимостей (**Dependency Injection**). Для тестирования используется фреймворк **xUnit**.

---

### **Структура проекта**

1. **Основные классы:**
   - `Zoo`: Основной класс, управляющий животными и вещами.
   - `Animal`: Базовый класс для всех животных.
   - `Thing`: Базовый класс для всех вещей.
   - `MenuRenderer`: Класс для отображения меню и обработки действий пользователя.

2. **Фабрики:**
   - `AnimalFactory`: Абстрактная фабрика для создания животных.
   - `ThingFactory`: Абстрактная фабрика для создания вещей.

3. **Интерфейсы:**
   - `IAnimalManager`, `IFoodCalculator`, `IPettingZoo`, `IInventoryPrinter`: Интерфейсы для работы с зоопарком.
   - `IMenuAction`: Интерфейс для действий в меню.

4. **Тесты:**
   - Unit-тесты написаны для проверки основных функций, таких как добавление животных, вещей, проверка здоровья, инвентаризация и т.д.

---

### **Примененные принципы SOLID**

1. **Single Responsibility Principle (SRP):**
   - Каждый класс выполняет только одну задачу:
     - `Zoo` управляет животными и вещами.
     - `ErrorHandler` обрабатывает ошибки.
     - `MenuRenderer` отвечает за отображение меню.
     - Фабрики (`AnimalFactory`, `ThingFactory`) занимаются созданием объектов.

2. **Open/Closed Principle (OCP):**
   - Код открыт для расширения, но закрыт для модификации. Например:
     - Можно добавить новые типы животных или вещей, не изменяя существующий код.
     - Можно добавить новые действия в меню, реализовав интерфейс `IMenuAction`.

3. **Liskov Substitution Principle (LSP):**
   - Подклассы могут заменять базовые классы без изменения поведения программы. Например:
     - Любой класс, наследующий `Animal`, может быть добавлен в зоопарк через метод `AddAnimal`.

4. **Interface Segregation Principle (ISP):**
   - Интерфейсы разделены на небольшие, специализированные части:
     - `IAnimalManager` управляет животными.
     - `IFoodCalculator` рассчитывает потребление еды.
     - `IPettingZoo` предоставляет список дружелюбных животных.

5. **Dependency Inversion Principle (DIP):**
   - Высокоуровневые модули зависят от абстракций, а не от конкретных реализаций. Например:
     - `Zoo` зависит от интерфейса `IVeterinaryClinic`, а не от конкретной реализации клиники.

---

### **Внедрение зависимостей (DI)**

Для управления зависимостями используется **Microsoft.Extensions.DependencyInjection**. Это позволяет:
- Упростить настройку и использование сервисов.
- Обеспечить легкую замену реализаций (например, замена реальной клиники на мок).

#### Пример настройки DI:
```csharp
services.AddSingleton<IVeterinaryClinic>(new VeterinaryClinic());
services.AddSingleton<Zoo>();
services.AddTransient<IMenuAction, AddAnimalAction>();
```
---

### **Паттерн Factory**

#### **Фабрика для животных**
Реализован паттерн **Factory** для создания животных. Это позволяет абстрагировать процесс создания объектов и сделать код более гибким.

Пример:
```csharp
public interface IAnimalFactory
{
    Animal Create(int id, string name, string description);
}

public class MonkeyFactory : IAnimalFactory
{
    public Animal Create(int inventoryNumber, double foodConsumption)
    {
        DataProcessing.ReadInt("Введите уровень доброты (1-10): ", out int kindnessLevel, 1, 10);
        return new Monkey(inventoryNumber, foodConsumption, kindnessLevel);
    }
}
```

#### **Фабрика для вещей**
Аналогично реализована фабрика для создания вещей:
```csharp
public interface IThingFactory
{
    Thing Create(int id, string name, string description);
}

public class TableFactory : IThingFactory
{
    public Thing Create(int id, string name, string description)
    {
        DataProcessing.ReadInt("Введите количество ножек: ", out int legsCount);
        DataProcessing.ReadString("Введите материал стола: ", out string material);

        return new Table(id, name, description, legsCount, material);
    }
}
```

---

### **Общие принятые решения**

1. **Логирование ошибок:**
   - Все ошибки логируются в файл `error_log.txt`.
   - Пользователь получает понятные сообщения об ошибках в консоль.

2. **Обработка исключений:**
   - Создан класс `ErrorHandler` для централизованной обработки ошибок.
   - Разные типы ошибок обрабатываются отдельно (например, `InvalidOperationException`, `FormatException`).

3. **Валидация данных:**
   - Ввод данных проверяется на корректность (например, числа, строки).

4. **Модульность:**
   - Код разделен на независимые модули, что упрощает поддержку и расширение.

---

### **Использование Unit-тестов**

Для тестирования используется фреймворк **xUnit**. Тесты покрывают следующие сценарии:
- Добавление животных и вещей.
- Проверка здоровья животных.
- Инвентаризация.
- Добавление животных в контактный зоопарк.

Пример теста:
```csharp
[Fact]
public void AddMonkey_AddsHealthyAnimalToZoo()
{
    // Arrange
    var mockClinic = new Mock<IVeterinaryClinic>();
    mockClinic.Setup(c => c.IsHealthy(It.IsAny<Animal>())).Returns(true);

    var zoo = new Zoo(mockClinic.Object);
    var monkey = new Monkey(1, 5, 8);

    // Act
    zoo.AddAnimal(monkey);

    // Assert
    Assert.Single(zoo.GetAnimalsForPettingZoo());
}
```

---

### **Как запустить проект**

1. **Установка зависимостей:**
   - Убедитесь, что установлен .NET SDK.
   - Запустите команду для восстановления зависимостей:
     ```bash
     dotnet restore
     ```

2. **Сборка проекта:**
   - Соберите проект:
     ```bash
     dotnet build
     ```

3. **Запуск приложения:**
   - Запустите приложение:
     ```bash
     dotnet run --project kpo_miniHW1
     ```

4. **Запуск тестов:**
   - Запустите unit-тесты:
     ```bash
     dotnet test
     ```

---

### **Заключение**

Проект демонстрирует применение современных подходов к разработке программного обеспечения:
- Использование принципов SOLID для создания гибкого и поддерживаемого кода.
- Реализация паттернов проектирования (Factory, Dependency Injection).
- Написание unit-тестов для проверки корректности работы программы.
