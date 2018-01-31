using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

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

            EventWaitHandle wh = new EventWaitHandle(true, EventResetMode.AutoReset, "EventWaitHandle");
            EventWaitHandle wh1 = new EventWaitHandle(false, EventResetMode.AutoReset, "EventWaitHandle1");
            while (true)
            {
                string str;
                string line;
                wh.WaitOne();
                using (StreamReader sr = new StreamReader(FileNameRead))
                {
                    line = sr.ReadLine();
                     str =  op.Check(line);
                   
                }
                using (StreamWriter writer = new StreamWriter(FileNameWrite))
                {
                    writer.WriteLine(str);

                }
                wh1.Set();
                wh1.WaitOne();
                wh.Set();
            }
        }
    }
}
