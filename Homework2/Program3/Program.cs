using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program3
{
    class Program
    {
        static void Main(string[] args)
        {



            int[] A = new int[99];                  //创建数组
            for (int i = 2 ; i < 101 ; i++)
            {
                A[i - 2] = i;
            }
            int[] B = new int[99];
            int b=0;


            for (int i = 2; i < 101; i++)             //将非素数变为0
            {
                for (int k = 0; k < 99; k++)
                    if (A[k] % i == 0&&A[k]>i)
                {
                        A[k] = 0 ;
                }
            }


            for (int i = 0; i < 99; i++)            //输出
            {
                if (A[i] != 0)
                {
                    Console.WriteLine(A[i]+"   ");
                }
            }


        }
    }
}
