using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int TriangleNum =6;
            int dynamicFactor=3;
            int cntFactors = 0;

            while(cntFactors<=500)
            {
                dynamicFactor++;
                TriangleNum += dynamicFactor;
                Console.Write("num is:" + TriangleNum + " ");
                cntFactors = CntFactors(TriangleNum);
            }
            Console.WriteLine("The first triangle number with over 500 factors is:"+TriangleNum);
        }
        public static int CntFactors(int num)
        {
            int sqrt = (int)Math.Sqrt(num);
            int cntFactors = 2;//the 2 is 1 and the number itself
            while (sqrt>1)
            {
                if (num % sqrt == 0) cntFactors+=2;
                sqrt -= 1;
            }    

            Console.WriteLine("cnt factors is:"+cntFactors);
            return cntFactors; 
        }
    }
}
