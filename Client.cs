using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;

namespace Shireen_Np_Project
{
    public partial class Client : Form
    {
        Server s = new Server();
        ClientClass cc;
        string[] a = new string[2];
        public Client()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

      

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            string msg = cc.send("exit");
            Environment.Exit(0);
        }

        

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void connect_Click_1(object sender, EventArgs e)
        {
            cc = new ClientClass(IPAddress.Parse(textBox1.Text), int.Parse(textBox2.Text));
            string msg = cc.connect();
            if (msg != "Connection failed.")
            {
                MessageBox.Show("Connection successful");
                button1.Enabled = true;
                timer1.Start();
                connect.Enabled = false;
                disconnected.Enabled = true;
            }
            else
            {
                MessageBox.Show(msg);
            }
        }

        private void disconnected_Click_1(object sender, EventArgs e)
        {
            string msg = cc.send("exit");
            MessageBox.Show("Disconnected");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            s.button();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            string text = cc.recieve();
            if (text != "N" && text != "")
            {
                MessageBox.Show(text);
            }
        }
    }
}
