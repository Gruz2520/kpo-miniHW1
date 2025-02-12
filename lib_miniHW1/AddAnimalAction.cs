using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    public class AddAnimalAction : IMenuAction
    {
        private readonly IAnimalManager _animalManager;

        public AddAnimalAction(IAnimalManager animalManager)
        {
            _animalManager = animalManager;
        }

        public string Name => "Добавить животное";

        public void Execute()
        {
            string[] animals = { "Обезьяна (Monkey)", "Кролик (Rabbit)", "Тигр (Tiger)", "Волк (Wolf)" };
            var rand = new Random();
            Console.Clear();
            Console.WriteLine("Выберите тип животного:");
            for (int i = 0; i < animals.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {animals[i]}");
            }
            Console.WriteLine($"{animals.Length + 1}. Выбрать случайно");
            Console.WriteLine($"{Environment.NewLine}Нажмите Escape для возврата на главное меню");

            int typeOfAnimal = -1;
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1 or ConsoleKey.NumPad1:
                    typeOfAnimal = 0;
                    break;
                case ConsoleKey.D2 or ConsoleKey.NumPad2:
                    typeOfAnimal = 1;
                    break;
                case ConsoleKey.D3 or ConsoleKey.NumPad3:
                    typeOfAnimal = 2;
                    break;
                case ConsoleKey.D4 or ConsoleKey.NumPad4:
                    typeOfAnimal = 3;
                    break;
                case ConsoleKey.D5 or ConsoleKey.NumPad5:
                    typeOfAnimal = rand.Next(animals.Length);
                    break;
                case ConsoleKey.Escape:
                    return;
                default:
                    Execute();
                    return;
            }

            string animalType = animals[typeOfAnimal].Split('(')[1].TrimEnd(')');
            IAnimalFactory factory = AnimalFactoryProvider.GetFactory(animalType);
            Console.Clear();
            Console.WriteLine($"Добавляемое животное: {animals[typeOfAnimal]}");
            DataProcessing.ReadInt("Введите инвентарный номер: ", out int inventoryNumber);
            DataProcessing.ReadInt("Введите количество еды в кг в сутки: ", out int foodConsumption);
            Animal animal = factory.Create(inventoryNumber, foodConsumption);
            _animalManager.AddAnimal(animal);
            Thread.Sleep(3000);
        }
    }
}
