using System;

namespace ConsoleApp3
{
	class Program
    {
		static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\sws58\Desktop\EulerProjejct\11.txt");

            int[,] grid= new int[20, 20];
            int i = 0;
            int lineIndex = 0;

            foreach (string line in lines)
            { 
                for(int j=0;j<20;j++)
                {
                    grid[i, j] = ((int)line[lineIndex] - '0') * 10 + (int)line[lineIndex+1] - '0';
                    lineIndex += 3;
                }
                i++;
                lineIndex = 0;
                Console.WriteLine();
            }

            for (int k = 0; k < 20; k++)
            {
                for (int l = 0; l < 20; l++)
                    Console.Write("{0} ",grid[k, l]);
                Console.WriteLine();
            }
            int tempSum = 0;
            int maxSum = 0;
            for (int k = 0; k < 20; k++)
            {
                for (int l = 0; l < 20; l++)
                {
                    if (l <= 16) //right only
                    {
                        tempSum = (grid[k, l]) * (grid[k, l + 1]) * (grid[k, l + 2]) * (grid[k, l + 3]);
                        maxSum = tempSum > maxSum ? tempSum : maxSum;
                    }
                    if (k >= 3) 
                    {
                        tempSum = (grid[k, l]) * (grid[k-1, l]) * (grid[k-2, l]) * (grid[k-3, l]);//up only
                        maxSum = tempSum > maxSum ? tempSum : maxSum;
                        if (l <= 16) //up-right only
                        {
                            tempSum = (grid[k, l]) * (grid[k - 1, l + 1]) * (grid[k - 2, l + 2]) * (grid[k - 3, l + 3]);
                            maxSum = tempSum > maxSum ? tempSum : maxSum;
                        }
                    }
                }
            }
            Console.WriteLine("The max mul is:"+maxSum);
        }
    }
}















