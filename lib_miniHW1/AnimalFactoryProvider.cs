using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    public static class AnimalFactoryProvider
    {
        private static readonly Dictionary<string, IAnimalFactory> _factories = new()
    {
        { "Monkey", new MonkeyFactory() },
        { "Rabbit", new RabbitFactory() },
        { "Tiger", new TigerFactory() },
        { "Wolf", new WolfFactory() }
    };

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
