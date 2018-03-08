using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ServerCli
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);


            server.Bind(ip);
            server.Listen(3);
            Socket client = server.Accept();
            byte[] nhan = new byte[1024];
            int rec = client.Receive(nhan);
            string sNhan = Encoding.ASCII.GetString(nhan, 0, rec);
            Console.WriteLine("Client gui: {0}", sNhan);

            string sGui = "Hello Client!";
            byte[] gui = Encoding.ASCII.GetBytes(sGui);
            client.Send(gui);
            client.Close();
        }
    }
}
