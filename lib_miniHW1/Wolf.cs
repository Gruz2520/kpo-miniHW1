using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    /// <summary>
    /// Класс, представляющий волка как хищное животное. Волк не тигр, но в цирке не выступает.
    /// </summary>
    public class Wolf : Predator
    {
        /// <summary>
        /// Конструктор для создания экземпляра волка.
        /// </summary>
        /// <param name="inventoryNumber">Инвентарный номер волка.</param>
        /// <param name="foodConsumption">Количество потребляемой еды (кг/сутки).</param>
        public Wolf(int inventoryNumber, double foodConsumption)
        {
            InventoryNumber = inventoryNumber;
            FoodConsumption = foodConsumption;
        }
    }
}