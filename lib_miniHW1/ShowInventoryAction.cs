using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    /// <summary>
    /// Класс, реализующий действие "Просмотреть инвентаризацию" в меню.
    /// </summary>
    public class ShowInventoryAction : IMenuAction
    {
        private readonly IInventoryPrinter _inventory;

        /// <summary>
        /// Конструктор классаъ.
        /// </summary>
        /// <param name="inventory">Объект, предоставляющий доступ к данным инвентаризации.</param>
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