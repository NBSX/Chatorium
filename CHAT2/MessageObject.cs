using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAT2
{
    class MessageObject
    {
        protected Peer author;
        protected string message;
        protected string time_stamp;

        public MessageObject(Peer a, string m = null)
        {
            if (m == null)
                m = "";
            author = a;
            message = m;
            time_stamp = DateTime.Now.ToString();
        }

        public override string ToString()
        {
            if (String.Compare(author.Name, "command") == 0)
                return message;
            return String.Concat(time_stamp + "   <", author.Name, "> ", message);
        }
    }
}
