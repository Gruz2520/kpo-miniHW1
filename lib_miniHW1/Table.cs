using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    public class Table : Thing
    {
        public int LegsCount { get; set; }
        public string Material { get; set; }

        public Table(int id, string name, string description, int legsCount, string material)
            : base(id, name, description)
        {
            LegsCount = legsCount;
            Material = material;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Количество ножек: {LegsCount}, Материал: {Material}");
        }
    }
}
