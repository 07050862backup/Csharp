using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGmae
{
    class Program
    {
        static Random random = new Random();
        const int m_NumberPlayers = 10;
        static int[] cards = new int[18];
        static CPlayer[] m_Players = new CPlayer[m_NumberPlayers];

        static void Main(string[] args)
        {
            m_Players[0] = new C00000000();
            m_Players[1] = new C07050862();
            m_Players[2] = new C07050862();
            m_Players[3] = new C07050862();
            m_Players[4] = new C07050862();
            m_Players[5] = new C07050862();
            m_Players[6] = new C07050862();
            m_Players[7] = new C07050862();
            m_Players[8] = new C07050862();
            m_Players[9] = new C07050862();
            //m_Players[2] = new C00000000();
            /* m_Players[2] = new C00000000();
             m_Players[3] = new C00000000();
             m_Players[4] = new C00000000();
             m_Players[5] = new C00000000();
             m_Players[6] = new C00000000();
             m_Players[7] = new C00000000();
             m_Players[8] = new C00000000();
             m_Players[9] = new C00000000();*/

            for (int i=0; i< m_NumberPlayers; ++i)
            {
                for(int j=i+1; j< m_NumberPlayers; ++j)
                {
                    int player1Score = 0;
                    int player2Score = 0;

                    Console.Write("{0}-{1};", i, j);
                    Shuffle();
                    m_Players[i].SetNumbers(cards);
                    int[] cardsSec = new int[9];
                    for (int x = 0; x < 9; ++x) cardsSec[x] = cards[x+9];
                    m_Players[j].SetNumbers(cardsSec);

                    int[] player1_1 = new int[3];
                    int[] player2_1 = new int[3];
                    int[] player1_2 = new int[3];
                    int[] player2_2 = new int[3];
                    int[] player1_3 = new int[3];
                    int[] player2_3 = new int[3];

                    //第1組比較
                    m_Players[i].GetPart1(ref player1_1);
                    m_Players[j].GetPart1(ref player2_1);
                    Console.WriteLine("\n玩家一: {0} 玩家二: {1}", GetNumber(player1_1), GetNumber(player2_1));
                    if (GetNumber(player1_1) > GetNumber(player2_1)) player1Score += 1;
                    else if (GetNumber(player1_1) < GetNumber(player2_1)) player2Score += 1;
                    //第2組比較
                    m_Players[i].GetPart2(ref player1_2);
                    m_Players[j].GetPart2(ref player2_2);
                    Console.WriteLine("玩家一: {0} 玩家二: {1}", GetNumber(player1_2), GetNumber(player2_2));
                    if (GetNumber(player1_2) < GetNumber(player1_1) && GetNumber(player2_2) < GetNumber(player2_1)) player1Score += 0;
                    else if (GetNumber(player1_2) < GetNumber(player1_1)) player2Score += 1;
                    else if (GetNumber(player2_2) < GetNumber(player2_1)) player1Score += 1;
                    else if (GetNumber(player1_2) > GetNumber(player2_2)) player1Score += 1;
                    else if (GetNumber(player1_2) < GetNumber(player2_2)) player2Score += 1;
                    //第3組比較
                    
                    m_Players[i].GetPart3(ref player1_3);
                    m_Players[j].GetPart3(ref player2_3);
                    Console.WriteLine("玩家一: {0} 玩家二: {1}", GetNumber(player1_3), GetNumber(player2_3));
                    if (GetNumber(player1_3) < GetNumber(player1_2) && GetNumber(player2_3) < GetNumber(player2_2)) player1Score += 0;
                    else if (GetNumber(player1_3) < GetNumber(player1_2)) player2Score += 1;
                    else if (GetNumber(player2_3) < GetNumber(player2_2)) player1Score += 1;
                    else if (GetNumber(player1_3) > GetNumber(player2_3)) player1Score += 1;
                    else if (GetNumber(player1_3) < GetNumber(player2_3)) player2Score += 1;
                    Console.Write("{0}:{1}\t", player1Score, player2Score);
                }
                Console.WriteLine();
            }
        }

        static int GetNumber(int[] numbers)
        {//1 3 3        5-3(2)<3 ok    &&     8-5(3)<3 NoOk
            if (numbers[1] - numbers[0] <= 3 && numbers[2] - numbers[1] <= 3)
                return numbers[2];
            else if (numbers[1] - numbers[0] <= 3)// 5 - 3(2)< 3  ok  所以return 5 
                return numbers[1];
            else
                return numbers[0];
               
        }

        static void Shuffle()  //洗牌
        {
            for (int j = 0; j < 2; ++j)
                for (int i = 0; i < 9; ++i)
                    cards[j * 9 + i] = i + 1;
            for (int i = 0; i < 999; ++i)
            {
                int x = random.Next(0, 16);
                int y = random.Next(0, 16);
                int z = cards[x];
                cards[x] = cards[y];
                cards[y] = z;
            }
            //for (int i = 0; i < 18; ++i)
            //    Console.Write("{0}, ", cards[i]);
        }
    }
}
