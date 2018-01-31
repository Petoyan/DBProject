using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {        
        WriteRead c = new WriteRead(@"C:\Users\User\Desktop\Baza\Message.txt", @"C:\Users\User\Desktop\Baza\Message1.txt");
        c.On();
            
        }
    }
}
