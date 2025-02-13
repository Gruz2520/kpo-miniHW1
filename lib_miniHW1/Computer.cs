using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    /// <summary>
    /// Класс, представляющий компьютер как тип вещи.
    /// Наследуется от базового класса Thing.
    /// </summary>
    public class Computer : Thing
    {
        public string Brand { get; set; }
        public int RAM { get; set; }

        /// <summary>
        /// Конструктор для создания экземпляра компьютера.
        /// </summary>
        /// <param name="id">Идентификатор вещи.</param>
        /// <param name="name">Название вещи.</param>
        /// <param name="description">Описание вещи.</param>
        /// <param name="brand">Бренд компьютера, йоу.</param>
        /// <param name="ram">Объем оперативной памяти в.</param>
        public Computer(int id, string name, string description, string brand, int ram)
            : base(id, name, description)
        {
            Brand = brand;
            RAM = ram;
        }

        /// <summary>
        /// Переопределенный метод для отображения информации о компьютере.
        /// </summary>
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Бренд: {Brand}, ОЗУ: {RAM} ГБ");
        }
    }
}