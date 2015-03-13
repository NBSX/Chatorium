using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHAT2
{
    public partial class MessageItem : UserControl
    {
        protected string author;
        protected string message;
        protected Color highlight;
        protected Color textcolor;

        public MessageItem(Color h, Color t, string a, string s = null)
        {
            InitializeComponent();
            if (s != null) message = s;
            else message = "";

            author = a;
            highlight = h;
            textcolor = t;
        }

        public void Highlight(bool bit = false)
        {
            if (bit)
                BackColor = highlight;
            else
                BackColor = Color.Transparent;
        }

        public string Author { get { return author; } }
        public string Message { get { return message; } }
        public Color TextColor { get { return textcolor; } set { textcolor = value; } }
        
    }
}
