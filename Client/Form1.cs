using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        const int PORT_NO = 9999;
        const string SERVER_IP = "127.0.0.1";
        TcpClient client;
        NetworkStream nwStream;

        public Form1()
        {
            InitializeComponent();

            client = new TcpClient(SERVER_IP, PORT_NO);
            nwStream = client.GetStream();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes("TOOUNCES " + textToSend.Text);
            send(bytesToSend);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes("TOGRAM " + textToSend.Text);
            send(bytesToSend);
        }

        private void send(byte[] bytesToSend)
        {
            Console.WriteLine("Sending : " + textToSend.Text);
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);
            
            byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            string response = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
            result.Text = response;
            Console.WriteLine("Received : " + response);
            Console.ReadLine();
        }

        private void Form1_FormClosing(object sender, EventArgs e)
        {
            client.Close();
        }
    }
}
