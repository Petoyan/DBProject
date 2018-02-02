using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Commons;

namespace Server
{
    public class ReadWrite
    {

        private readonly string FileNameRead;
        private readonly string FileNameWrite;
        public ReadWrite(string fileNameRead, string fileNameWrite)
        {
            FileNameRead = fileNameRead;
            FileNameWrite = fileNameWrite;

        }
        Operations op = new Operations();

        public void On()
        {
            EventWaitHandle eventReader = EWHCheck.OpenorCreate(false, EventResetMode.AutoReset, "eventReader");
            EventWaitHandle eventRW = EWHCheck.OpenorCreate(false, EventResetMode.AutoReset, "eventRW");
            EventWaitHandle eventWriter = EWHCheck.OpenOrWait("eventWriter");
            while (true)
            {
                string str;
                string line;
                eventWriter.WaitOne();
                using (StreamReader sr = new StreamReader(FileNameRead))
                {
                    line = sr.ReadLine();
                    str = op.Check(line);

                }
                using (StreamWriter writer = new StreamWriter(FileNameWrite))
                {
                    writer.WriteLine(str);

                }
                eventRW.Set();
                eventReader.Set();

            }
        }
    }
}
