using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunGame
{
    public partial class Form1 : Form
    {
        

        PunterAbstract[] punters = new PunterAbstract[3];
        
        
        public Form1()
        {
            InitializeComponent();
            SetUp();
        }

        public void SetUp()
        {
            punters[0] = PunterFactory.CreatePunter("Robert");
            punters[1] = PunterFactory.CreatePunter("Samuel");
            punters[2] = PunterFactory.CreatePunter("George");
        }

        private void BetBtn_Click(object sender, EventArgs e)
        {
            Contestant temp = new Contestant();
            int index = Convert.ToInt32(ContestantName.Value);

            if (index == 0)
                temp.CreateContestant(Rabbit, "Rabbit");
            else if (index == 1)
                temp.CreateContestant(Turtle, "Turtle");
            else if (index == 2)
                temp.CreateContestant(Tom, "Tom");
            else if (index == 3)
                temp.CreateContestant(Jerry, "Jerry");
            else
                MessageBox.Show("Error!, could not create the contestant");

            int bet = Convert.ToInt32(BetAmount.Value);

            if (RobertRadBtn.Checked)
            {
                punters[0].contestant = temp;
                punters[0].Bet = bet;
                RobertSituation.Text = punters[0].Name + " bet " + punters[0].Bet + " on contestant " + temp.Name;
                //remove this line later!!! depends on you!
                textBox1.Text = punters[0].Cash + "";
            }
            else if (SamuelRadBtn.Checked)
            {
                punters[1].contestant = temp;
                punters[1].Bet = bet;
                SamuelSituation.Text = punters[1].Name + " bet " + punters[1].Bet + " on contestant " + temp.Name;
                textBox1.Text = punters[1].Cash + "";
            }
            else if (GeorgeRadBtn.Checked)
            {
                punters[2].contestant = temp;
                punters[2].Bet = bet;
                GeorgeSituation.Text = punters[2].Name + " bet " + punters[2].Bet + " on contestant " + temp.Name;
                textBox1.Text = punters[2].Cash + "";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            StartRace.Enabled = false;
        }

        private void StartRace_Click(object sender, EventArgs e)
        {
            Contestant[] contestants = new Contestant[4];
            contestants[0] = new Contestant(Rabbit, "Rabbit");
            contestants[1] = new Contestant(Turtle, "Turtle");
            contestants[2] = new Contestant(Tom, "Tom");
            contestants[3] = new Contestant(Jerry, "Jerry");

            Point p0 = new Point(contestants[0].Picture.Location.X, contestants[0].Picture.Location.Y);
            Point p1 = new Point(contestants[1].Picture.Location.X, contestants[1].Picture.Location.Y);
            Point p2 = new Point(contestants[2].Picture.Location.X, contestants[2].Picture.Location.Y);
            Point p3 = new Point(contestants[3].Picture.Location.X, contestants[3].Picture.Location.Y);

            while (contestants[0].Picture.Location.X < 700 || contestants[1].Picture.Location.X < 700 || contestants[2].Picture.Location.X < 700 || contestants[3].Picture.Location.X < 700 )
               
            {
                Random rnd = new Random();

                int random = rnd.Next(10, 20);
                p0.X += random;
                contestants[0].Picture.Location = p0;

                random = rnd.Next(10, 20);
                p1.X += random;
                contestants[1].Picture.Location = p1;

                random = rnd.Next(10, 20);
                p2.X += random;
                contestants[2].Picture.Location = p2;

                random = rnd.Next(10, 20);
                p3.X += random;
                contestants[3].Picture.Location = p3;
            }

            int max = contestants[0].Picture.Location.X;
            int index = 0;
            for(int i = 1; i < 4; i++)
            {
                if(contestants[i].Picture.Location.X > max)
                {
                    max = contestants[i].Picture.Location.X;
                    index = i;
                }
            }

            MessageBox.Show(index + "");

            for(int j = 0; j < 3; j++)
            {
                if(punters[j].contestant.Name == contestants[index].Name)
                {
                    punters[j].Cash = punters[j].Cash + punters[j].Bet;
                }
                else
                {
                    punters[j].Cash -= punters[j].Bet; 
                }
            }
       
        }
        public void ResetContestantPositions()
        {
            for (int i = 0; i < 4; i++)
            {
                
            }
        }
        //coding for a reset bets
        public void ResetBets()
        {
            for (int i = 0; i < 3; i++)
            {
                label1.Text = "Robert hasn't placed any bets.";
                label2.Text = "Samuel hasn't placed any bets.";
                label3.Text = "George hasn't placed any bets.";
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

     
    }
 
}


                 
