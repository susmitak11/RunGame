using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RunGame
{//it is abstract class providing different functionality to punters
    public abstract class PunterAbstract
    {
        public abstract string Name { get; set; }
        public abstract int Cash { get; set; }
        public abstract int Bet { get; set; }
        public abstract bool OutOfMoney { get; set; }
        public abstract Contestant contestant { get; set; }
               
    }

    
}

