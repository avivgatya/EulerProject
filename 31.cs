using System;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
            Console.WriteLine("Check!");
			int[] options = { 1, 2, 5, 10, 20, 50, 100, 200 };
			int sumOfCoins = 0;
			int cntOfOptions = 0;
		for(int c1=0;c1<=200;c1++)
		for(int c2=0;c2<=100;c2++)
		for(int c3=0;c3<=40;c3++)
		for(int c4=0;c4<=20;c4++)
		for(int c5=0;c5<=10;c5++)
		for(int c6=0;c6<=4;c6++)
		for(int c7=0;c7<=2;c7++)
		for(int c8=0;c8<=1;c8++)
            {
			sumOfCoins= c1* options[0]+c2 * options[1] + c3 * options[2] + c4 * options[3] + c5 * options[4] + c6 * options[5] + c7 * options[6] + c8 * options[7];
			if (sumOfCoins == 200)
					cntOfOptions++;
            }
            Console.WriteLine("there are:{0} options!",cntOfOptions);
			//73682
		}
	}
}