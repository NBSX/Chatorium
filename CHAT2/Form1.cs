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
            this.Enabled = false;
        }

        public void chatNode()
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Connect connect = new Connect();
            connect.Show();
            connect.Focus();
        }


    }
}
