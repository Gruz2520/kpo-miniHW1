using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    public abstract class Predator : Animal
    {
        public override bool CanInteractWithVisitors()
        {
            return false;
        }
    }
}
