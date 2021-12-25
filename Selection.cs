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
    public partial class Selection : Form
    {
        Form1 g = new Form1();
        public Selection()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //g.fromWhere("Server");
            this.Hide();
            g.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //g.fromWhere("Client");
            this.Hide();
            g.Show();
        }

    }
}
