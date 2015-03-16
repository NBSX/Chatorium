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
     class ClientProcess : Chat
    {
        string message;
        StreamReader sr;
        Stream stream;
        Thread runner;

        public ClientProcess()
        {
            stream = Chat.tcpclient.GetStream();
            sr = new StreamReader(stream);
            runner = new Thread(new ThreadStart(Run));
            runner.Start();
        }

        public void Run()
        {
            while(true)
            {
                try
                {
                    message = sr.ReadLine();
                    if(message != null)
                    {
                        writeToChat(message);
                        message = null;
                    }
                    stream.Flush();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            }
        }
    }
