using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    /// <summary>
    /// Фабрика для создания обезьян.
    /// </summary>
    public class MonkeyFactory : IAnimalFactory
    {
        /// <summary>
        /// Создает экземпляр обезьяны.
        /// </summary>
        /// <param name="inventoryNumber">Инвентарный номер животного.</param>
        /// <param name="foodConsumption">Количество потребляемой еды (кг/сутки).</param>
        /// <returns>Экземпляр класса Monkey.</returns>
        public Animal Create(int inventoryNumber, double foodConsumption)
        {
            DataProcessing.ReadInt("Введите уровень доброты (1-10): ", out int kindnessLevel, 1, 10);
            return new Monkey(inventoryNumber, foodConsumption, kindnessLevel);
        }
    }

    /// <summary>
    /// Фабрика для создания кроликов.
    /// </summary>
    public class RabbitFactory : IAnimalFactory
    {
        /// <summary>
        /// Создает экземпляр кролика.
        /// </summary>
        /// <param name="inventoryNumber">Инвентарный номер животного.</param>
        /// <param name="foodConsumption">Количество потребляемой еды (кг/сутки).</param>
        /// <returns>Экземпляр класса Rabbit.</returns>
        public Animal Create(int inventoryNumber, double foodConsumption)
        {
            DataProcessing.ReadInt("Введите уровень доброты (1-10): ", out int kindnessLevel, 1, 10);
            return new Rabbit(inventoryNumber, foodConsumption, kindnessLevel);
        }
    }

    /// <summary>
    /// Фабрика для создания тигров.
    /// </summary>
    public class TigerFactory : IAnimalFactory
    {
        /// <summary>
        /// Создает экземпляр тигра.
        /// </summary>
        /// <param name="inventoryNumber">Инвентарный номер животного.</param>
        /// <param name="foodConsumption">Количество потребляемой еды (кг/сутки).</param>
        /// <returns>Экземпляр класса Tiger.</returns>
        public Animal Create(int inventoryNumber, double foodConsumption)
        {
            return new Tiger(inventoryNumber, foodConsumption);
        }
    }

    /// <summary>
    /// Фабрика для создания волков.
    /// </summary>
    public class WolfFactory : IAnimalFactory
    {
        /// <summary>
        /// Создает экземпляр волка.
        /// </summary>
        /// <param name="inventoryNumber">Инвентарный номер животного.</param>
        /// <param name="foodConsumption">Количество потребляемой еды (кг/сутки).</param>
        /// <returns>Экземпляр класса Wolf.</returns>
        public Animal Create(int inventoryNumber, double foodConsumption)
        {
            return new Wolf(inventoryNumber, foodConsumption);
        }
    }
}