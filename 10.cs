using System;

namespace ConsoleApp19
{
    class Program
    {
        
        static void Main(string[] args)
        {
            long sum = 17; //17 is the sum of all prime numbers under 10
            int digit;
            for (int i = 11; i < 2000000; i++)
            {
                digit = i % 10;
                if ((digit == 1) || (digit == 3) || (digit == 7) || (digit == 9))
                {
                    if (CheckPrime(i) == true)
                        sum += i;
                }
            }
            Console.WriteLine("sum of all primes below 2million is:{0}",sum);
        }
        static bool CheckPrime(int num)
        {
            int square = (int)Math.Sqrt(num);
            for(int i=2;i<=square;i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }
    }
}

