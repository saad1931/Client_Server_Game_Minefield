using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Shireen_Np_Project
{
    class ServerClass
    {
        int recv;
        byte[] data = new byte[1024];
        IPEndPoint iep;
        Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Socket client;
        IPEndPoint clientip;
        Stream stream;
        StreamWriter writer;
       
        string msg = "";
        public static string getword = "";
        public ServerClass(IPAddress ip, int port)
        {
            iep = new IPEndPoint(ip, port);
            newsock.Bind(iep);
        }
        public ServerClass()
        {

        }
        public int Accept()
        {
            newsock.Listen(5);
            client = newsock.Accept();
            client.ReceiveTimeout = 50;
            stream = new NetworkStream(client);
            writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            if (client != null)
            {
                clientip = (IPEndPoint)client.RemoteEndPoint;
                /*string welcome = "Welcome to my test server";
                writer.Write(welcome);
                writer.Flush();*/
                return 1;
            }
            else
            {
                return 0;
            }

        }
        public string info()
        {
            
            return "Connected Client IP: " + clientip.Address + " and port is: " + clientip.Port;
        }
        public string Recieve()
        {
            string word = "";
            data = new byte[1024];
            try
            {
                recv = client.Receive(data);
                word = Encoding.ASCII.GetString(data, 0, recv);
            }
            catch (SocketException)
            {
                word = "N";
            }
            return word;
        }
        public void Send(string msg)
        {
            data = Encoding.ASCII.GetBytes(msg);
            client.Send(data);
        }

        //public void sendWord()
        //{
        //    msg = gw.sendword();
        //    data = Encoding.ASCII.GetBytes(msg);
        //    writer.Write(data);
        //}
        public void exitCon()
        {
            client.Close();
            newsock.Close();
        }
        public void dcClient()
        {
            client.Close();
        }
        public void wordfromClient(string word)
        {
            getword = word;
        }


    }
}
