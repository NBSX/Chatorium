using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace CHAT2
{
    public partial class Chat : Form
    {

        public const int port = 10714;
        public const uint bufferSize = 2048;

        List<MessageObject> chatlist;
        public static TcpClient tcpclient;
        public static TcpListener tcplistener;
        Thread clientThread;
        Thread serverThread;
        ClientProcess clientProcess;
        ServerProcess serverProcess;
        bool connected = false;

        public Chat()
        {
            InitializeComponent();
            chatlist = new List<MessageObject>();
            writeToChat("Bem Vindo!");
            writeToChat("Arroz! Arroz! Arroz!");
            tbSend.Text = "Write here!";
            tbSend.Focus();
        }

        public void chatNode()
        {

        }

        private void tbSend_KeyUp(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(13)))
            {
                sendText();
            }
        }

        private void sendText()
        {
            try
            {
                if (tbSend.Text[0] == '/')
                    parseCommand();
                else
                {
                    if (connected)
                        serverProcess.message = tbSend.Text;
                    writeToChat(tbSend.Text, "localhost");
                }
                tbSend.Clear();
            }
            catch (Exception e1)
            {
            }
        }

        private void parseCommand()
        {
            string[] command = tbSend.Text.Split(' ');
            switch(command[0])
            {
                case "/about":
                    {
                        writeToChat("Chat Program 0.002 Alpha");
                        break;
                    }
                case "/connect":
                    {
                        if (connected) break;
                        try
                        {
                            IPAddress ip = IPAddress.Parse(command[1]);
                            if (IPAddress.IsLoopback(ip))
                            {
                                writeToChat("Loopback IP is not useable.");
                                return;
                            }

                            /*byte[] mask = new byte[4];
                            string[] bytes = command[2].Split('.');
                            mask[0] = Convert.ToByte(bytes[0]);
                            mask[1] = Convert.ToByte(bytes[1]);
                            mask[2] = Convert.ToByte(bytes[2]);
                            mask[3] = Convert.ToByte(bytes[3]);
                            writeToChat("Valid Mask:  " + bytes[0] + "." + bytes[1] + "." + bytes[2] + "." + bytes[3]);*/
                            connected = connect(ip);
                            if (!connected)
                                writeToChat("Could not connect to: " + ip.ToString());
                            
                        }
                        catch(Exception e2)
                        {
                            Console.WriteLine("ERROR E2: INVALID IP ADDRESS OR NETMASK");
                            writeToChat("Invalid IP address or netmask.");
                        }
                        break;
                    }
                case "/listen":
                    {
                        if (connected) break;
                        connected = listen();
                        if (connected)
                            writeToChat("Connection received!");
                        else
                            writeToChat("Error while listening");

                        break;
                    }
            }
        }

        public void writeToChat(string msg, string author = "command")
        {
            chatlist.Add(new MessageObject(author, msg));
            RefreshChat();
        }

        private void RefreshChat()
        {
            chatbox.DataSource = null;
            chatbox.DataSource = chatlist;
        }


        private bool connect(IPAddress ip)
        {
            try
            {
                tcpclient = new TcpClient();
                tcpclient.Connect(ip,port);

                clientThread.Start(clientProcess);
                return true;
            }
            catch(Exception connectex)
            {
                writeToChat("Connection error!");
                Console.WriteLine("ERROR CONNECTEX: CONNECTION ERROR");
                Console.WriteLine(connectex.ToString());
                return false;
            }
        }

        private bool listen()
        {
            try
            {
                tcplistener = new TcpListener(port);
                tcplistener.Start();
                serverThread.Start(serverProcess);
                return true;
            }
            catch(Exception listenex)
            {
                writeToChat("Listen error!");
                Console.WriteLine("ERROR LISTENEX: LISTEN ERROR");
                Console.WriteLine(listenex.ToString());
                return false;
            }
        }

        
    }
}
