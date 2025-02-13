using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    /// <summary>
    /// Статический класс для предоставления фабрик животных.
    /// Используется для получения конкретной фабрики на основе типа животного.
    /// </summary>
    public static class AnimalFactoryProvider
    {
        /// <summary>
        /// Словарь, содержащий зарегистрированные фабрики для различных типов животных.
        /// Ключ — тип животного, значение — соответствующая фабрика.
        /// </summary>
        private static readonly Dictionary<string, IAnimalFactory> _factories = new()
        {
            { "Monkey", new MonkeyFactory() },
            { "Rabbit", new RabbitFactory() },
            { "Tiger", new TigerFactory() },
            { "Wolf", new WolfFactory() }
        };

        /// <summary>
        /// Возвращает фабрику для указанного типа животного.
        /// Если тип животного не найден, кидаем исключение ArgumentException.
        /// </summary>
        /// <param name="animalType">Тип животного.</param>
        /// <returns>Фабрика для создания животного указанного типа.</returns>
        /// <exception cref="ArgumentException">Кидаем исключение, если тип животного неизвестен.</exception>
        public static IAnimalFactory GetFactory(string animalType)
        {
            if (_factories.TryGetValue(animalType, out var factory))
            {
                return factory;
            }
            throw new ArgumentException($"Неизвестный тип животного: {animalType}");
        }
    }
}