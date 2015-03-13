using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CHAT2
{
    public partial class ChatContainer : UserControl
    {
        List<MessageItem> message_list;
        protected const int MESSAGE_LIMIT = 50;
        protected StreamWriter logger;

        public ChatContainer()
        {
            InitializeComponent();
            message_list = new List<MessageItem>();
        }

        public void AddMessage(string author, Color author_color, bool color,string message = null)
        {
            MessageItem m = message_list.Last();
            Program.WriteToLog(m.Message);
            message_list.Remove(m);
            m = null;   //faster garbage collection

            if (message == null)
                message = "";

            MessageItem MI = new MessageItem(color ? Color.Silver : Color.Firebrick, author_color, author, message);
            message_list.Add(MI);
            components.Add(MI);
            Refresh();
        }
    }
}
