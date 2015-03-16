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
using Microsoft.Win32;

namespace CHAT2
{
    public partial class Chat : Form
    {

        public const int port = 10714;
        public const uint bufferSize = 2048;

        static List<MessageObject> chatlist;
        TcpClient receiver;
        TcpClient sender;

        TcpListener listener;

        Thread receiver_process;
        Thread sender_process;

        bool connected = false;
        IPAddress local;
        char[] out_packet;
        char[] in_packet;
        

        public Chat()
        {
            InitializeComponent();
            chatlist = new List<MessageObject>();
            tbSend.Focus();
            local = IPAddress.Parse("127.0.0.1");
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
                    {
                        out_packet = new char[bufferSize];
                        stringToArray(tbSend.Text,out_packet);
                    }
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
                            /*if (IPAddress.IsLoopback(ip))
                            {
                                writeToChat("Loopback IP is not useable.");
                                return;
                            }*/

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
                            outputLog(e2.ToString());
                            writeToChat("Invalid IP address or netmask.");
                        }
                        break;
                    }
                case "/listen":
                    {
                        if (connected) break;
                        connected = listen();
                        if (connected)
                        {
                            writeToChat("Connection received!");
                        }
                        else
                            writeToChat("Error while listening");

                        break;
                    }
                case "/setip":
                    {
                        local = IPAddress.Parse(command[1]);
                        if (local != null)
                            writeToChat("IP successfully set to: " + local.ToString());
                        else
                            writeToChat("Invalid IP address!");
                        break;
                    }
            }
        }

        public static void writeToChat(string msg, string author = "command")
        {
            chatlist.Add(new MessageObject(author, msg));
            RefreshChat();
        }

        private static void RefreshChat()
        {
            chatbox.DataSource = null;
            chatbox.DataSource = chatlist;
        }


        private bool connect(IPAddress ip)
        {
            try
            {
                receiver = new TcpClient();
                receiver.Connect(ip,port);
                receiver_process = new Thread(new ThreadStart(ReceiverProcess));
                receiver_process.Start();
                return true;
            }
            catch(Exception connectex)
            {
                writeToChat("Connection error!");
                outputLog(connectex.ToString());
                return false;
            }
        }

        private bool listen()
        {
            try
            {
                listener = new TcpListener(local,port);
                listener.Start();
                receiver = listener.AcceptTcpClient();
                receiver_process = new Thread(new ThreadStart(ReceiverProcess));
                receiver_process.Start();
                return true;
            }
            catch(Exception listenex)
            {
                writeToChat("Listen error!");
                outputLog(listenex.ToString());
                return false;
            }
        }

        private void ReceiverProcess()
        {
            StreamReader sr = new StreamReader(receiver.GetStream());
            StreamWriter sw = new StreamWriter(receiver.GetStream());
            while(true)
            {
                try
                {
                    sr.Read(in_packet, 0, (int)bufferSize);
                    if(in_packet != null)
                    {
                        string s = new string(in_packet);
                        s = s.Trim('\0');
                        s = s.Trim();
                        if(s.Length > 1)
                            writeToChat(s);
                        in_packet = null;
                    }

                    if(out_packet != null)
                    {
                        Thread.Sleep(500);
                        string g = new string(out_packet);
                        g = g.Trim('\0');
                        g = g.Trim();
                        if (String.Compare(g, "orangemonkeyeagle") == 0)
                            break;
                        sw.WriteLine(out_packet);
                        out_packet = null;
                    }
                    sw.Flush();
                }
                catch(Exception cpex)
                {
                    writeToChat("Client Process error!");
                    outputLog(cpex.ToString());
                }
            }
            writeToChat("Connection terminated.");
            receiver.Close();
            sr.Close();
            sw.Close();
        }

        public static void outputLog(string s)
        {
            StreamWriter file = new StreamWriter(@"C:\\error_"+ DateTime.Now.Hour.ToString() + ".log");
            file.WriteLine(DateTime.Today.ToString() + ":::" + DateTime.Now.TimeOfDay.ToString());
            file.WriteLine(s);
            file.WriteLine("==================================================");
            file.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        
        private void stringToArray(string s, char[] c)
        {
            for (int i = 0; i < s.Length; i++)
                c[i] = s[i];

        }
    }
}
