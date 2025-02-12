using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    public class MonkeyFactory : IAnimalFactory
    {
        public Animal Create(int inventoryNumber, double foodConsumption)
        {
            DataProcessing.ReadInt("Введите уровень доброты (1-10): ", out int kindnessLevel, 1, 10);
            return new Monkey(inventoryNumber, foodConsumption, kindnessLevel);
        }
    }

    public class RabbitFactory : IAnimalFactory
    {
        public Animal Create(int inventoryNumber, double foodConsumption)
        {
            DataProcessing.ReadInt("Введите уровень доброты (1-10): ", out int kindnessLevel, 1, 10);
            return new Rabbit(inventoryNumber, foodConsumption, kindnessLevel);
        }
    }

    public class TigerFactory : IAnimalFactory
    {
        public Animal Create(int inventoryNumber, double foodConsumption)
        {
            return new Tiger(inventoryNumber, foodConsumption);
        }
    }
    public class WolfFactory : IAnimalFactory
    {
        public Animal Create(int inventoryNumber, double foodConsumption)
        {
            return new Wolf(inventoryNumber, foodConsumption);
        }
    }

}
