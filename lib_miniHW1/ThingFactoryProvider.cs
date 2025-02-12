using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    public static class ThingFactoryProvider
    {
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
