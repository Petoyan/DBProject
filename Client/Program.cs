using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Commons;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {

            ICommit commitClient = new Commit(@"C:\Users\User\Desktop\Baza\Message.txt", @"C:\Users\User\Desktop\Baza\Message1.txt");
            while (true)
            {
                foreach (var item in commitClient.CommitClient())
                {
                    Console.WriteLine(item);
                } 
            }
           
        }
    }
}
