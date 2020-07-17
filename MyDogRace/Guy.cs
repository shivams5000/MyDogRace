using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDogRace
{
    class Guy : Punter
    {
        public string Name;
        public int Money;
        public Bet Bet;

        //guy's GUI controls
        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdateLabels()
        {
            //set the label to bet's description and label on radio button to show money
            MyLabel.Text = this.Bet.GetDescription(); //"Bets $"+Bet.Amount + " on dog " + (Bet.Dog +1);
        }

       

        //Set the Max limit for bucks to spend = 15
        public bool IsExceedBetLimit(int amount)
        {
            if (amount > 50 && amount > 5)
                return true;

            return false;
        }
        public override bool PlaceBet(int BetAmount, int DogToWin)
        {
            //Place a new bet and store it
            //return true if guy had enough bucks to bet
            if (this.Money > BetAmount)
            {
                if (IsExceedBetLimit(BetAmount))
                {
                    MessageBox.Show("You can't spend greater than 15 on dog.", "DOG RACE", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                else
                {
                    Bet = new Bet()
                    {
                        Amount = BetAmount,
                        Dog = DogToWin,
                        Bettor = this  
                    };
                }
                UpdateLabels();

               
                return true;
            }
            else
            {
                Console.WriteLine(this.Name + " didn't have enough to bet");
                return false;
            }
        }

        
    }
}
