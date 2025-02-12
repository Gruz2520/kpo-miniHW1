using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    public class Wolf : Predator
    {
        public Wolf(int inventoryNumber, double foodConsumption)
        {
            InventoryNumber = inventoryNumber;
            FoodConsumption = foodConsumption;
        }
    }
}
