using System;

namespace ConsoleApp18
{
    class Program
    {
        static void Main(string[] args)
        {
            double cSquared, c;
            bool finish = false;
            for (int a = 3; a<1000&&!finish; a++) // initialzing a=3 & b=4 as the first Pythagorean thriplet (3,4,5)
            {
                for (int b = 4; (b < 1000&&!finish) ; b++)
                {
                    cSquared = Math.Pow(a, 2) + Math.Pow(b, 2);
                    c = Math.Sqrt(cSquared);
                    if (c %1==0)
                    {
                        if ((a + b + c) == 1000)
                        {
                            Console.WriteLine("found! a:{0} b:{1} c:{2}, product is:{3}", a, b, c,a*b*c);
                            finish = true;
                        }
                    }
                }
            }
        }
    }
}
            