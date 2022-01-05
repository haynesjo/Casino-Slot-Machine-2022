using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlotMachine
{
    public partial class frmSlot : Form
    {
        private bool myblnBorder1 = false;
        private bool myblnBorder2 = false;
        private bool myblnBorder3 = false;

        //These will handle money
        private decimal mydecBet = 1;
        private decimal mydecWinnings = 0;
        private decimal mydecCash = 5;

        public frmSlot()
        {
            InitializeComponent();
        }

        private void tmrSlot1_Tick(object sender, EventArgs e)
        {
            ChangePicture(lblSlot1, picSlot1);
            if (stop())
            {
                tmrSlot1.Enabled = false;
            }
        }
        private void ChangePicture(Label lbl, PictureBox pic)
        {
            int intNumber = int.Parse(lbl.Text); //int.parse is making the text turn into an integer cause lblSlot.Text is a text not an integer
            intNumber++;//This will add 1 to intNumber
            //make sure the number is not bigger than the number of pictures
            if (intNumber > 7)
            {
                intNumber = 1;
            }
            lbl.Text = intNumber.ToString(); //.ToString is making the integer turn into the string again
            Image picNun = ((PictureBox)this.Controls.Find("pic" + intNumber.ToString(), true)[0]).BackgroundImage;
            pic.BackgroundImage = picNun;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //This is when the button is disabled after pushed the lever
            //This is when the casino GETs my cash
            mydecCash -= mydecBet;
            btnLever.Enabled = false;
            btbBet1.Enabled = false;
            btnBet4.Enabled = false;
            btnReset.Enabled = false;
            btnBetMax.Enabled = false;
            tmrSlot1.Enabled = true;
            tmrSlot2.Enabled = true;
            tmrSlot3.Enabled = true;
           
        }


        private void tmrSlot2_Tick(object sender, EventArgs e)
        {
            ChangePicture(lblSlot2, picSlot2);
            if (!tmrSlot1.Enabled && stop())
            {
                tmrSlot2.Enabled = false;
            }
        }


        private void tmrSlot3_Tick(object sender, EventArgs e)
        {
            ChangePicture(lblSlot3, picSlot3);
            if (!tmrSlot2.Enabled && stop())
            {
                tmrSlot3.Enabled = false;
                //we need to reenable the buttons so the user can play again
                btnLever.Enabled = true;
                btbBet1.Enabled = true;
                btnBet4.Enabled = true;
                btnBetMax.Enabled = true;
                btnReset.Enabled = true;
                Win();
            }
        }
        Random rndStop = new Random();
        private bool stop()
        {
            //This will return true if the random number generator says to
            return rndStop.Next(0, 10) == 7;
        }
        private void Win()
        {
            //This will check if I won or not
            mydecWinnings = 0;
            //We need to set these to false becaue none of the windows are winners by default
            myblnBorder1 = false;
            myblnBorder2 = false;
            myblnBorder3 = false;
            if (lblSlot1.Text == lblSlot2.Text && lblSlot1.Text == lblSlot3.Text)
            {
                //BIG WINNER!!!
                myblnBorder1 = true;
                myblnBorder2 = true;
                myblnBorder3 = true;
                mydecWinnings = mydecBet * 10;
            }
            else if (lblSlot1.Text == lblSlot2.Text)
            {
                //small winner
                myblnBorder1 = true;
                myblnBorder2 = true;
                mydecWinnings = mydecBet;



            }
            //todo: I need to add the other two ways to win here!
            else if (lblSlot1.Text == lblSlot3.Text)
            {
                //small winner
                myblnBorder1 = true;
                myblnBorder3 = true;
                mydecWinnings = mydecBet;



            }
            else if (lblSlot2.Text == lblSlot3.Text)
            {
                //small winner
                myblnBorder2 = true;
                myblnBorder3 = true;
                mydecWinnings = mydecBet;



            }
            mydecCash = mydecCash + mydecWinnings;
            showMeDaMoney();
            tmrWin.Enabled = true;
        }


        private void tmrWin_Tick(object sender, EventArgs e)
        {
            //This will change the backcolor of the winning borders
            if (picBorder1.BackColor == Color.Firebrick)
            {
                picBorder1.BackColor = Color.Gold;
            }
            else if (picBorder1.BackColor == Color.Gold)
            {
                picBorder1.BackColor = Color.Azure;
            }
            else
            {
                picBorder1.BackColor = Color.Firebrick;
            }
            picBorder2.BackColor = picBorder1.BackColor;
            picBorder3.BackColor = picBorder1.BackColor;

            if (stop())
            {
                tmrWin.Enabled = false;
                myblnBorder1 = false;
                myblnBorder2 = false;
                myblnBorder3 = false;

            }
            //This will show the right borders
            picBorder1.Visible = myblnBorder1;
            picBorder2.Visible = myblnBorder2;
            picBorder3.Visible = myblnBorder3;
        }

        private void frmSlot_Load(object sender, EventArgs e)
        {
            showMeDaMoney();
        }
        private void showMeDaMoney()
        {
            if (mydecCash <= 0)
            {
                MessageBox.Show("You are out of money", "I am generous and will give you more");
                ResetEverything(); //when cash hits 0 it gives the message to the player that the money is all gone
            }

            if (mydecBet>mydecCash)
            {
                mydecBet = mydecCash;
            }

            btnBet4.Visible = mydecCash >= 4;
            btbBet1.Visible = mydecCash >= 1;
            btnBetMax.Visible = mydecCash > 0;

            btnLever.Enabled = true;


            lblBet.Text = mydecBet.ToString("C");
            lblWinning.Text = mydecWinnings.ToString("C");
            lblCash.Text = mydecCash.ToString("C");
        }
        private void ResetEverything()
        {
            mydecBet = 1;
            mydecCash = 5;
            mydecWinnings = 0;
            showMeDaMoney();
        }

        private void btnBet4_Click(object sender, EventArgs e)
        {
            mydecBet = 4;
            showMeDaMoney();
        }

        private void btnBet1_Click(object sender, EventArgs e)
        {
            mydecBet = 1;
            showMeDaMoney();
        }

        private void btnBetMax_Click(object sender, EventArgs e)
        {
            mydecBet = mydecCash;
            showMeDaMoney();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetEverything(); //This will reset everything to the default
        }

        private void frmSlot_Load_1(object sender, EventArgs e)
        {
           MessageBox.Show("Welcome") ; //This will give welcome message when the program is run
            showMeDaMoney(); //This will replace label1 to $
        }

       
    }
}
