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

        public MessageObject(Peer a, string m = null)
        {
            if (m == null)
                m = "";
            author = a;
            message = m;
        }

        public override string ToString()
        {
            if (String.Compare(author.Name, "command") == 0)
                return message;
            return String.Concat("<", author, "> ", message);
        }
    }
}
