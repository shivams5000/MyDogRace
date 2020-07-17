using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDogRace
{
    public partial class GamePanel : Form
    {
        //Initialize array of guys
        Guy[] guys = new Guy[3];

        //intialize array of greyhounds
        GreyHound[] GreyhoundArray = new GreyHound[5];
        public GamePanel()
        {
            InitializeComponent();
            guys[0] = new Guy() { Money = 75, Name = "Shivam", MyLabel = lblJoe, MyRadioButton = radioJoe };
            guys[1] = new Guy() { Money = 75, Name = "Rishi", MyLabel = lblBob, MyRadioButton = radioBob };
            guys[2] = new Guy() { Money = 75, Name = "Smith", MyLabel = lblAl, MyRadioButton = radioAl };
            foreach (Guy guy in guys)
                guy.PlaceBet(0, 0);

            //set the default bet name to Joe
            lblName.Text = guys[0].Name;

            GreyhoundArray[0] = new GreyHound()
            {
                MyPictureBox = pictureBox1,
                StartingPosition = pictureBox1.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox1.Width,
                Randomizer = new Random()
            };

            GreyhoundArray[1] = new GreyHound()
            {
                MyPictureBox = pictureBox2,
                StartingPosition = pictureBox2.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox2.Width,
                Randomizer = GreyhoundArray[0].Randomizer
            };

            GreyhoundArray[2] = new GreyHound()
            {
                MyPictureBox = pictureBox3,
                StartingPosition = pictureBox3.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox3.Width,
                Randomizer = GreyhoundArray[0].Randomizer
            };

            GreyhoundArray[3] = new GreyHound()
            {
                MyPictureBox = pictureBox4,
                StartingPosition = pictureBox4.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox4.Width,
                Randomizer = GreyhoundArray[0].Randomizer
            };

            GreyhoundArray[4] = new GreyHound()
            {
                MyPictureBox = pictureBox5,
                StartingPosition = pictureBox5.Left,
                RacetrackLength = racetrackPictureBox.Width - pictureBox4.Width,
                Randomizer = GreyhoundArray[0].Randomizer
            };

            updateForm();
        }

        private void GamePanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    DialogResult result = MessageBox.Show("Do you really want to exit?", "Alert", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Application.ExitThread();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void updateForm()
        {
            radioJoe.Text = guys[0].Name + " has $" + guys[0].Money;
            radioBob.Text = guys[1].Name + " has $" + guys[1].Money;
            radioAl.Text = guys[2].Name + " has $" + guys[2].Money;
        }

        private void btnRace_Click(object sender, EventArgs e)
        {
            try
            {
                //reset dog positions
                foreach (GreyHound g in GreyhoundArray)
                {
                    g.MyPictureBox.Left = g.StartingPosition;
                }

                //start timer for race

                timer1.Enabled = true;

                //int winner = new Random().Next(1,4);
                //while(!GreyhoundArray[0].Run(racetrackPictureBox));
                //MessageBox.Show("Dog " + (winner + 1) + " wins!");
                //MessageBox.Show("Dogs ran");
                btnRace.Enabled = false;
                btnBets.Enabled = false;
                button1.Enabled = false;
            }
            catch (Exception ex)
            {
                    MessageBox.Show(ex.Message);
            }
        }

        private void btnBets_Click(object sender, EventArgs e)
        {
            try
            {
                // Bets button working here
                int guy;
                if (radioJoe.Checked)
                {
                    guy = 0;
                }
                else if (radioBob.Checked)
                {
                    guy = 1;
                }
                else
                {
                    guy = 2;
                }

                /*place the bet for the selected amount on the selected dog 
                 by the selected guy */
                guys[guy].PlaceBet((int)numBets.Value, (int)numDog.Value - 1);

                Console.WriteLine(guys[guy].Name + " bets $" + guys[guy].Bet.Amount + " on dog " + (guys[guy].Bet.Dog + 1));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioJoe_CheckedChanged(object sender, EventArgs e)
        {
            lblName.Text = guys[0].Name; //set the name of guy on label for Rahul
        }

        private void radioBob_CheckedChanged(object sender, EventArgs e)
        {
            lblName.Text = guys[1].Name; //set the name of guy on label for Bobby
        }

        private void radioAl_CheckedChanged(object sender, EventArgs e)
        {
            lblName.Text = guys[2].Name; //set the name of guy on label for Amit
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int winner;
            //while (!GreyhoundArray[0].Run(racetrackPictureBox) && !GreyhoundArray[1].Run(racetrackPictureBox) && !GreyhoundArray[2].Run(racetrackPictureBox) && !GreyhoundArray[3].Run(racetrackPictureBox)) { }
            //timer1.Enabled = false;
            for (int i = 0; i < GreyhoundArray.Length; i++)
            {
                
                if (GreyhoundArray[i].Run(racetrackPictureBox))
                {
                    winner = i;
                    timer1.Enabled = false;
                    MessageBox.Show("Dog #" + (winner + 1) + " Wins!");
                    for (int j = 0; j < guys.Length; j++)
                    {
                        if (guys[j].Bet.PayOut(winner) != 0)
                            guys[j].Money += guys[j].Bet.PayOut(winner);
                        guys[j].MyRadioButton.Text = guys[j].Name + " has $" + guys[j].Money;
                        if (guys[0].Money < 5)
                        {
                            lblJoe.Text = "BUSTED!";
                            guys[0].MyRadioButton.Enabled = false;
                        }
                        else if (guys[1].Money < 5)
                        {
                            lblBob.Text = "BUSTED!";
                            guys[1].MyRadioButton.Enabled = false;

                        }
                        else if (guys[2].Money < 5)
                        {
                            lblAl.Text = "BUSTED!";
                            guys[2].MyRadioButton.Enabled = false;
                        }
                        else if (guys[0].Money < 5 && guys[1].Money < 5 && guys[2].Money < 5)
                        {
                            lblAl.Text = "BUSTED!"; lblBob.Text = "BUSTED!"; lblJoe.Text = "BUSTED!";
                            guys[0].MyRadioButton.Enabled = false;
                            guys[1].MyRadioButton.Enabled = false;
                            guys[2].MyRadioButton.Enabled = false;
                            MessageBox.Show("GAME OVER");

                            // buttons disabled here
                            btnBets.Enabled = false;
                            btnRace.Enabled = false;
                            button1.Enabled = false;
                        }
                    }

                    // buttons enabled again
                    btnBets.Enabled = true;
                    
                    button1.Enabled = true;
                    
                    break;

                }
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Top = 0;
            pictureBox2.Top = 0;
            pictureBox3.Top = 0;
            pictureBox4.Top = 0;
            pictureBox5.Top = 0;
            btnRace.Enabled = true;
            
        }
    }
}
