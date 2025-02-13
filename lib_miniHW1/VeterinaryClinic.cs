using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    /// <summary>
    /// Интерфейс для ветеринарной клиники.
    /// Определяет метод для проверки здоровья животного.
    /// </summary>
    public interface IVeterinaryClinic
    {
        /// <summary>
        /// Проверяет, здоров ли указанное животное.
        /// </summary>
        /// <param name="animal">Животное, которое нужно проверить.</param>
        /// <returns>True, если животное здоровое; иначе False.</returns>
        bool IsHealthy(Animal animal);
    }

    /// <summary>
    /// Класс, реализующий ветеринарную клинику.
    /// </summary>
    public class VeterinaryClinic : IVeterinaryClinic
    {
        /// <summary>
        /// Проверяет, здоров ли указанное животное.
        /// </summary>
        /// <param name="animal">Животное, которое нужно проверить.</param>
        /// <returns>True, если животное здоровое иначе False.</returns>
        public bool IsHealthy(Animal animal)
        {
            // Простая проверка здоровья: если потребление еды больше 0, животное считается здоровым. Почему бы и нет)
            return animal.FoodConsumption > 0;
        }
    }
}