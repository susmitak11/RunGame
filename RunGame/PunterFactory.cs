using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunGame
{
    public static class PunterFactory
    {
        public static PunterAbstract CreatePunter(String name)
        {
            PunterAbstract punter = null;

            if (name == "Robert")
                punter = new Robert(50, false);
            else if (name == "Samuel")
                return new Samuel(50, false);
            else if (name == "George")
                return new George(50, false);
            return punter;
        }
    }
}
