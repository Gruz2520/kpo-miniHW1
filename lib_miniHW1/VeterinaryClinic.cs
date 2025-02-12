using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    public interface IVeterinaryClinic
    {
        bool IsHealthy(Animal animal);
    }

    public class VeterinaryClinic : IVeterinaryClinic
    {
        public bool IsHealthy(Animal animal)
        {
            // Простая проверка здоровья (например, если потребление еды больше 0)
            return animal.FoodConsumption > 0;
        }
    }
}
