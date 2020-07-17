using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDogRace
{
    // This is an Abstract Class having a Method PlaceBet() 
    // to place bet on dog
    abstract class Punter
    {
        // Place Bet on dog with Bet-Amount
        public abstract bool PlaceBet(int BetAmount, int DogToWin);
    }
}
