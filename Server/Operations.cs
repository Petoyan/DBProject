using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Commons;

namespace Server
{

    class Operations
    {
        public Operations(WriteRead writeRead)
        {
            writeRead.OnCheck += Check;
        }
        private string ServerName = "bot";
        private string adres= @"C:\Users\User\Desktop\Baza\DB\";
        private List<string> mes;
        public List<string> Check(object sender, string str)
        {

            string[] arr = str.Split(' ');
            if (arr.Length > 4 || arr.Length < 3)
            {
                mes = new List<string>();
                mes.Add("Your input is wrong") ;
            }
            else if (arr[0] == ServerName && (arr[1] == "createdb" || arr[1] == "add" || arr[1] == "get"))
            {


                if (arr[1] == "createdb")
                {
                    using (FileStream fs = File.Create(adres + arr[2] + ".txt"))
                        mes = new List<string>();
                    mes.Add("file created");
                }
                else if (arr[1] == "add")
                {
                    var message = new Message<string>();
                    try
                    {
                        System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(Message<string>));
                        using (StreamReader file = new StreamReader(adres + arr[2] + ".txt"))
                        {
                            Message<string> overview = (Message<string>)reader.Deserialize(file);
                            message = overview;
                            message.list.Add(arr[3]);
                        }
                    }
                    catch (Exception)
                    {
                        message.list.Add(arr[3]);
                    }

                    var writer = new System.Xml.Serialization.XmlSerializer(typeof(Message<string>));
                    using (var wfile = new StreamWriter(adres + arr[2] + ".txt"))
                    {
                        writer.Serialize(wfile, message);                       
                    }
                    mes = new List<string>();
                    mes.Add("message  added");
                }
                else if (arr[1] == "get")
                {
                    try
                    {
                        System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(Message<string>));
                        using (StreamReader file = new StreamReader(adres + arr[2] + ".txt"))
                        {
                            Message<string> overview = (Message<string>)reader.Deserialize(file);
                            mes = new List<string>();
                            mes =overview.list;

                        }
                    }
                    catch (FileNotFoundException)
                    {
                        mes = new List<string>();
                        mes.Add("FileNotFoundException...........Place create file");
                    }
                    
                }
            }
            else
            {
                mes = new List<string>();
                mes.Add("Your input is wrong");
            }
            return mes ;
        }
    }
}
