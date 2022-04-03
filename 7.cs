using System;

namespace ConsoleApp12
{
    class Problem7
    {
        static void Main(string[] args)
        {
            int cnt = 2, num = 3; //num2 is the first prime number so cnt=1 in the first iteration (of num 2)
            while (cnt < 10001)//(cnt <= 10001)
            {
                num++;
                if (CheckPrime(num) == true)cnt++
            }
            Console.WriteLine("The 10001st Prime number is:{0}", num);
        }
        static bool CheckPrime(int num)
        {
            for (int i = 2; i < num; i++)
            if (num % i == 0) return false;
            return true;
        }
    }
}
