using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    /// <summary>
    /// Класс, представляющий тигра как хищное животное. Не лев, а тигр!
    /// </summary>
    public class Tiger : Predator
    {
        /// <summary>
        /// Конструктор для создания экземпляра тигра.
        /// </summary>
        /// <param name="inventoryNumber">Инвентарный номер тигра.</param>
        /// <param name="foodConsumption">Количество потребляемой еды (кг/сутки).</param>
        public Tiger(int inventoryNumber, double foodConsumption)
        {
            InventoryNumber = inventoryNumber;
            FoodConsumption = foodConsumption;
        }
    }
}