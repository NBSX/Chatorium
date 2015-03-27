﻿using System;
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

        TcpListener listener;

        Thread receiver_process;

        bool connected = false;
        IPAddress local;
        char[] out_packet;
        char[] in_packet;
        console consola;
        Thread listening;
        Peer me, other, command;

        public Chat()
        {
            InitializeComponent();
            chatlist = new List<MessageObject>();
            tbSend.Focus();
            local = IPAddress.Parse("127.0.0.1");
            in_packet = new char[bufferSize];
            consola = new console();
            consola.Show();
            me = new Peer();
            command = new Peer("command");
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
                        sendPacket(out_packet);
                    }
                    writeToChat(tbSend.Text, me);
                }
                tbSend.Clear();
            }
            catch (Exception e1)
            {
                consola.WriteLine(e1.ToString());
            }
        }

        private void parseCommand()
        {
            string[] command = tbSend.Text.Split(' ');
            switch(command[0])
            {
                case "/about":
                    {
                        writeToChat("Chat Program 0.1 BETA");
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
                            else
                            {
                                receiver_process.Start();
                                string s = "%%#=" + me.Name;
                                out_packet = new char[bufferSize];
                                stringToArray(s, out_packet);
                                sendPacket(out_packet);
                            }
                            
                        }
                        catch(Exception e2)
                        {
                            consola.WriteLine(e2.ToString());
                            //outputLog(e2.ToString());
                            writeToChat("Invalid IP address or netmask.");
                        }
                        break;
                    }
                case "/listen":
                    {
                        if (listening != null)
                        {
                            writeToChat("Already listening.");
                            return;
                        }
                        if (connected) 
                            return;
                        listening = new Thread(new ThreadStart(listen));
                        listening.Start();
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
                case "/toconsole":
                    {
                        for (int i = 1; i < command.Length; i++)
                        {
                            if (command[i] != null)
                                consola.WriteLine(command[i]);
                        }
                            break;
                    }
                case "/name":
                    {
                        if (command[1] != null)
                        {
                            me.Name = command[1];
                            writeToChat("Name set!");
                            if(connected)
                            {
                                string s = "%%#=" + me.Name;
                                out_packet = new char[bufferSize];
                                stringToArray(s, out_packet);
                                sendPacket(out_packet);
                            }
                        }
                        else
                            writeToChat("Invalid name.");

                        break;
                    }
                case "/disconnect":
                    {
                        if (connected)
                        {
                            string s = "%%##terminate-";
                            out_packet = new char[bufferSize];
                            stringToArray(s, out_packet);
                            sendPacket(out_packet);
                            writeToChat("Disconnected.");
                        }
                        break;
                    }
            }
        }

        private void writeToChat(string msg, Peer author = null)
        {
            if(author == null)
                chatlist.Add(new MessageObject(command, msg));
            else
                chatlist.Add(new MessageObject(author, msg));
            RefreshChat();
        }

        private void RefreshChat()
        {
            consola.WriteLine("refreshing...");
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
                return true;
            }
            catch(Exception connectex)
            {
                writeToChat("Connection error!");
                consola.WriteLine(connectex.ToString());
                //outputLog(connectex.ToString());
                return false;
            }
        }

        private void listen()
        {
            try
            {
                writeToChat("Listening...");
                listener = new TcpListener(local,port);
                listener.Start();
                receiver = listener.AcceptTcpClient();
                connected = true;
                receiver_process = new Thread(new ThreadStart(ReceiverProcess));
                receiver_process.Start();
            }
            catch(Exception listenex)
            {
                writeToChat("Listen error!");
                consola.WriteLine(listenex.ToString());
                //outputLog(listenex.ToString());
                connected = false;
                listening = null;
            }

            if (connected)
            {
                writeToChat("Connection received!");
            }
            else
                writeToChat("Error while listening");
        }

        private void ReceiverProcess()
        {
            int count = 0;
            StreamReader sr = new StreamReader(receiver.GetStream());
            StreamWriter sw = new StreamWriter(receiver.GetStream());
            other = new Peer();
            while(connected)
            {
                
                try
                {
                    if(in_packet != null)
                    {
                        sr.Read(in_packet, 0, (int)bufferSize);
                        string s = new string(in_packet);
                        s = s.Trim('\0');
                        s = s.Trim();
                        if (s.Length > 3 && s[0] == '%' && s[1] == '%' && s[2] == '#' && s[3] == '=')
                        {
                            other.Name = s.Substring(4);
                            continue;
                        }
                        if (String.Compare(s, "%%##terminate-") == 0)
                        {
                            connected = false;
                            listening = null;
                            other.Name = "unnamed";
                            writeToChat("Connection terminated by peer.");
                            receiver_process.Abort();
                        }

                        if (s.Length > 0)
                            writeToChat(s, other);
                    }
                }
                catch(Exception cpex)
                {
                    writeToChat("Client Process error!");
                    consola.WriteLine(cpex.ToString());
                    count++;
                    if (count > 100)
                        connected = false;
                    //outputLog(cpex.ToString());
                }
            }
            writeToChat("Connection terminated.");
            receiver.Close();
            sr.Close();
        }

        private void sendPacket(char[] p)
        {
            if (connected)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(receiver.GetStream());
                    sw.Write(p);
                    sw.Flush();
                }
                catch(Exception spex)
                {
                    outputLog(spex.ToString());
                }
            }
            else
            {
                writeToChat("Not connected!");
            }
        }

        public static void outputLog(string s)
        {
            StreamWriter file = new StreamWriter(@"C:\\error_"+ DateTime.Now.Hour.ToString() + ".log",true);
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
