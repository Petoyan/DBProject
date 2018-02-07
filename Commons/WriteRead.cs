using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Commons
{
    public delegate List<String> MyDelegat(object obj, string message);
    public class WriteRead
    {
        private event MyDelegat _OnCheck;
        public event MyDelegat OnCheck
        {
            add
            {
                _OnCheck += value;
            }
            remove
            {
                _OnCheck -= value;
            }
        }
        private readonly string FileNameRead;
        private readonly string FileNameWrite;
      
        public WriteRead(string fileNameWrite, string fileNameRead)
        {
            FileNameWrite = fileNameWrite;
            FileNameRead = fileNameRead;
        }

        public void WriteReade()
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
                //using (StreamReader sr = new StreamReader(FileNameRead))
                //{           
                //        Console.WriteLine(sr.ReadLine()); 
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<string>));
                using (StreamReader file = new StreamReader(FileNameRead))
                {
                    List<string> overview = (List<string>)reader.Deserialize(file);
                                        
                    foreach (var item in overview)
                    {
                        Console.WriteLine(item);
                    }
                   

                }
                //}
            }
        }
        public void ReadWrite()
        {
            EventWaitHandle eventReader = EWHCheck.OpenorCreate(false, EventResetMode.AutoReset, "eventReader");
            EventWaitHandle eventRW = EWHCheck.OpenorCreate(false, EventResetMode.AutoReset, "eventRW");
            EventWaitHandle eventWriter = EWHCheck.OpenOrWait("eventWriter");
            while (true)
            {
                List<string> str;
                string line;
                eventWriter.WaitOne();
                using (StreamReader sr = new StreamReader(FileNameRead))
                {
                    line = sr.ReadLine();
                    str = _OnCheck?.Invoke(this, line);
                    

                }
                //using (StreamWriter writer = new StreamWriter(FileNameWrite))
                //{
                // writer.WriteLine(str);                
                    var writer = new System.Xml.Serialization.XmlSerializer(typeof(List<string>));
                    using (var wfile = new StreamWriter(FileNameWrite))
                    {
                        writer.Serialize(wfile, str);
                    }

                //}
                eventRW.Set();
                eventReader.Set();

            }
        }
    }
}
