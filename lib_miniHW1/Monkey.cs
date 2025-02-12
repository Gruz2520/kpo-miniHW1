using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    public class Monkey : Herbivore
    {
        public Monkey(int inventoryNumber, double foodConsumption, int kindnessLevel)
        {
            InventoryNumber = inventoryNumber;
            FoodConsumption = foodConsumption;
            KindnessLevel = kindnessLevel;
        }
    }
}
