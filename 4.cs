using System;

namespace EulerProject
{
    class Problem4
    {
        static void Main(string[] args)
        {
            int maxA = 100, maxB = 100, maxPalindrom = 10001; 
            for(int i=100;i<=999;i++)
                for(int j=100;j<=999;j++)
                {
                    if(i*j>maxPalindrom)
                    {
                        if (CheckPalindrom(i * j) == true)
                        {
                            maxPalindrom = i * j;
                            maxA = i;
                            maxB = j;
                        }
                    }
                }
            Console.WriteLine("Max A is:{0}, Max B is:{1} and product is:{2}",maxA,maxB,maxPalindrom);
        }
        static bool CheckPalindrom(int num)
        {
            int copy = num, reverse=0;
            while(num>0)
            {
                reverse *= 10;
                reverse += num % 10;
                num /= 10;
            }
            return copy == reverse;
        }
    }
}
