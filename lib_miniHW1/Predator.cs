using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    /// <summary>
    /// Абстрактный класс, представляющий хищных животных.\
    /// </summary>
    public abstract class Predator : Animal
    {
        /// <summary>
        /// Определяет, может ли хищное животное взаимодействовать с посетителями.
        /// Хищные животные не могут взаимодействовать с посетителями.
        /// </summary>
        /// <returns>Всегда возвращает false. Потому что мне так захотелось.</returns>
        public override bool CanInteractWithVisitors()
        {
            return false;
        }
    }
}