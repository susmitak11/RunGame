using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunGame
{
    class Robert : PunterAbstract
    {

        public Robert(int cash, bool outOfMoney)
        {
            Name = "Robert";
            Cash = cash;
            OutOfMoney = outOfMoney;
        }
    }
}
 