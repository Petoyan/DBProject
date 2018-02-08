using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Commons;


namespace Server
{
    class Program
    {


        static void Main(string[] args)
        {            
            WriteRead c = new WriteRead(@"C:\Users\User\Desktop\Baza\Message1.txt", @"C:\Users\User\Desktop\Baza\Message.txt");
            Operations op = new Operations(c);
            while (true)
            {
                c.ReadWrite();
            }
           
        }
    }
}
