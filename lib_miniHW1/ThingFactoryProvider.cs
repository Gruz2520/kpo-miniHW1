using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    /// <summary>
    /// Статический класс для предоставления фабрик вещей. Китай так же развивался.
    /// </summary>
    public static class ThingFactoryProvider
    {
        /// <summary>
        /// Возвращает фабрику для указанного типа вещи.
        /// </summary>
        /// <param name="thingType">Тип вещи.</param>
        /// <returns>Фабрика для создания вещи указанного типа.</returns>
        /// <exception cref="ArgumentException">Кидаем, если тип вещи неизвестен.</exception>
        public static IThingFactory GetFactory(string thingType)
        {
            return thingType.ToLower() switch
            {
                "table" => new TableFactory(),
                "computer" => new ComputerFactory(), 
                _ => throw new ArgumentException($"Неизвестный тип вещи: {thingType}") 
            };
        }
    }
}