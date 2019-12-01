using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunGame
{
    class Samuel : PunterAbstract
    {//taking things from abstract class for george
        public Samuel(int cash, bool outOfMoney)
        {
            Name = "Samuel";
            Cash = cash;
            OutOfMoney = outOfMoney;
        }
    }
}
