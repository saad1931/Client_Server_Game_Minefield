using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Shireen_Np_Project
{
    class ClientClass
    {
        byte[] data = new byte[1024];
        string input;
        IPEndPoint iep;
        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public ClientClass(IPAddress ip, int port)
        {
            iep = new IPEndPoint(ip, port);
        }
        public ClientClass()
        {

        }
        public string connect()
        {
            try
            {
                server.Connect(iep);
                return "Connection successful.";
            }
            catch (SocketException)
            {
                return "Connection failed.";
            }
        }
        public string recieve()
        {
            string word = "";
            server.ReceiveTimeout = 50;
            data = new byte[1024];
            try
            {
                int recv = server.Receive(data);
                word = Encoding.ASCII.GetString(data, 0, recv);
            }
            catch (SocketException exp)
            {
                word = exp.ToString();
                word = "N";
            }
            return word;
        }
        public string send(string message)
        {
            input = message;
            if (input == "exit")
            {
                Environment.Exit(0);
            }
            else
            {
                server.Send(Encoding.ASCII.GetBytes(input));
            }
            return "Sent";
        }
    }
}
