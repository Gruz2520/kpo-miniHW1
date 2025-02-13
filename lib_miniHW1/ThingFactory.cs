using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    /// <summary>
    /// Фабрика для создания столов. Маленькое производство туда сюда.
    /// </summary>
    public class TableFactory : IThingFactory
    {
        /// <summary>
        /// Создает экземпляр стола.
        /// </summary>
        /// <param name="id">Идентификатор вещи.</param>
        /// <param name="name">Название вещи.</param>
        /// <param name="description">Описание вещи.</param>
        /// <returns>Экземпляр класса Table.</returns>
        public Thing Create(int id, string name, string description)
        {
            DataProcessing.ReadInt("Введите количество ножек: ", out int legsCount, 0);
            DataProcessing.ReadString("Введите материал стола: ", out string material);

            return new Table(id, name, description, legsCount, material);
        }
    }

    /// <summary>
    /// Фабрика для создания компьютеров. Вот оно - российское производство компьютеров.
    /// </summary>
    public class ComputerFactory : IThingFactory
    {
        /// <summary>
        /// Создает экземпляр компьютера с указанными параметрами.
        /// </summary>
        /// <param name="id">Идентификатор вещи.</param>
        /// <param name="name">Название вещи.</param>
        /// <param name="description">Описание вещи.</param>
        /// <returns>Экземпляр класса Computer.</returns>
        public Thing Create(int id, string name, string description)
        {
            DataProcessing.ReadString("Введите бренд компьютера: ", out string brand);
            DataProcessing.ReadInt("Введите объем ОЗУ (ГБ): ", out int ram, 0);

            return new Computer(id, name, description, brand, ram);
        }
    }
}