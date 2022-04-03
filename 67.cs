using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sums = new int[99];
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\sws58\Desktop\EulerProjejct\67.txt");
            for (int row = lines.Length - 1; row > 0; row--)
            {
                if (row == lines.Length - 1) //first iteration only!
                    for (int col = 0; col <= (row * 3 - 3); col += 3)
                    {
                        Console.WriteLine("col is:" + col);
                        sums[col / 3] = Max(CharsToNum(lines[row][col], lines[row][col + 1]), CharsToNum(lines[row][col + 3], lines[row][col + 4]));
                    }
                else // all other iterations
                {
                    for (int col = 0; col <= (row * 3 - 3); col += 3)
                    {
                        Console.WriteLine("col is:" + col);
                        sums[col / 3] = Max(CharsToNum(lines[row][col], lines[row][col + 1]) + (sums[col / 3]), CharsToNum(lines[row][col + 3], lines[row][col + 4]) + (sums[col / 3 + 1]));
                    }
                }
            }
            int result = (lines[0][0] - '0') * 10 + (lines[0][1] - '0') + sums[0];
            Console.WriteLine("resultr is:" + result);



        }
        public static int CharsToNum(char tens, char units) => (tens - '0') * 10 + (units - '0');
        public static int Max(int a, int b) => a > b ? a : b;

    }


}