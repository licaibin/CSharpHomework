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
            int n1 = 0;
            int n2 = 0;
            string s = "";
            Console.WriteLine("Please input the first number :");
            s = Console.ReadLine();
            n1 = int.Parse(s);
            Console.WriteLine("Please input second numbers :");
            s = Console.ReadLine();
            n2 = int.Parse(s);
            Console.WriteLine("The result of multiplying the two is :" + (n1 * n2));          
        }
    }
}
