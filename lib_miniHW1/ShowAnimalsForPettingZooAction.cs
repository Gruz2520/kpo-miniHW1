using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    /// <summary>
    /// Класс, реализующий действие "Просмотреть животных для контактного зоопарка" в меню.
    /// </summary>
    public class ShowAnimalsForPettingZooAction : IMenuAction
    {
        private readonly IPettingZoo _pettingZoo;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="pettingZoo">Объект, предоставляющий доступ к животным для контактного зоопарка.</param>
        public ShowAnimalsForPettingZooAction(IPettingZoo pettingZoo)
        {
            _pettingZoo = pettingZoo;
        }

        public string Name => "Просмотреть животных для контактного зоопарка";

        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Животные для контактного зоопарка:");

            foreach (var animal in _pettingZoo.GetAnimalsForPettingZoo())
            {
                Console.WriteLine($"{animal.GetType().Name} (Инвентарный номер: {animal.InventoryNumber})");
            }

            Thread.Sleep(3000);
        }
    }
}