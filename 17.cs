using System;

namespace a
{
    class Program
    {
        static void Main(string[] args)
        {
            int twentyToNinetynine=0;
            int oneToNinetynine;
            int finalResult = 0;
            int oneThousand = 11;
            int hundred = 7;

            const int oneToNine = 36; //one 3, two 3, three 5, four 4, five 4, six 3, seven 5, eight 5, nine 4
            const int ten = 3; // ten= 3
            const int teen = 67; //  eleven 6, twelve 6, thirteen 8, fourteen 8, fifteen 7, sixteen 7, seventeen 9, eighteen 8, nineteen 8
            //const int tens = 46; //twenty 6, thirty 6, forty 5, fifty 5, sixty 5, seventy 7, eighty 6, ninety 6
            int[] tens = { 6, 6, 5, 5, 5, 7, 6, 6 };

            const int oneToNineteen = (oneToNine + ten + teen);

            for (int i = 0; i < tens.Length; i++)        
                twentyToNinetynine += (tens[i] * 10 + oneToNine);

            oneToNinetynine = oneToNineteen + twentyToNinetynine;
            finalResult += oneToNinetynine*10+oneThousand + oneToNine*100 +hundred*900 + 3*891; // and=3 duplicates by 900 timed, but in 9 times (hundred, two hundred, three hundred...) no need and
            Console.WriteLine("final result is:{0}",finalResult);
            
            // 1-9 + 10  + teen 

        }


    }
}