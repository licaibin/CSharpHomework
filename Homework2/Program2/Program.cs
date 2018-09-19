using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class Program
    {
        static void Main(string[] args)
        {



            Console.Write("Please input the array length.");    //得到数组
            string s = Console.ReadLine();
            int n;
            n = int.Parse(s);
            int[] A = new int[n];
            Console.Write("Please input All numbers.");
            for (int i = 0; i < n; i++)
            {
                A[i] = int.Parse(Console.ReadLine());
            }



            int max = A[0];                                     //求四个值
            int min = A[0];
            int average = 0;
            int sum = 0;
            for (int j = 0; j < n; j++)
            {
                if(A[j] > max)                               
                    max = A[j];
                if (A[j] < min)
                    min = A[j];
                sum += A[j];
            }
            average = sum / n;


            Console.Write("max:" +max);
            Console.Write("   min:" + min);
            Console.Write("   average:" + average);
            Console.Write("   sum:" + sum);

            
        }
    }
}
