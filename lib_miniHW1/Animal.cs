using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    /// <summary>
    /// Абстрактный базовый класс для всех животных.
    /// </summary>
    public abstract class Animal : IAlive, IInventory
    {
        /// <summary>
        /// Инвентарный номер животного.
        /// Используется для идентификации животного в зоопарке.
        /// </summary>
        public int InventoryNumber { get; set; }

        /// <summary>
        /// Количество потребляемой еды (кг/сутки).
        /// Определяет, сколько еды требуется животному для поддержания жизнедеятельности.
        /// </summary>
        public double FoodConsumption { get; set; }

        /// <summary>
        /// Абстрактный метод для проверки возможности взаимодействия с посетителями.
        /// </summary>
        /// <returns>True, если животное может взаимодействовать с посетителями; иначе False.</returns>
        public abstract bool CanInteractWithVisitors();
    }
}