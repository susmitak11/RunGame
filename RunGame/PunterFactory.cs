using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunGame
{
    public class PunterFactory
    {//it is an abstract class to define punter and the money they have
        static int Count = 0;
       public static PunterAbstract CreatePunter(String name)
        {
            Count++;

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

        public static int ReturnCount()
        {
            return Count;
        }
    }
}
