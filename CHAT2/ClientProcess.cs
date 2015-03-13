using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace CHAT2
{
     class ClientProcess : Chat
    {
        string message;
        StreamReader sr;

        public ClientProcess()
        {
            sr = new StreamReader(Chat.tcpclient.GetStream());
            Run();
        }

        public void Run()
        {
            while(true)
            {
                try
                {
                    if(message == null)
                    {
                        message = sr.ReadLine();
                        writeToChat(message);
                        message = null;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
