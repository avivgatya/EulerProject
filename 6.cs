using System;

namespace ConsoleApp12
{
    class Problem6
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Result is:{0}", SquareOfTheSum(100) - SumOfTheSquares(100));
        }

        static long SumOfTheSquares(int num)
        {
            long sum=0;
            for (long i = 1; i <= 100; i++)
            {
                sum+=(long)Math.Pow(i, 2);
            }
            return sum;
        }

        static long SquareOfTheSum(int num)
        {
            long sum = 0;
            for (long i = 1; i <= 100; i++)
            {
                sum += i;
            }
            return (long)Math.Pow(sum, 2);
           
        }
    }
}
