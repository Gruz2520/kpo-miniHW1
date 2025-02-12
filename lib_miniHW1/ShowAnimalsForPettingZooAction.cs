using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    public class ShowAnimalsForPettingZooAction : IMenuAction
    {
        private readonly IPettingZoo _pettingZoo;

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
