using System;

namespace ConsoleApp22
{
    class Program
    {
        static void Main(string[] args)
        {
            //start 1jan 1901 to 31dec2000
            int currentYear = 1901; 
            int countSundays=-0;

            int[] months = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int regYear = 365; //regular year has 365 days
            int daysInCentury=0; // number of days in the specific 20th century.
            

            //Caluculating how many days pass from  Jan 1901 (include) to 31Dec 2000 (include)
            while(currentYear<=2000) 
            {
                Console.WriteLine("current year:{0}",currentYear);
                daysInCentury += 365+CheckLeap(currentYear); // If year is leap, add +1 to 365.
                currentYear++;
            }
            Console.WriteLine("Days in century:{0}",daysInCentury);

            int[] allDays = new int[daysInCentury+1];//+end day
            int index = 0; // index to "allDays" array

            //lets put 1 in any day in the array that is first of any month, for example:
            allDays[0] = 1; // first day is array is first day of Jan 1901, should get sign of 1
            currentYear = 1901;
            while (currentYear<=2000)//(index<daysInCentury)
            {
                Console.WriteLine(">>>>>Year is:{0}",currentYear);
                int leap = CheckLeap(currentYear);
                for (int i = 0; i < 12; i++)
                {
                    
                    index += months[i];
                    if (i == 1) index += leap; // if this februar and year is leap, leap will be 1, else - 0

                     allDays[index] = 1;
                }
                currentYear++;
            }
            index = 5; //index is 5th because points to 6th Jan which is first sunday in 1901
            while(index<= daysInCentury-1)
            {
                if (allDays[index] == 1) countSundays++;
                index += 7;
            }
            Console.WriteLine("final result is:{0}",countSundays);
           


        }
        static int CheckLeap(int year)  
        {
            int leap = 0; //default value - year is not leap
            if (year%4==0) // there are chance to be leap year
            {
                leap = 1;
                if(year%100==0)
                {
                    leap = 0;
                    if (year % 400 == 0) leap = 1;
                }
            }
            return leap;
        }
        
    }
}
