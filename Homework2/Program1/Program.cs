using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {


            int n = 0;                                             //得到一个数 
            Console.WriteLine("Please input a number :");
            string s = Console.ReadLine();
            n = int.Parse(s);


            for(int i = 2; i<=n; i++)                                //求素数因子
            {
                if (n % i == 0)
                {
                    Console.Write(i + "  ");
                    n /= i;
                    i--;
                }               
            }

        }
    }
}
