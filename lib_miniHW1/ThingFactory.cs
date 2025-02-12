using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    public class TableFactory : IThingFactory
    {
        public Thing Create(int id, string name, string description)
        {
            DataProcessing.ReadInt("Введите количество ножек: ", out int legsCount, 0);
            DataProcessing.ReadString("Введите материал стола: ", out string material);

            return new Table(id, name, description, legsCount, material);
        }
    }

    public class ComputerFactory : IThingFactory
    {
        public Thing Create(int id, string name, string description)
        {
            DataProcessing.ReadString("Введите бренд компьютера: ", out string brand);
            DataProcessing.ReadInt("Введите объем ОЗУ (ГБ): ", out int ram, 0);

            return new Computer(id, name, description, brand, ram);
        }
    }
}
