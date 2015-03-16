using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace CHAT2
{
     class ServerProcess
    {
         public string message;
         StreamWriter sw;
         Stream stream;
         Thread runner;

        public ServerProcess()
        {
            Socket soc = Chat.tcplistener.AcceptSocket();
            stream = new NetworkStream(soc);
            sw = new StreamWriter(stream);
            runner = new Thread(new ThreadStart(Run));
            runner.Start();
        }

        public  void Run()
        {
            int i = 0;
            while (true)
            {
                Chat.outputLog("running ["+i+"]");
                i++;
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
