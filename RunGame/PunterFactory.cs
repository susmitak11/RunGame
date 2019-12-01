using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunGame
{
    public class PunterFactory
    {
       public PunterAbstract CreatePunter(String name)
        {
            PunterAbstract punter = null;

            if (name == "Robert")
            {
                punter = new Robert(50, false);
                return punter;
            }
            else if (name == "Samuel")
            {
                punter = new Samuel(50, false);
                return punter;
            }
            else if (name == "George")
            {
                punter = new George(50, false);
                return punter;
            }
            return null;
        }
    }
}
