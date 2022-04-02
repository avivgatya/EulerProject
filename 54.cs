using System;

namespace ConsoleApp1
{
	enum Rank
	{
		HighestCard,
		OnePair,
		TwoPairs,
		ThreeOfAKind,
		Straight,
		Flush,
		FullHouse,
		FourOfAKind,
		StraightFlush,
		RoyalFlush
	}

	class Program
	{
		static void Main(string[] args)
		{
			int cnt = 1;
			string[] lines = System.IO.File.ReadAllLines(@"C:\Users\sws58\Desktop\EulerProjejct\54.txt");
			int player1HandsWin = 0;
			int player2HandsWin = 0;
			foreach (string line in lines)
			{
                Console.Write("Hands number :{0,4} are: {1}   >>>",cnt,line);
				cnt++;
				string bothHands = line;//"AS AS AS AS 7S TS JS QS KS AS";
				int[] hand1 = new int[5];
				char[] hand1S = new char[5];
				int[] hand2 = new int[5];
				char[] hand2S = new char[5];

				FillData(hand1, hand1S, hand2, hand2S, bothHands);
				int duplicatesHand1 = SameCards(hand1);
				int duplicatesHand2 = SameCards(hand2);
				bool hand1SameSuit = SameSuit(hand1S);
				bool hand2SameSuit = SameSuit(hand2S);
				int hand1Consecutive = Consecutive(hand1);
				int hand2Consecutive = Consecutive(hand2);
				int winner;

				Rank rankHand1 = Rank.HighestCard;
				Rank rankHand2 = Rank.HighestCard;

				if (hand1Consecutive > 0) rankHand1 = Rank.Straight;
				if (hand2Consecutive > 0) rankHand2 = Rank.Straight;
				if (hand1SameSuit == true) rankHand1 = Rank.Flush;
				if (hand2SameSuit == true) rankHand2 = Rank.Flush;
				if (hand1Consecutive > 0 && hand1SameSuit == true)
				{
					rankHand1 = Rank.StraightFlush;
					if (hand1Consecutive == 10) rankHand1 = Rank.RoyalFlush;
				}
				if (hand2Consecutive > 0 && hand2SameSuit == true)
				{
					rankHand2 = Rank.StraightFlush;
					if (hand2Consecutive == 10) rankHand2 = Rank.RoyalFlush;
				}
				if (duplicatesHand1 > (int)rankHand1) rankHand1 = (Rank)duplicatesHand1;
				if (duplicatesHand2 > (int)rankHand2) rankHand2 = (Rank)duplicatesHand2;
				//---------------
				if (rankHand1 == rankHand2) // include the situation that both have nothing special, so we checking highest card
				{
                    Console.Write("###Equal!!! rank of hand 1 is:"+rankHand1+"###"); 
					if (rankHand1 == Rank.HighestCard) winner = CheckWinnerHighestCard(hand1, hand2);
					else //in case they both have same rank, but high than 1 rank. like pair, full house and so on...
						winner = CheckWinnerHighestCard2(hand1, hand2,rankHand1);
				}
				else
				{
					winner = (int)rankHand1 > (int)rankHand2 ? 1 : 2;
				}
				if (winner == 1) player1HandsWin++;
				if (winner == 2) player2HandsWin++;
                Console.WriteLine("Winner is player:{0}",winner);
				//Console.WriteLine("Winner is player number: {0}, which have rank:{1}", winner, winner == 1 ? rankHand1 : rankHand2);
				//Console.WriteLine("Loser is player number: {0}, which have rank:{1}", winner == 1 ? 2 : 1, winner == 2 ? rankHand1 : rankHand2);
			}
			Console.WriteLine("Player 1 won:{0} times!", player1HandsWin);
			Console.WriteLine("Player 2 won:{0} times!", player2HandsWin);
		}
		public static void FillData(int[] hand1, char[] hand1S, int[] hand2, char[] hand2S, string bothHands)
		{
			for (int i = 0; i <= 4; i++)
			{
				hand1[i] = CharToValue(bothHands[i * 3]);
				hand2[i] = CharToValue(bothHands[15 + i * 3]);
				hand1S[i] = bothHands[i * 3 + 1];
				hand2S[i] = bothHands[i * 3 + 16];
			}
		}
		public static bool SameSuit(char[] hand)
		{
			for (int i = 0; i <= 3; i++)
				if (hand[i] != hand[i + 1]) return false;
			return true;
		}
		public static int Consecutive(int[] hand)
		{
            
			int minValue = 14, maxValue = 2;
			int[] cntArray = new int[13];

			if (SameCards(hand) != 0) return 0;
			
			//until here, no same cards
			for (int i = 0; i <= 4; i++)
			{
				if (hand[i] < minValue) minValue = hand[i];
				if (hand[i] > maxValue) maxValue = hand[i];
			}
			if (maxValue - minValue == 4)
			{
				Console.WriteLine("Consective!!!!!$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
				return minValue == 10 ? 10 : 1;
			}
			else return 0;
		}
		public static int CharToValue(char c)
		{
			if (c <= '9' && c >= '0') return c - 48;
			else
			{
				switch (c)
				{
					case 'T':
						return 10;
					case 'J':
						return 11;
					case 'Q':
						return 12;
					case 'K':
						return 13;
					case 'A':
						return 14;
					default:
						Console.WriteLine("Error!");
						break;
				}
			}
			return -1; // for error case
		}
		public static int SameCards(int[] hand)
		{
			int indexOfCard;
			int[] cntArray = new int[13];
			int pair = 0, third = 0;
			for (int i = 0; i <= 4; i++) //check for same cards
			{
				indexOfCard = (hand[i] - 2);
				cntArray[indexOfCard] += 1;
			}

			for (int i = 0; i <= 12; i++)
			{
				if (cntArray[i] == 4) return 7;
				if (cntArray[i] == 2) pair++;
				if (cntArray[i] == 3) third++;
			}
			if (third == 1)
			{
				if (pair == 1) return 6;//fullhouse
				else return 3; //three of a kind
			}
			else if (pair == 2) return 2;
			else if (pair == 1) return 1;

			return 0;

		} // 0 - all different,1=pair, 2=two pairs,3=three,6-fullhouse,7-four of a kind
		public static int CheckWinnerHighestCard(int[] hand1, int[] hand2) // left win = 0, right win = 1
		{
			int cnt = 1;
			int[] copyHand1 = new int[5];
			int[] copyHand2 = new int[5];
			CopyArray(copyHand1, hand1 );
			CopyArray(copyHand2, hand2 );


			int maxHand1 = 2, maxHand2 = 2;
			for (int i = 0; i <= 4; i++)
			{
				if (copyHand1[i] > maxHand1) maxHand1 = copyHand1[i];
				if (copyHand2[i] > maxHand2) maxHand2 = copyHand2[i];
			}
			if (maxHand1 > maxHand2) return 1;
			else if (maxHand1 < maxHand2) return 2;

            Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
			//if both biggest cards are equal
			while (cnt <= 5) //infinity loop (only return stop the loop)
			{
				for (int i = 0; i <= 4; i++)
				{
					if ((copyHand1[i]) == maxHand1) copyHand1[i] = 0;
					if ((copyHand2[i]) == maxHand2) copyHand2[i] = 0;
				}
				if (maxHand1 > maxHand2) return 1;
				else if (maxHand1 < maxHand2) return 2;
				cnt++;
			}
			Console.WriteLine("If you see this, there is an Error!!! >>>in highest card function!!!");
			return -1;
			//15
		}
		public static int CheckWinnerHighestCard2(int[] hand1, int[] hand2,Rank rankHand1) // left win = 0, right win = 1
		{
            
			int[] copyHand1 = new int[5];
			int[] copyHand2 = new int[5];
			
			int h1=0, h2=0;
			if (rankHand1 == Rank.OnePair)
			{
				Console.Write("one pair...");
				for (int i = 0; i < hand1.Length; i++)
					for (int j = i + 1; j < hand1.Length; j++)
						if (hand1[i] == hand1[j]) h1 = hand1[i];

				for (int i = 0; i < hand2.Length; i++)
					for (int j = i + 1; j < hand2.Length; j++)
						if (hand2[i] == hand2[j]) h2 = hand2[i];

				if (h1 > h2) return 1;
				else if (h2 > h1) return 2;
				else return CheckWinnerHighestCard(hand1, hand2);
			}
			else if (rankHand1 == Rank.TwoPairs)
			{
				Console.Write("tow pairs...");
				int h1a = 0, h1b = 0, h2a = 0, h2b = 0;
				CopyArray(copyHand1, hand1);
				CopyArray(copyHand2, hand2);

				for (int i = 0; i < hand1.Length; i++)
					for (int j = i + 1; j < hand1.Length; j++)
						if (copyHand1[i] == copyHand1[j])
						{
							h1a = copyHand1[i];
							copyHand1[i] = -1; // just to make sure not choose it again while searching for second pair
							copyHand1[j] = -2; // -"-
						}
				for (int i = 0; i < hand1.Length; i++)
					for (int j = i + 1; j < hand1.Length; j++)
						if (copyHand1[i] == copyHand1[j])
							h1b = copyHand1[i];
				//
				for (int i = 0; i < hand2.Length; i++)
					for (int j = i + 1; j < hand2.Length; j++)
						if (copyHand2[i] == copyHand2[j])
						{
							h2a = copyHand2[i];
							copyHand2[i] = -1; // just to make sure not choose it again while searching for second pair
							copyHand2[j] = -2; // -"-
						}
				for (int i = 0; i < hand2.Length; i++)
					for (int j = i + 1; j < hand2.Length; j++)
						if (copyHand2[i] == copyHand2[j])
							h2b = copyHand2[i];

				if ((h1a > h1b ? h1a : h1b) > (h2a > h2b ? h2a : h2b)) return 1;
				else if ((h2a > h2b ? h2a : h2b) > (h1a > h1b ? h1a : h1b)) return 2;
				else return CheckWinnerHighestCard(hand1, hand2);
			}
			else if (rankHand1 == Rank.ThreeOfAKind)
			{
				Console.Write("three pairs...");
				h1 = 0;
				h2 = 0;
				for (int i = 0; i < hand1.Length; i++)
					for (int j = i + 1; j < hand1.Length; j++)
						if (hand1[i] == hand1[j]) h1 = hand1[i];

				for (int i = 0; i < hand2.Length; i++)
					for (int j = i + 1; j < hand2.Length; j++)
						if (hand2[i] == hand2[j]) h2 = hand2[i];

				if (h1 > h2) return 1;
				else if (h2 > h1) return 2;
				else return CheckWinnerHighestCard(hand1, hand2);
			}
			else if (rankHand1 == Rank.Straight)
			{
				Console.Write("straight...");
				int maxH1 = 0, maxH2 = 0;
				for (int i = 0; i < hand1.Length; i++)
					if (hand1[i] > maxH1) maxH1 = hand1[i];

				for (int i = 0; i < hand2.Length; i++)
					if (hand2[i] > maxH2) maxH2 = hand2[i];

				if (maxH1 == maxH2) Console.WriteLine("Error! two straight are equal! same hand!");
				return maxH1 > maxH2 ? 1 : 2;
			}
			else if (rankHand1 == Rank.Flush)
			{
				return CheckWinnerHighestCard(hand1, hand2);
				Console.Write("flush...");
			}
			else if (rankHand1 == Rank.FullHouse)
			{
				Console.Write("full house...");
				int h1Three = 0, h1Pair = 0;
				int h2Three = 0, h2Pair = 0;
				CopyArray(copyHand1, hand1);
				CopyArray(copyHand2, hand2);

				for (int i = 0; i < copyHand1.Length; i++)
					for (int j = i + 1; j < copyHand1.Length; j++)
						for (int k = j + 1; k < copyHand1.Length; k++)
							if (copyHand1[i] == copyHand1[j] && copyHand1[j] == copyHand1[k])
							{
								h1Three = copyHand1[i];
								copyHand1[i] = -1;
								copyHand1[j] = -2;
								copyHand1[k] = -3;
								break;
							}
				for (int i = 0; i < copyHand1.Length; i++)
					for (int j = i + 1; j < copyHand1.Length; j++)
						if (copyHand1[i] == copyHand1[j]) h1Pair = copyHand1[i];
				//

				for (int i = 0; i < copyHand2.Length; i++)
					for (int j = i + 1; j < copyHand2.Length; j++)
						for (int k = j + 1; k < copyHand2.Length; k++)
							if (copyHand2[i] == copyHand2[j] && copyHand2[j] == copyHand2[k])
							{
								h2Three = copyHand2[i];
								copyHand2[i] = -1;
								copyHand2[j] = -2;
								copyHand2[k] = -3;
								break;
							}
				for (int i = 0; i < copyHand2.Length; i++)
					for (int j = i + 1; j < copyHand2.Length; j++)
						if (copyHand2[i] == copyHand2[j]) h2Pair = copyHand2[i];

				if (h1Three > h2Three) return 1;
				else if (h2Three > h1Three) return 2;
				else if (h1Pair > h2Pair) return 1;
				else if (h2Pair > h1Pair) return 2;
				else Console.WriteLine("Error! same hand in full house!");

			}
			else if (rankHand1 == Rank.FourOfAKind)
			{
				Console.Write("four of a kind...");
				h1 = 0;
				h2 = 0;
				for (int i = 0; i < hand1.Length; i++)
					for (int j = i + 1; j < hand1.Length; j++)
						if (hand1[i] == hand1[j]) h1 = hand1[i];

				for (int i = 0; i < hand2.Length; i++)
					for (int j = i + 1; j < hand2.Length; j++)
						if (hand2[i] == hand2[j]) h2 = hand2[i];
				if (h1 > h2) return 1;
				else if (h2 > h1) return 2;
				else return CheckWinnerHighestCard(hand1, hand2); //cant happend both hand have same four
			}
			else if (rankHand1 == Rank.StraightFlush)
			{
				Console.Write("straight flush...");
				int maxH1 = 0, maxH2 = 0;
				for (int i = 0; i < hand1.Length; i++)
					if (hand1[i] > maxH1) maxH1 = hand1[i];

				for (int i = 0; i < hand2.Length; i++)
					if (hand2[i] > maxH2) maxH2 = hand2[i];

				if (maxH1 == maxH2) Console.WriteLine("Error! two straight Flushs are equal! same hand!");
				return maxH1 > maxH2 ? 1 : 2;
			}
			else if (rankHand1 == Rank.RoyalFlush)
			{
				Console.Write("royal flush...");
				Console.WriteLine("Error! Both have royal flush, if you see this message, you need to add tie options");
			}
				return 0;
		}
		public static void CopyArray(int[] newArr,int[] oldArr)
        {
			for (int i = 0; i < newArr.Length; i++)
				newArr[i] = oldArr[i];
        }
	}
}








