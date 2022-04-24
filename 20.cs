using System;
using System.Text;
namespace a
{
    class Program
    {
        public static void Main(string[] args)
        {
            string str = "6"; // 6 is start point i choosed which is a result of 3!, next operation will be duplicating by 4 to get to 4! and so on...
            for (int i = 4; i <= 100; i++) // On each iteration I duplicate thre current number by i, untill Ill get to *100 which is 100!
                str=UpdateString(str,i);
            Console.WriteLine("sum of digits of 100! is:" + SumDigits(str));

        }
        public static string UpdateString(string str,int num)
        {
            int multiplier;
            int tempMultification;
            string[] results = {"","0","00"};
            int indexResults = 0;
            int temp;

            while(num>0)
            {
                multiplier = num % 10;
                tempMultification = 0;
                for (int i=0;i<str.Length;i++) 
                { 
                    temp= tempMultification + multiplier * (str[i] - '0');
                    tempMultification = 0; 
                    results[indexResults] += (char)((temp % 10)+'0');  
                    temp /= 10;
                    tempMultification += temp;
                }
                if(tempMultification>0) results[indexResults] +=  (char)(tempMultification + '0');
                indexResults++;
                num /= 10;
            }

            string resString = AddStrings(results[0], results[1]);

            if (results[2]!="00") // will happend only once, while duplicating the number by 100
                 resString = AddStrings(resString, results[2]);
            return resString;

        }
        public static string AddStrings(string a,string b)
        {
            int sum = 0, carry=0;
            string result="";
            int i;
            for (i = 0; i < a.Length && i < b.Length; i++)
            {
                sum = (a[i] - '0') + (b[i] - '0')+carry;
                result += (char)((sum % 10)+'0');
                carry=sum / 10;

            }
            if(i < a.Length || i < b.Length)
            {
                if(a.Length>b.Length)
                    for (; i < a.Length; i++)
                    {
                        sum = (a[i] - '0')+carry;
                      
                            result += (char)((sum % 10) + '0');
                        carry = sum / 10;

                    }
                else
                    for (; i < b.Length; i++)
                    {
                        sum = (b[i] - '0') + carry;
                        result += (char)((sum % 10) + '0');
                        carry = sum / 10;

                    }
            }
            if (carry > 0) result += (char)(carry+'0');
            return result;
        }
        public static int SumDigits(string str)
        {
            int sum = 0;
            for (int i = 0; i < str.Length; i++)
                sum += str[i] - '0';
            return sum;
        }
    }
}