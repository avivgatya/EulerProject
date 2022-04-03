using System;

namespace EulerProject
{
    class Problem5
    {
        static void Main(string[] args)
        {
            long smallest = 1; //comp is a number in a potential to be the "smallest number can be divided by each 1-20 without remainder.
            int i;
            for (i=2;i<=20;i++)
            {
                smallest = SmallestNumDiv(smallest, i);
                Console.WriteLine("smallest is:{0}",smallest);
            }
            Console.WriteLine("result is:{0}",smallest);
        }

        static long SmallestNumDiv(long num1,int num2)
        {
            long num1Copy = num1;
            while(true) //this loop is NOT infinity, every 2 numbers have number that both divisor of.
            {
                Console.WriteLine(">>>num1 is:{0}",num1);
                
                if (num1 % num2 == 0) return num1;
                num1 += num1Copy;
                //else continue;
            }
        }
    }
}
