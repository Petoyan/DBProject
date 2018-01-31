using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{

    class Operations
    {
        private string ServerName="Robot";        
        
        public string Check(string str)
        {
           
            string[] arr = str.Split(' ');
            if (arr.Length > 3 || arr.Length < 3)
            {
                return "Your input is wrong";
            }
            if (arr[0] == ServerName && ( arr[1] == "Add" || arr[1]=="Remove"))
            {
                int num1, num2, sum;
                string[] arr1 = arr[2].Split(',');
                num1 = Convert.ToInt32(arr1[0]);
                num2 = Convert.ToInt32(arr1[1]);
                if (arr[1] == "Add")
                {
                    sum =num1+num2;
                }
                 else
                {
                    sum = num1 - num2;
                }
                return sum.ToString();
            }
            else
            {
                return "Your input is wrong";
            }
        }
        

    }
}
