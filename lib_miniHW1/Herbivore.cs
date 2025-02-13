using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    /// <summary>
    /// Абстрактный класс, представляющий травоядных животных.
    /// Наследуется от базового класса Animal.
    /// </summary>
    public abstract class Herbivore : Animal
    {
        /// <summary>
        /// Уровень доброты травоядного животного в диапазоне 1-10.
        /// Определяет, насколько животное дружелюбно к посетителям.
        /// </summary>
        public int KindnessLevel { get; set; }

        /// <summary>
        /// Определяет, может ли травоядное животное взаимодействовать с посетителями.
        /// Животное может взаимодействовать, если уровень доброты превышает 5.
        /// </summary>
        /// <returns>True, если уровень доброты больше 5; иначе False.</returns>
        public override bool CanInteractWithVisitors()
        {
            return KindnessLevel > 5;
        }
    }
}