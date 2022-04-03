using System;

namespace EulerProject
{
    class Problem3
    {
        static void Main(string[] args)
        {
            long num = 600851475143, biggestPrimeFactor; //I choosed to use long becuase I dont know yet if int is enough

            biggestPrimeFactor = Func(num);
           
            Console.WriteLine("Biggest prime factor of 600851475143 is:{0}", biggestPrimeFactor);

        }


        static long Func(long num) //this function get number(long) and check if it's prime.
        {
            long dividerA=1,dividerB=1;
            if (CheckPrime(num) == true)
            {
                return num;
            }
            else //Divdie the number to 2 parts (dividers)
            {
                Console.WriteLine("check1");
                for (int i=2;i<num;i++)
                {
                    if(num%i==0)
                    {
                        dividerA = i;
                        dividerB = num / dividerA;
                        break;
                    }
                }
                return MAX(Func(dividerA),Func(dividerB));
            }
        }

        static long MAX(long num1,long num2)
        {
            if (num1 > num2) return num1;
            else return num2;
        }

        static bool CheckPrime(long num)
        {
            for(int i=2;i<num;i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }

    }
}
