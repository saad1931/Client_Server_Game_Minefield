using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Shireen_Np_Project
{
    public partial class Server : Form
    {
        ServerClass sc;
        public static string word = "";
        //GetWord gw = new GetWord();
        public Server()
        {
            InitializeComponent();
            end.Enabled = false;
            accept.Enabled = false;
            listBox1.Enabled = false;
           // word = gw.sendword();
        }

        



        public void button()
        {
            //word = gw.sendword();
            Selection ws = new Selection();
            this.Hide();
            ws.Show();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            string txt = sc.Recieve();
            if (txt == "exit" || txt == "Exit")
            {
                listBox1.Items.Clear();
                timer1.Stop();
            }
            else if (txt != "N")
            {
                sc.wordfromClient(txt);
            }
        }

        private void start_Click_1(object sender, EventArgs e)
        {
            IPHostEntry ipentry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] ip = ipentry.AddressList;
            label1.Text = label1.Text + ip[1].ToString();
            label2.Text = label2.Text + "1111";
            sc = new ServerClass(IPAddress.Parse(ip[1].ToString()), int.Parse("1111"));
            accept.Enabled = true;
            end.Enabled = true;
            start.Enabled = false;
        }

        private void accept_Click_1(object sender, EventArgs e)
        {
            int check = sc.Accept();
            if (check == 1)
            {
                listBox1.Items.Add(sc.info());
                timer1.Start();

            }
            else
            {
                MessageBox.Show("No incoming connection");
            }
        }

        private void end_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
