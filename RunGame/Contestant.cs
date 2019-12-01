using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunGame
{
    public class Contestant// it is the contestant class
    {
        public PictureBox Picture { get; set; }// to view picture of contestant
        public string Name { get; set; }//setting name

        public int startPosition { get; set; }// move to start postion
        public Contestant()
        {
            
        }

        public Contestant(PictureBox picture, string name, int startPos)
        {
            Picture = picture;
            Name = name;
            this.startPosition = startPos;
        }

        public void CreateContestant(PictureBox picture, string name)
        {
            Picture = picture;
            Name = name;
        }
        //resetting the contestant
        public void MoveToStart()
        {
            Picture.Left = startPosition;
        }
    }
}
