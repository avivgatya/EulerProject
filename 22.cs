using System;

namespace AA
{
    class Program
    {
        public static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\sws58\Desktop\TEMPEulerProject\22.txt");
            int numOfWords = CountCommas(text);
            string[] words = new string[numOfWords];
            PutWordsInArray(words, text); // passing all names from text to array without quation marks and commas, each word in seperated cell
            AlphaBetSort(words); // AlphaBet sorting...
                                 //Console.WriteLine("Final result after sorting:");
                                 // PrintAllWords(words);
            Console.WriteLine("Final result:"+ CalculatingNameScores(words));

            Console.WriteLine("End of program!");
        }
        public static int CountCommas(string text)
        {
            int cnt = 0;
            for (int i = 0; i < text.Length; i++)
                if (text[i] == ',') cnt++;
            return cnt + 1; // there is comma between 2 words, so after last word there is no comma, so I add 1 to count also last word.
        }
        public static void PutWordsInArray(string[] wordsArray, string text)
        {
            int indexText = 1;// loops starts with 1 to skip the first quation mark(") which is in index 0
            for (int i = 0; i < wordsArray.Length; i++)
            {
                wordsArray[i] = ""; // initialize blank string
                while (indexText < text.Length && text[indexText] != '"')
                {
                    wordsArray[i] += text[indexText];
                    indexText++;
                }
                indexText += 3; // to skip (",") after this, index is on first lettet of first word.
            }
        }

        public static void AlphaBetSort(string[] words)
        {
            string temp;
            bool changes = false;
        scanWords:
            for (int i = 0; i < words.Length; i++)
            {
                changes = false;
                for (int j = i+1; j < words.Length; j++)
                    if (SwitchWords(words[i], words[j]))
                    {
                        temp = words[i];
                        words[i] = words[j];
                        words[j] = temp;
                        changes = true;
                    }
            }
            if (changes)
            {
                Console.WriteLine("Check");
                goto scanWords;
            }


        }
        public static bool SwitchWords(string a, string b)
        {
            int i;
            for (i = 0; i < a.Length && i < b.Length; i++)
            {
                if (a[i] - '0' > b[i] - '0') return true; // in case a bigger than b, need to switch
                else if (a[i] - '0' < b[i] - '0') return false;
            }
            // I assume no same words in the list, so if we get here, it means 1 word longest than other, no other option.
            if (i == a.Length) return false;// means a shorter, means no need to switch
            if (i == b.Length) return true; // means b shorter and we need to switch.
            return true;
        }
        public static void PrintAllWords(string[] words)
        {
            foreach (string word in words)
                Console.WriteLine(word+", ");
        }
        public static int CalculatingNameScores(string[] words)
        {
            int Score = 0, tempSum = 0;
            
            for(int i=0; i < words.Length; i++)
            {
                tempSum = 0;
                for (int j = 0; j < words[i].Length; j++)
                {
                    tempSum += words[i][j]-'A'+1;
                }
                Score += tempSum*(i+1);
            }
            return Score; 
        }
    }
}