using System;

namespace ConsoleApp14
{
    class Program
    {
        public static void Main(string[] args)
        {
            /* check one number for example
            int startingNum = 910107;
            Console.Write(startingNum+ " ");
            int tempCnt = 1;
            while (startingNum != 1)
            {
                if (startingNum % 2 == 0)
                    startingNum /= 2;
                else startingNum = startingNum * 3 + 1;
                Console.Write(startingNum+" ");
                tempCnt++;
            }
            Console.WriteLine("temp cnt is:{0}---------------------",tempCnt);
            */
            long longestWay = 1;
            long numProducesLongest=1;
            long temp;
            for(long i=999999;i>=1;i--)
            {
                temp = CountTerms(i);
                if (temp > longestWay)
                {
                    longestWay = temp;
                    numProducesLongest = i;
                }
            }
            Console.WriteLine("Num produces the longest way is:{0} with {1} terms",+numProducesLongest,longestWay);
        }
        public static int CountTerms(long num)
        {
            int cnt = 1; //we start with 2 to include the num itself and also 1
            while(num>1)
            {
                if (num % 2 == 0) num /= 2;
                else num = num * 3 + 1;
                cnt++;
            }
            return cnt;
        }
    }
}