using System;

namespace EulerProject
{
    class Problem1
    {
        static void Main(string[] args)
        {
            int sum = 0;
            for(int i=3;i<1000;i++)
            {
                if (i % 3 == 0 || i % 5 == 0) sum += i;
            }
            Console.WriteLine("result is:{0}",sum);
        }
    }
}
