using System;

namespace a
{
    class Program
    {
        public static void Main(string[] args)
        {
            int maxN = 0;
            int productCoefficients=0;
            int n = 0;

            for (int a = -999; a < 1000; a++)
            {
                for (int b = -1000; b<= 1000; b++)
                {
                    n = 0;
                    while (true)
                    {
                        if (!CheckPrime((int)(Math.Pow(n, 2) + a * n + b)))
                        {
                            if (n > maxN)
                            {
                                maxN = n;
                                productCoefficients = a * b;
                            }
                            break;
                        }
                        n++;
                    }
                }
            }
            Console.WriteLine("The product of Coefficients is:{0}",productCoefficients);
        }

        public static bool CheckPrime(int num)
        {
            if (num <= 1) return false;
            // assume at start that all numbers are prime.
            int sqrt = (int)Math.Sqrt(num);
            for (int i = 2; i <= sqrt; i++)
                if (num % i == 0) return false;
            return true;
        }
    }
}