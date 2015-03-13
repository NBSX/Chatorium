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
     class ServerProcess
    {
         public string message;
         StreamWriter sw;
         Stream stream;
 

        public ServerProcess()
        {
            Socket soc = Chat.tcplistener.AcceptSocket();
            stream = new NetworkStream(soc);
            sw = new StreamWriter(stream);
            Run();
        }

        public  void Run()
        {
            while (true)
            {
                try
                {
                    if (message != null)
                    {
                        sw.Write(message);
                        message = null;
                    }
                    stream.Flush();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
