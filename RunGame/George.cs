using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunGame
{
    class George : PunterAbstract
    {//taking the things from abstract class for george

        public George(int cash, bool outOfMoney)
        {
            Name = "George";
            Cash = cash;
            OutOfMoney = outOfMoney;
        }

    }
}
