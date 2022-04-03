using System;

namespace EulerProject
{
    class Problem3
    {
        static void Main(string[] args)
        {
            int sum = 0, n1 = 1, n2 = 2, temp;

            while (n2 <= 4000000)
            {
                if (n2 % 2 == 0) sum += n2;

                temp = n2;
                n2 += n1;
                n1 = temp;
            }

            Console.WriteLine("result is:{0}, last num is:{1}", sum);
        }
    }
}
