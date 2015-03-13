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
 

        public ServerProcess()
        {
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
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
