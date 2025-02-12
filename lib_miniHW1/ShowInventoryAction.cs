using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    public class ShowInventoryAction : IMenuAction
    {
        private readonly IInventoryPrinter _inventory;

        public ShowInventoryAction(IInventoryPrinter inventory)
        {
            _inventory = inventory;
        }

        public string Name => "Просмотреть инвентаризацию";

        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Инвентаризация:");
            _inventory.PrintInventory();
            Thread.Sleep(3000);
        }
    }
}
