using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Commons;

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
            EventWaitHandle eventWriter = EWHCheck.OpenorCreate(false, EventResetMode.AutoReset, "eventWriter");
            EventWaitHandle eventReader = EWHCheck.OpenOrWait("eventReader");
            EventWaitHandle eventRW = EWHCheck.OpenOrWait("eventRW");
            while (true)
            {
                using (StreamWriter sw = new StreamWriter(FileNameWrite))
                {
                    string write = Console.ReadLine();
                    sw.WriteLine(write);
                }
                eventWriter.Set();
                eventRW.WaitOne();
                eventReader.WaitOne();
                using (StreamReader sr = new StreamReader(FileNameRead))
                {
                    Console.WriteLine(sr.ReadLine());
                }



            }
        }
    }
}
