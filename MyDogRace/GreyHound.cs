using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDogRace
{
    public class GreyHound
    {
        public int StartingPosition;
        public int RacetrackLength;
        public PictureBox MyPictureBox = null;
        public int Location = 0;
        public Random Randomizer;
        public bool flag = false;
       
        public bool Run(PictureBox racetrack)
        {
            //move forward either 1,2,3,4,... or 5 spaces at random

            
                this.MyPictureBox.Top += this.Randomizer.Next(1, 5);
                

                if (this.MyPictureBox.Bottom > (racetrack.Bottom))
                {
                   
                return true;
                    
                }

            return false;

            //update the position of my picturebox on the form

        }

        public void TakeStartingPosition()
        {
            //reset location to 0 and picturebox to starting position
            Location = 0;
            StartingPosition = 0;
            
        }
    }
}
