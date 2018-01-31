using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Client
{
    public class WriteRead
    {
        private readonly string FileNameRead;
        private readonly string FileNameWrite;
        public WriteRead(string fileNameWrite, string fileNameRead)
        {
            FileNameWrite = fileNameWrite;
            FileNameRead = fileNameRead;
        }
       
        public void On()
        {
            EventWaitHandle wh = new EventWaitHandle(false, EventResetMode.AutoReset, "EventWaitHandle");
            EventWaitHandle wh1 = new EventWaitHandle(true, EventResetMode.AutoReset, "EventWaitHandle1");

            while (true)
            {
                using (StreamWriter sw = new StreamWriter(FileNameWrite))
                {
                    string write = Console.ReadLine();
                    sw.WriteLine(write);
                }
                wh.Set();
                wh1.WaitOne();
                using (StreamReader sr = new StreamReader(FileNameRead))
                {
                    Console.WriteLine(sr.ReadLine());
                    
                }
                wh1.Set();
                wh.WaitOne();
                
            }
        }
    }

}
