using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Server
{

    class Operations
    {
        private string ServerName = "bot";
        private string adres;
        private string f;
        public string Check(string str)
        {

            string[] arr = str.Split(' ');
            if (arr.Length > 4 || arr.Length < 3)
            {
                return "Your input is wrong";
            }
            if (arr[0] == ServerName && (arr[1] == "createdb" || arr[1] == "add" || arr[1] == "get"))
            {


                if (arr[1] == "createdb")
                {
                    adres = @"C:\Users\User\Desktop\Baza\DB\" + arr[2] + ".txt";
                    using (FileStream fs = File.Create(adres)) 
                    f = "file created";
                }
                else if (arr[1] == "add")
                {                    
                    Message ms = new Message();
                    var b = new Message { message = arr[3] };
                    var writer = new System.Xml.Serialization.XmlSerializer(typeof(Message));
                    using (var wfile = new StreamWriter(@"C:\Users\User\Desktop\Baza\DB\" + arr[2] + ".txt"))
                    {
                        writer.Serialize(wfile, b);
                    }              
                    f = "message  added";
                }
                else if (arr[1] == "get")
                {


                    System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(Message));
                    using (StreamReader file = new StreamReader(@"C:\Users\User\Desktop\Baza\DB\" + arr[2] + ".txt"))
                    {
                        Message overview = (Message)reader.Deserialize(file);
                        f = overview.message;
                    }
                }

                return f;
            }
            else
            {
                return "Your input is wrong";
            }
        }
    }
}
