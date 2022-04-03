using System;
using System.Text;
namespace a
{
    class Program
    {
        public static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder("61");

            for (int exponent = 5; exponent <= 1000; exponent++)
                UpdateString(sb);

            Console.WriteLine("sum of digits of 2^1000 is:"+SumDigits(sb));
        }
        public static void UpdateString(StringBuilder sb)
        {
            int num, carry = 0;
            for (int i = 0; i < sb.Length; i++)
            {
                num = (sb[i] - '0') * 2;
                num += carry;
                carry = 0;
                if (num < 10) sb[i] = (char)(num + '0');
                else
                {
                    carry = num / 10;
                    sb[i] = (char)((num % 10) + '0');
                }

            }
            if (carry > 0) sb.Append((char)(carry + '0'));
        }
        public static int SumDigits(StringBuilder sb)
        {
            int sum = 0;
            for(int i=0;i<sb.Length;i++)
                sum += sb[i] - '0';
            return sum;
        }
    }
}