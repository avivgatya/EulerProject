using System;
namespace Aa
{
    class Program
    {
        static public void Main(string[] args)
        {
            int sumAmicables = 0;
            for (int i = 1; i <= 10000; i++)
            {
                if (CheckAmicable(i)) sumAmicables += i;
            }
            Console.WriteLine("result:"+sumAmicables);
        }
        public static bool CheckAmicable(int num)
        {
            int sumDivisors1 = 1;
            int sumDivisors2 = 1;
            int sqrt = (int)Math.Sqrt(num); 
            for(int i=2; i<=sqrt;i++)z
            {
                if (num % i == 0)
                {
                    sumDivisors1 += i;
                    sumDivisors1 += num/i;
                }
            }
            if (num == sumDivisors1) return false;
            int sqrt2 = (int)Math.Sqrt(sumDivisors1);
            for (int i = 2; i <= sqrt2; i++)
            {
                if (sumDivisors1 % i == 0)
                {
                    sumDivisors2 += i;
                    sumDivisors2 += sumDivisors1 / i;
                }
            }
            if (sumDivisors2 == num) return true;
            else return false;
        }
    }
}