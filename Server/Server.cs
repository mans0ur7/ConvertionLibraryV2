using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Server
    {
        const int PORT_NO = 9999;
        const string SERVER_IP = "127.0.0.1";
        static void Main(string[] args)
        {
            var convertions = new Convertions();

            IPAddress localAdd = IPAddress.Parse(SERVER_IP);
            TcpListener listener = new TcpListener(localAdd, PORT_NO);
            Console.WriteLine("Listening...");
            listener.Start();

            //---incoming client connected---
            TcpClient client = listener.AcceptTcpClient();

            //---get the incoming data through a network stream---
            NetworkStream nwStream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];
            int bytesRead;
            string dataReceived;
            
            while (true)
            {
                //---read incoming stream---
                bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

                //---convert the data received into a string---
                dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                if (dataReceived.Equals("exit")) break;
                if (!dataReceived.Contains(' '))
                {
                    nwStream.Write(Encoding.ASCII.GetBytes("Error"), 0, 5);
                    continue;
                }
                var cmd = dataReceived.Split(' ');
                string send;
                if (cmd[0].Equals("TOGRAM")) send = convertions.OuncesToGrams(Double.Parse(cmd[1])).ToString();
                else if (cmd[0].Equals("TOOUNCES")) send = convertions.GramsToOunces(Double.Parse(cmd[1])).ToString();
                else
                {
                    nwStream.Write(Encoding.ASCII.GetBytes("Error"), 0, 5);
                    continue;
                }
                Console.WriteLine("Receiving: " + dataReceived);
                Console.WriteLine("Sending: " + send);
                nwStream.Write(Encoding.ASCII.GetBytes(send), 0, send.Length);
            }

            client.Close();
            listener.Stop();
            Console.ReadLine();
        }
    }
}
