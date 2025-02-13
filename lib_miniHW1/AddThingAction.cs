using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    /// <summary>
    /// Класс, реализующий действие "Добавить вещь" в меню.
    /// Реализует интерфейс IMenuAction.
    /// </summary>
    public class AddThingAction : IMenuAction
    {
        private readonly Zoo _zoo;

        /// <summary>
        /// Конструктор класса AddThingAction.
        /// Инициализирует экземпляр с помощью объекта Zoo.
        /// </summary>
        /// <param name="zoo">Экземпляр зоопарка для управления добавлением вещей.</param>
        public AddThingAction(Zoo zoo)
        {
            _zoo = zoo;
        }

        public string Name => "Добавить вещь";

        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Выберите тип вещи:");
            Console.WriteLine("1. Стол");
            Console.WriteLine("2. Компьютер");

            string thingType = null;

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1 or ConsoleKey.NumPad1:
                    thingType = "table";
                    break;
                case ConsoleKey.D2 or ConsoleKey.NumPad2:
                    thingType = "computer";
                    break;
                default:
                    Execute();
                    return;
            }

            DataProcessing.ReadInt("Введите ID вещи: ", out int id);
            DataProcessing.ReadString("Введите название вещи: ", out string name);
            DataProcessing.ReadString("Введите описание вещи: ", out string description, allowEmpty: true);

            // Получение фабрики для создания вещи
            IThingFactory factory = ThingFactoryProvider.GetFactory(thingType);

            // Создание вещи через фабрику
            Thing thing = factory.Create(id, name, description);

            _zoo.AddThing(thing);
            Console.WriteLine($"{thing.Name} успешно добавлен.");
            Thread.Sleep(2000);
        }
    }
}