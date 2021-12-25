using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shireen_Np_Project
{
    public partial class Form1 : Form
    {
        public static string value = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int mine1 = rnd.Next(1, 12);
            int mine2 = rnd.Next(13, 18);
            int mine3 = rnd.Next(19, 25);

            for (int i = 1; i <= 25; i++)
            {
                Button btnTemp = new Button();

                btnTemp.Name = "btnTemp" + i.ToString();
                btnTemp.Size = new System.Drawing.Size(40, 40);
                btnTemp.Text = i.ToString();
                btnTemp.UseVisualStyleBackColor = true;

                if (mine1 == i || mine2 == i || mine3 == i)
                    btnTemp.Tag = true;
                else
                    btnTemp.Tag = false;

                btnTemp.Click += btnTemp_Click;
                flowLayoutPanel1.Controls.Add(btnTemp);
            }

        }

        private void btnTemp_Click(object sender, EventArgs e)
        {
            Button btnTemp = (Button)sender;
            bool tag = (bool)btnTemp.Tag;

            if (tag)
            {
                btnTemp.BackColor = Color.Red;
                int score = int.Parse(lblBoom.Text);
                score++;
                lblBoom.Text = score.ToString();
                btnTemp.Enabled = false;

                if (score == 1)
                {
                    MessageBox.Show("You have lost the game!", "Game Result", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }
            }



            else
            {
                btnTemp.BackColor = Color.Green;
                int score = int.Parse(lblScore.Text);
                score++;
                lblScore.Text = score.ToString();
                btnTemp.Enabled = false;

            }


        }
        //public void fromWhere(string msg)
        //{
        //    if (msg == "Server")
        //    {
        //        value = Server.word;
        //        if (value == "")
        //        {
        //            MessageBox.Show("There were no word from server.Proceeding with word from client");
        //            value = ServerClass.getword;
        //        }
        //    }
        //    else
        //    {
        //        value = ServerClass.getword;
        //        if (value == "")
        //        {
        //            MessageBox.Show("There were no word from client.Proceeding with word from server");
        //            value = Server.word;
        //        }
        //    }
        //}
    }
}
