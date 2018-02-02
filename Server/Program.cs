using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Server
{
    class Program
    {


        static void Main(string[] args)
        {
            ReadWrite c = new ReadWrite(@"C:\Users\User\Desktop\Baza\Message.txt", @"C:\Users\User\Desktop\Baza\Message1.txt");
            c.On();
        }
    }
}
