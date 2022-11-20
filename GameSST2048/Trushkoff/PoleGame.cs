using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game2048
{
    public partial class PoleGame : Form
    {
        Logic lic = new Logic();

        public PoleGame()
        {
            InitializeComponent();


        }

      
        public void InitializeNums()
        {
            textBox1.Text = lic.DrewsNums[0];
            textBox2.Text = lic.DrewsNums[1];
            textBox3.Text = lic.DrewsNums[2];
            textBox4.Text = lic.DrewsNums[3];
            textBox5.Text = lic.DrewsNums[4];
            textBox6.Text = lic.DrewsNums[5];
            textBox7.Text = lic.DrewsNums[6];
            textBox8.Text = lic.DrewsNums[7];
            textBox9.Text = lic.DrewsNums[8];
            textBox10.Text = lic.DrewsNums[9];
            textBox11.Text = lic.DrewsNums[10];
            textBox12.Text = lic.DrewsNums[11];
            textBox13.Text = lic.DrewsNums[12];
            textBox14.Text = lic.DrewsNums[13];
            textBox15.Text = lic.DrewsNums[14];
            textBox16.Text = lic.DrewsNums[15];
        }

    
        private void Form1_Load(object sender, EventArgs e)
        {

            lic.ReGame();
            InitializeNums();

        }

        



        
        private void Button1_Click_1(object sender, EventArgs e)
        {
            lic.ReGame();
            InitializeNums();
        }

      
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {


                if (lic.CanUp() == true)
                {
                    lic.Up();
                    lic.Create();
                }


                lic.RunLose();
                InitializeNums();

            }
            else if (e.KeyData == Keys.Left)
            {
                if (lic.CanLeft() == true)
                {
                    lic.Left();
                    lic.Create();
                }

                lic.RunLose();
                InitializeNums();
            }
            else if (e.KeyData == Keys.Right)
            {
                if (lic.CanRight() == true)
                {
                    lic.Right();
                    lic.Create();
                }
                lic.RunLose();
                InitializeNums();
            }
            else if (e.KeyData == Keys.Down)
            {
                if (lic.CanDown() == true)
                {
                    lic.Down();
                    lic.Create();
                }
                lic.RunLose();
                InitializeNums();
            }
        }
    }
}
