using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAT2
{
    class Peer
    {
        string name;

        public Peer()
        {
            name = "unnamed";
        }

        public Peer(string s)
        {
            name = s;
        }

        public string Name { get { return name; } set { name = value; } }
    }
}
