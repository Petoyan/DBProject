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
        public Operations(Commit commitServer)
        {
            commitServer.OnCheck += Check;
        }
        XMLDriver xmlDriver = new XMLDriver();
        private string ServerName = "bot";
        private string adres = @"C:\Users\User\Desktop\Baza\DB\";
        private List<string> mes;
        public List<string> Check(object sender, string str)
        {
            string[] arr = str.Split(' ');
            if (arr.Length > 4)
            {
                for (int i = 4; i < arr.Length; i++)
                {
                    arr[3] += " ";
                    arr[3] += arr[i];
                }
            }
            if (arr.Length < 3)
            {
                mes = new List<string>();
                mes.Add("Your input is wrong");
            }

            else if (arr[0] == ServerName && (arr[1] == "createdb" || arr[1] == "add" || arr[1] == "get"))
            {
                if (arr[1] == "createdb")
                {
                    xmlDriver.Create(adres + arr[2] + ".xml");
                    mes = new List<string>();
                    mes.Add("file created");
                }
                else if (arr[1] == "add")
                {
                    xmlDriver.Add(adres + arr[2] + ".xml", arr[3]);
                    mes = new List<string>();
                    mes.Add("message  added");
                }
                else if (arr[1] == "get")
                {
                    mes = xmlDriver.Get(adres + arr[2] + ".xml");                   
                }
            }
            else
            {
                mes = new List<string>();
                mes.Add("Your input is wrong");
            }
            return mes;
        }
    }
}
