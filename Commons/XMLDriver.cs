using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Commons
{
    public class XMLDriver
    {
        public void Create(string adres)
        {
            using (FileStream fs = File.Create(adres)) { }
        }
        public void Add(string adres, string sms)
        {
            var message = new Message<string>();

            try
            {
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(Message<string>));
                using (StreamReader file = new StreamReader(adres))
                {
                    Message<string> overview = (Message<string>)reader.Deserialize(file);
                    message = overview;
                    message.list.Add(sms);
                }
            }
            catch (Exception)
            {
                message.list.Add(sms);
            }

            var writer = new System.Xml.Serialization.XmlSerializer(typeof(Message<string>));
            using (var wfile = new StreamWriter(adres))
            {
                writer.Serialize(wfile, message);
            }
        }
        public List<string> Get(string adres)
        {
            List<string> mes;
            try
            {
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(Message<string>));
                using (StreamReader file = new StreamReader(adres))
                {
                    Message<string> overview = (Message<string>)reader.Deserialize(file);

                    mes = overview.list;
                }
            }
            catch (FileNotFoundException)
            {
                mes = new List<string>();
                mes.Add("FileNotFoundException...........Place create file");
            }
            return mes;
        }
    }
}
