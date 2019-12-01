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
        public string Name { get; set; }
        public int Cash { get; set; }
        public int Bet { get; set; }
        public bool OutOfMoney { get; set; }
        public Contestant contestant { get; set; }

    }
}

