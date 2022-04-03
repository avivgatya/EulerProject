using System;

namespace ConsoleApp15
{
    class Program // problem85
    {
        // In this excersice "recs" means all the rectangles that can get in one big rectangle
        static void Main(string[] args)
        {
            int areaMax = 0, recsMax = 0, areaTemp=0, recsTemp=0;
            int width = 2, height = 1;
            while (true) //loop will stop by break;
            {
                CheckNumberOfColored(width, height, ref areaTemp, ref recsTemp);
                ClosestAreaToTarget(areaTemp, recsTemp, ref areaMax, ref recsMax);
                if (recsTemp > 2000000)
                {
                    if (width == height) break;
                    width = 1;
                    height++;
                }
                width++;
            }

           Console.WriteLine("area is:{0}, recs is:{1}", areaMax, recsMax);
        }
        static void CheckNumberOfColored(int width,int height,ref int area,ref int numOfRecs) //Calculate number of recs and area of specific rectangle
        {
            numOfRecs = 0;
            area = width * height;
            for(int i=1;i<=height;i++)
                for(int j=1;j<=width;j++)
                    numOfRecs += (width - j+1) * (height - i + 1);
        }
        static void ClosestAreaToTarget(int areaA,int recsA,ref int areaB,ref int recsB) 
        {   
            int tempRecsA = 2000000 - recsA;
            int tempRecsB = 2000000 - recsB;
            if (tempRecsA < 0) tempRecsA = tempRecsA * -1;
            if (tempRecsB < 0) tempRecsB = tempRecsB * -1;
            if (tempRecsA < tempRecsB)
            {
                areaB = areaA;
                recsB = recsA;
            }
        }
    }
}
