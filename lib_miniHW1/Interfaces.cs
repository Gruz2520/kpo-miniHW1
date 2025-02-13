using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    /// <summary>
    /// Интерфейс для действий в меню.
    /// Определяет методы для отображения названия действия и его выполнения.
    /// </summary>
    public interface IMenuAction
    {
        /// <summary>
        /// Название действия, которое будет отображаться в меню.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Выполнение действия меню.
        /// </summary>
        void Execute();
    }

    /// <summary>
    /// Интерфейс для фабрики вещей.
    /// Предоставляет метод для создания экземпляров вещей.
    /// </summary>
    public interface IThingFactory
    {
        /// <summary>
        /// Создает новую вещь.
        /// </summary>
        /// <param name="id">Идентификатор вещи.</param>
        /// <param name="name">Название вещи.</param>
        /// <param name="description">Описание вещи.</param>
        /// <returns>Экземпляр класса Thing.</returns>
        Thing Create(int id, string name, string description);
    }

    /// <summary>
    /// Интерфейс для управления животными.
    /// Предоставляет метод для добавления животных.
    /// </summary>
    public interface IAnimalManager
    {
        /// <summary>
        /// Добавляет животное в зоопарк.
        /// </summary>
        /// <param name="animal">Животное, которое нужно добавить.</param>
        void AddAnimal(Animal animal);
    }

    /// <summary>
    /// Интерфейс для расчета общего потребления еды.
    /// Предоставляет метод для получения суммарного количества потребляемой еды.
    /// </summary>
    public interface IFoodCalculator
    {
        /// <summary>
        /// Возвращает общее количество потребляемой еды всеми животными.
        /// </summary>
        /// <returns>Общее количество потребляемой еды (кг/сутки).</returns>
        double GetTotalFoodConsumption();
    }

    /// <summary>
    /// Интерфейс для работы с контактным зоопарком.
    /// Предоставляет метод для получения списка животных, доступных для взаимодействия с посетителями.
    /// </summary>
    public interface IPettingZoo
    {
        /// <summary>
        /// Возвращает список животных, которые могут взаимодействовать с посетителями.
        /// </summary>
        /// <returns>Коллекция дружелюбных животных.</returns>
        IEnumerable<Animal> GetAnimalsForPettingZoo();
    }

    /// <summary>
    /// Интерфейс для печати инвентаризации.
    /// Предоставляет метод для вывода информации о животных и вещах.
    /// </summary>
    public interface IInventoryPrinter
    {
        /// <summary>
        /// Выводит информацию о текущей инвентаризации зоопарка.
        /// </summary>
        void PrintInventory();
    }

    /// <summary>
    /// Интерфейс для живых существ.
    /// Определяет свойство для потребления еды.
    /// </summary>
    public interface IAlive
    {
        /// <summary>
        /// Количество потребляемой еды (кг/сутки).
        /// </summary>
        double FoodConsumption { get; set; }
    }

    /// <summary>
    /// Интерфейс для объектов с инвентарным номером.
    /// Определяет свойство для уникального идентификатора.
    /// </summary>
    public interface IInventory
    {
        /// <summary>
        /// Инвентарный номер объекта.
        /// </summary>
        int InventoryNumber { get; set; }
    }

    /// <summary>
    /// Интерфейс для фабрики создания животных.
    /// Предоставляет метод для создания экземпляров животных.
    /// </summary>
    public interface IAnimalFactory
    {
        /// <summary>
        /// Создает новое животное с указанными параметрами.
        /// </summary>
        /// <param name="inventoryNumber">Инвентарный номер животного.</param>
        /// <param name="foodConsumption">Количество потребляемой еды (кг/сутки).</param>
        /// <returns>Экземпляр класса Animal.</returns>
        Animal Create(int inventoryNumber, double foodConsumption);
    }
}