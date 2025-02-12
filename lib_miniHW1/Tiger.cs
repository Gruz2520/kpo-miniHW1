using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    public class Tiger : Predator
    {
        public Tiger(int inventoryNumber, double foodConsumption)
        {
            InventoryNumber = inventoryNumber;
            FoodConsumption = foodConsumption;
        }
    }
}
