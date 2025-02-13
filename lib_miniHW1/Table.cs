using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    /// <summary>
    /// Да, стол. Ну типа да, просто стол.
    /// </summary>
    public class Table : Thing
    {
        public int LegsCount { get; set; }
        public string Material { get; set; }

        /// <summary>
        /// Конструктор для создания экземпляра стола.
        /// </summary>
        /// <param name="id">Идентификатор вещи.</param>
        /// <param name="name">Название вещи.</param>
        /// <param name="description">Описание вещи.</param>
        /// <param name="legsCount">Количество ножек стола.</param>
        /// <param name="material">Материал стола.</param>
        public Table(int id, string name, string description, int legsCount, string material)
            : base(id, name, description)
        {
            LegsCount = legsCount;
            Material = material;
        }

        /// <summary>
        /// Показываем крутизну стола.
        /// </summary>
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Количество ножек: {LegsCount}, Материал: {Material}");
        }
    }
}
