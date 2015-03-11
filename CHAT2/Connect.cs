using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace CHAT2
{
    public partial class Connect : Form
    {
        public Connect()
        {
            InitializeComponent();
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            IPAddress ip = IPAddress.Parse(tbIP.Text); //throws exception
            
        }

    }
}
