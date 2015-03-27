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
            console_output.AppendText(s);
            console_output.AppendText(Environment.NewLine);
            console_output.AppendText("==================================");
            console_output.AppendText(Environment.NewLine);
            if (s[0] == '/')
                parseCommand(s);
        }

        private void parseCommand(string command)
        {

        }
    }
}
