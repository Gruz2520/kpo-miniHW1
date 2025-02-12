using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    public class ShowTotalFoodConsumptionAction : IMenuAction
    {
        private readonly IFoodCalculator _foodCalculator;

        public ShowTotalFoodConsumptionAction(IFoodCalculator foodCalculator)
        {
            _foodCalculator = foodCalculator;
        }

        public string Name => "Просмотреть общее потребление еды";

        public void Execute()
        {
            Console.Clear();
            Console.WriteLine($"Общее потребление еды: {_foodCalculator.GetTotalFoodConsumption()} кг");
            Thread.Sleep(3000);
        }
    }
}
