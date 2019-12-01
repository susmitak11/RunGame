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
        

        PunterAbstract[] punters = new PunterAbstract[3];//setting an object for abstract
        
        
        public Form1()
        {
            InitializeComponent();
            SetUp();
        }

        public void SetUp()
        {

            punters[0] = PunterFactory.CreatePunter("Robert");//setting punters for the game
            punters[1] = PunterFactory.CreatePunter("Samuel");
            punters[2] = PunterFactory.CreatePunter("George");
        }

        private void BetBtn_Click(object sender, EventArgs e)
        {
            Contestant temp = new Contestant();
            int index = Convert.ToInt32(ContestantName.Value);
            //contestants  and their indexes
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

            int bet = Convert.ToInt32(BetAmount.Value);// setting bet value

            if (RobertRadBtn.Checked)//setting things for robert as a punter to bet in the match
            {
                punters[0].contestant = temp;
                punters[0].Bet = bet;
                RobertSituation.Text = punters[0].Name + " bet $" + punters[0].Bet + " on contestant " + temp.Name;
                
            }
            else if (SamuelRadBtn.Checked)//setting things for samuel as a punter to bet in the match
            {
                punters[1].contestant = temp;
                punters[1].Bet = bet;
                SamuelSituation.Text = punters[1].Name + " bet $" + punters[1].Bet + " on contestant " + temp.Name;
               
            }
            else if (GeorgeRadBtn.Checked)//setting things for george as a punter to bet in the match
            {
                punters[2].contestant = temp;
                punters[2].Bet = bet;
                GeorgeSituation.Text = punters[2].Name + " bet  $" + punters[2].Bet + " on contestant " + temp.Name;
                
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            StartRace.Enabled = false;
        }

        private void StartRace_Click(object sender, EventArgs e)
        {
            int startPosition = Rabbit.Left;
            Contestant[] contestants = new Contestant[4];
            contestants[0] = new Contestant(Rabbit, "Rabbit", startPosition);
            contestants[1] = new Contestant(Turtle, "Turtle", startPosition);
            contestants[2] = new Contestant(Tom, "Tom", startPosition);
            contestants[3] = new Contestant(Jerry, "Jerry", startPosition);

            Point p0 = new Point(contestants[0].Picture.Location.X, contestants[0].Picture.Location.Y);//point of location for Rabbit
            Point p1 = new Point(contestants[1].Picture.Location.X, contestants[1].Picture.Location.Y);//point of location for Turtle
            Point p2 = new Point(contestants[2].Picture.Location.X, contestants[2].Picture.Location.Y);//point of location for Tom
            Point p3 = new Point(contestants[3].Picture.Location.X, contestants[3].Picture.Location.Y);//point of location for Jerry

            while (contestants[0].Picture.Location.X < 700 || contestants[1].Picture.Location.X < 700 || contestants[2].Picture.Location.X < 700 || contestants[3].Picture.Location.X < 700 )
               
            {
                Random rnd = new Random();//creating random number
                //creating the random number limit for the contestant to run 
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
            //maximum location for the contestant to run
            int max = contestants[0].Picture.Location.X;
            int index = 0;
            for(int i = 0; i < contestants.Length; i++)
            {//winner of the game
                if(contestants[i].Picture.Location.X > max)
                {
                    max = contestants[i].Picture.Location.X;
                    index = i;
                }
            }

            for (int j = 0; j < 3; j++)//setting things for bet amount of punters
            {
                if (punters[j].contestant.Name == contestants[index].Name)//creating links between the contestant and punters who win the race
                {
                    punters[j].Cash = punters[j].Cash + punters[j].Bet;// bet amount is added to wining contestant
                }
                else
                {
                    //decrese the amount accorging to their bet
                    punters[j].Cash -= punters[j].Bet;
                }
            }

            // it shows the winner
            MessageBox.Show(index + " has won the match");
            // it will resume the game from starting
            for (int c = 0; c < contestants.Length; c++)
            {
                contestants[c].MoveToStart();
            }

            //will show thw cash money taken by the punter
            RobertCash.Text = "$" + punters[0].Cash;
            SamuelCash.Text = "$" + punters[1].Cash;
            GeorgeCash.Text = "$" + punters[2].Cash;

            //reseting the game
            ResetBets();

            //disabling if not enough money
            if (punters[0].Cash == 0)
            {
                RobertRadBtn.Enabled = false;
                RobertSituation.Text = "Robert is out of money";
            }

            if (punters[1].Cash == 0)
            {
                SamuelRadBtn.Enabled = false;
                SamuelSituation.Text = "Samuel is out of money";
            }

            if (punters[2].Cash == 0)
            {
                GeorgeRadBtn.Enabled = false;
                GeorgeSituation.Text = "George is out of money";
            }



            if(!RobertRadBtn.Enabled && !SamuelRadBtn.Enabled && !GeorgeRadBtn.Enabled)
            {
                MessageBox.Show("Game finished");
            }

        }
        // it is for resetting the game and start from the beginning
        public void ResetBets()
        {
            //reseting the bet amount
            for (int i = 0; i < 3; i++)
                punters[i].Bet = 0;

            RobertSituation.Text = "Robert haven't bet yet";
            GeorgeSituation.Text = "George haven't bet yet";
            SamuelSituation.Text = "Samuel haven't bet yet";

            RobertRadBtn.Checked = false;
            SamuelRadBtn.Checked = false;
            GeorgeRadBtn.Checked = false;
        }
        //to exit the game
        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        //disabling the radio button when robert is out of money
        private void RobertRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            BetAmount.Maximum = punters[0].Cash;
            
        }
        //disabling the radio button when samuel is out of money
        private void SamuelRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            BetAmount.Maximum = punters[1].Cash;
            
        }
        //disabling the radio button when george is out of money
        private void GeorgeRadBtn_CheckedChanged(object sender, EventArgs e)
        {
            BetAmount.Maximum = punters[2].Cash;
            
        }

        
    }
 
}


                 
