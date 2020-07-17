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
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                // after the timer's tick, launch the next frame
                this.Hide();
                GamePanel obj = new GamePanel();
                obj.Show();
                timer1.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Start_Load(object sender, EventArgs e)
        {
            timer1.Start();// Timer start at form load
        }
    }
}
