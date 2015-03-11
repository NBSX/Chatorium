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
        public Chat()
        {
            InitializeComponent();
            tbSend.Focus();
        }

        public void chatNode()
        {

        }

        private void chatbox_Click(object sender, EventArgs e)
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
                    //sendMessage();
                    writeToChat("SHIT");
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
                        writeToChat("Chat Program 0.001 Alpha");
                        break;
                    }
            }
        }

        private void writeToChat(string msg)
        {
            chatbox.Text += Environment.NewLine;
            chatbox.Text += msg;
        }
    }
}
