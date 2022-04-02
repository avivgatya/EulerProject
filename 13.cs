using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\sws58\Desktop\EulerProjejct\13.txt");
            //foreach(string line in lines)
              //  Console.WriteLine(line);
            int tempSum;
            long sum = 0;
            //Summing first digit of all the numbers:
            for (int dig = 0; dig < 50; dig++)
            {
                tempSum = 0;
                for (int row = 0; row < lines.Length; row++)
                {
                    tempSum += (int)(lines[row])[dig] - '0';
                    if (dig == 0) Console.WriteLine("temp sum is:"+tempSum);
                }
                sum *= 10;
                sum += tempSum;
                if (sum > 999999999999) //in the result take only first 10 digits
                {
                    Console.WriteLine("BREAK");
                    break;
                }
            }

            Console.WriteLine(sum); //result is: 5537376230
        }
    }
}
