using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ClientSer
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            client.Connect(ipServer);
            string sGui = "Hello Server!";
            byte[] gui = Encoding.ASCII.GetBytes(sGui);
            client.Send(gui);
            byte[] nhan = new byte[1024];
            int rec = client.Receive(nhan);
            string sNhan = Encoding.ASCII.GetString(nhan, 0, rec);
            Console.WriteLine("Server gui: {0}", sNhan);
            client.Close();
        }
    }
}
