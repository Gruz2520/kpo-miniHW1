using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    public abstract class Thing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        protected Thing(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id}, Название: {Name}, Описание: {Description}");
        }
    }
}
