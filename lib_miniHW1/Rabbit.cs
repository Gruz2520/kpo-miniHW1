using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    /// <summary>
    /// Класс, представляющий кролика как травоядное животное.
    /// </summary>
    public class Rabbit : Herbivore
    {
        /// <summary>
        /// Конструктор для создания экземпляра кролика.
        /// </summary>
        /// <param name="inventoryNumber">Инвентарный номер кролика.</param>
        /// <param name="foodConsumption">Количество потребляемой еды (кг/сутки).</param>
        /// <param name="kindnessLevel">Уровень доброты.</param>
        public Rabbit(int inventoryNumber, double foodConsumption, int kindnessLevel)
        {
            InventoryNumber = inventoryNumber;
            FoodConsumption = foodConsumption;
            KindnessLevel = kindnessLevel;
        }
    }
}