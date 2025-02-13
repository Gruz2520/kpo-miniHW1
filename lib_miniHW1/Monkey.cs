using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    /// <summary>
    /// Класс, представляющий обезьянку как травоядное животное.
    /// Наследуется от класса Herbivore.
    /// </summary>
    public class Monkey : Herbivore
    {
        /// <summary>
        /// Конструктор для создания экземпляра обезьяны.
        /// </summary>
        /// <param name="inventoryNumber">Инвентарный номер обезьяны.</param>
        /// <param name="foodConsumption">Количество потребляемой еды (кг/сутки).</param>
        /// <param name="kindnessLevel">Уровень доброты.</param>
        public Monkey(int inventoryNumber, double foodConsumption, int kindnessLevel)
        {
            InventoryNumber = inventoryNumber;

            FoodConsumption = foodConsumption;

            KindnessLevel = kindnessLevel;
        }
    }
}