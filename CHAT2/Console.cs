using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHAT2
{
    public partial class console : Form
    {
        public console()
        {
            InitializeComponent();
        }

        private void console_output_Click(object sender, EventArgs e)
        {

        }

        public void WriteLine(string s)
        {
            console_output.Text += s;
            console_output.Text += Environment.NewLine;
        }
    }
}
