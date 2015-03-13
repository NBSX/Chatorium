using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAT2
{
    class MessageObject
    {
        protected string author;
        protected string message;

        public MessageObject(string a, string m = null)
        {
            if (m == null)
                m = "";
            author = a;
            message = m;
        }

        public override string ToString()
        {
            if (String.Compare(author, "command") == 0)
                return message;
            return String.Concat("<", author, "> ", message);
        }
    }
}
