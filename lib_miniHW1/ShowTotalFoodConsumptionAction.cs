using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    /// <summary>
    /// Класс, реализующий действие "Просмотреть общее потребление еды" в меню.
    /// </summary>
    public class ShowTotalFoodConsumptionAction : IMenuAction
    {
        private readonly IFoodCalculator _foodCalculator;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="foodCalculator">Объект, предоставляющий расчет общего потребления еды.</param>
        public ShowTotalFoodConsumptionAction(IFoodCalculator foodCalculator)
        {
            _foodCalculator = foodCalculator;
        }

        public string Name => "Просмотреть общее потребление еды";

        public void Execute()
        {
            Console.Clear();
            double totalFoodConsumption = _foodCalculator.GetTotalFoodConsumption();
            Console.WriteLine($"Общее потребление еды: {totalFoodConsumption} кг");
            Thread.Sleep(3000);
        }
    }
}