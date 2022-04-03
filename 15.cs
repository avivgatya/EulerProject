using System;

namespace ConsoleApp21
{
    class Program
    {   
        //solution number 1 - each cell hold number of routes from his point of view
        static void Main(string[] args)
        {
            int sizeOfTable = 20;
            sizeOfTable++;
            long[,] table = new long[sizeOfTable, sizeOfTable];

            for (int i = 0; i < sizeOfTable - 1; i++) // i for rows
            {
                table[sizeOfTable - 1, i] = 1; // all 
                table[i, sizeOfTable - 1] = 1; // all 
            }
            int r = sizeOfTable - 2, c = sizeOfTable - 2;
            int loops = r;

            while (loops > 0)
            {

                table[r, c] = table[r, c + 1] + table[r + 1, c];
                for (int i = 1; i <= r; i++)
                {
                    table[r - i, c] = table[r - i, c + 1] + table[r - i + 1, c];//UP
                    table[r, c - i] = table[r, c - i + 1] + table[r + 1, c - i];//LEFT
                }
                loops--;
                r--;
                c--;
            }
            table[r, c] = table[r, c + 1] + table[r + 1, c];
            /* //Print the table if required, to understand only
            for (int i = 0; i < sizeOfTable; i++)
            {
                for (int j = 0; j < sizeOfTable; j++)
                {
                    Console.Write(table[i, j] + "           ");
                }
                Console.WriteLine();
            }*/
            Console.WriteLine("Final result is:{0}",table[0,0]);
        }
        

        /* Soultion number 2 - recursion -every cell call the function for his right and down cells.
         * not effective for size 20x20,(long runtime) but works fine for smaller sizes(15x15 and down)
        static void Main(string[] args)
        {
            int sizeOfTable = 6;
            sizeOfTable++;
            int[,] table = new int[sizeOfTable,sizeOfTable];
            Console.WriteLine("result is:{0}",Func(0,0,sizeOfTable));
        }

        static int Func(int rows,int cols,int sizeOfTable)
        {
            if(rows==sizeOfTable-1||cols==sizeOfTable-1) return 1; //return 1 means 1 way from this  (no split)
            else
                return (Func(rows+1,cols,sizeOfTable)+Func(rows,cols+1,sizeOfTable));
        }
        
        */







    }
}
