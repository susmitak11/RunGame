using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunGame
{
    public class Contestant
    {
        public PictureBox Picture { get; set; }
        public string Name { get; set; }

        public Contestant()
        {

        }

        public Contestant(PictureBox picture, string name)
        {
            Picture = picture;
            Name = name;
        }

        public void CreateContestant(PictureBox picture, string name)
        {
            Picture = picture;
            Name = name;
        }
    }
}
