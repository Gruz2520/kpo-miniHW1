using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    public abstract class Animal : IAlive, IInventory
    {
        public int InventoryNumber { get; set; }
        public double FoodConsumption { get; set; }

        public abstract bool CanInteractWithVisitors(); 
    }
}
