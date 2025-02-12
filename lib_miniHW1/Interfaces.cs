using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    public interface IMenuAction
    {
        string Name { get; }
        void Execute();
    }

    public interface IThingFactory
    {
        Thing Create(int id, string name, string description);
    }

    public interface IAnimalManager
    {
        void AddAnimal(Animal animal);
    }

    public interface IFoodCalculator
    {
        double GetTotalFoodConsumption();
    }

    public interface IPettingZoo
    {
        IEnumerable<Animal> GetAnimalsForPettingZoo();
    }

    public interface IInventoryPrinter
    {
        void PrintInventory();
    }

    public interface IAlive
    {
        double FoodConsumption { get; set; } 
    }

    public interface IInventory
    {
        int InventoryNumber { get; set; }
    }

    public interface IAnimalFactory
    {
        Animal Create(int inventoryNumber, double foodConsumption);
    }
}
