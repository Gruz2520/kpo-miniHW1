using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    public class Computer : Thing
    {
        public string Brand { get; set; }
        public int RAM { get; set; } 

        public Computer(int id, string name, string description, string brand, int ram)
            : base(id, name, description)
        {
            Brand = brand;
            RAM = ram;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Бренд: {Brand}, ОЗУ: {RAM} ГБ");
        }
    }
}
