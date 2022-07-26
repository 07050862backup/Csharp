using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGmae
{
    class C07050862 : CPlayer
    {
        public C07050862()
        {

        }

        ~C07050862()
        {

        }

        override public void SetNumbers(int[] numbers)
        {
            base.SetNumbers(numbers);
            Arrangement();
        }
        static void PrintMatrix(int[] matrix)
        {

            for (int j = 0; j <= matrix.GetUpperBound(0); ++j)
                    Console.Write("{0:d2} ", matrix[j]);
            Console.WriteLine();
        }

        private void Arrangement()
        {

            //PrintMatrix(m_Numbers);
            bool check = false;    //測試是否有數不符合，導致沒找到數字
            for (int i = 0; i < 9; ++i)//排序 m_Numbers
            {
                    for (int j = 0; j < i; ++j)
                    {
                        if (m_Numbers[j] > m_Numbers[i])
                        {
                            int temp = m_Numbers[j];
                            m_Numbers[j] = m_Numbers[i];
                            m_Numbers[i] = temp;
                        }
                    }
                }
            //PrintMatrix(m_Numbers);

            List<int> tempLists = new List<int>();
            //Console.WriteLine("將array複製到list");
            for(int i=0; i < m_Numbers.Length;i++ )
            {
                tempLists.Add(m_Numbers[i]);
                //Console.WriteLine(tempLists[i]);
            }
            int[,] ansArray = new int[3, 4];//{ [0 0 0 0]
                                            //  [0 0 0 0]
                                            //  [0 0 0 0]}
            ansArray[0,2] = tempLists[tempLists.Count-1];
            tempLists.RemoveAt(tempLists.Count-1);
            
            //第一組
            for (int i = 0; i < tempLists.Count; i++)
            {
                for(int j = 0; j < tempLists.Count;j++)
                    if(j!=i)
                    {
                        if (tempLists[j] - tempLists[i] < 3 && ansArray[0, 2] - tempLists[j] < 3)
                        {
                                ansArray[0, 0] = tempLists[i];
                                ansArray[0, 1] = tempLists[j];
                                if (j > i)
                                {
                                    tempLists.RemoveAt(j);
                                    tempLists.RemoveAt(i);
                                }
                                else//i大
                                {
                                    tempLists.RemoveAt(i);
                                    tempLists.RemoveAt(j);
                                }
                                check = true;
                                break;
                        }
                    }
                if (check == true)
                    break;
            }
            if (check == false)
            {
                ansArray[0, 0] = tempLists[0];
                ansArray[0, 1] = tempLists[1];
                tempLists.RemoveAt(0);
                tempLists.RemoveAt(0);
            }
            check = false;
            ansArray [1,2] = tempLists[tempLists.Count - 1];//第二組的C(最大) 
            tempLists.RemoveAt(tempLists.Count - 1);

            //第二組
            for (int i = 0; i < tempLists.Count; i++)
            {
                for (int j = 0; j < tempLists.Count; j++)
                    if (j != i)
                    {
                        if (tempLists[j] - tempLists[i] < 3)
                        {
                            if (ansArray[1, 2] - tempLists[j] < 3)
                            {
                                ansArray[1, 0] = tempLists[i];
                                ansArray[1, 1] = tempLists[j];
                                if(j>i)
                                {
                                    tempLists.RemoveAt(j);
                                    tempLists.RemoveAt(i);
                                }
                                else//i大
                                {
                                    tempLists.RemoveAt(i);
                                    tempLists.RemoveAt(j);
                                }
                                check = true;
                                break;
                            }
                        }
                    }
                if (check == true)
                    break;
            }
            if(check == false)
            {
                ansArray[1, 0] = tempLists[0];
                ansArray[1, 1] = tempLists[1];
                tempLists.RemoveAt(0);
                tempLists.RemoveAt(0);
            }

            ansArray[2, 0] = tempLists[0];//只剩三張，沒得選
            ansArray[2, 1] = tempLists[1];//只剩三張，沒得選
            ansArray[2, 2] = tempLists[2];//只剩三張，沒得選


           


            for (int k=0;k<3;k++)
            {
                    if (ansArray[k, 1] - ansArray[k, 0] <= 3 && ansArray[k, 2] - ansArray[k, 1] <= 3)
                        ansArray[k, 3] = ansArray[k, 2];
                    else if (ansArray[k, 1] - ansArray[k, 0] <= 3)// 5 - 3(2)< 3  ok  所以return 5 
                        ansArray[k, 3] = ansArray[k, 1];
                    else
                        ansArray[k, 3] = ansArray[k, 0];
            }
            //Console.WriteLine("沒排列 : {0} , {1} , {2}" , ansArray[0, 3], ansArray[1, 3], ansArray[2, 3]);

            for (int i = 0; i < 3; ++i)//排列第四個index的大小
            {
                for (int j = 0; j < i; ++j)
                {
                    if (ansArray[j, 3] > ansArray[i, 3])
                    {
                        int[] temp = new int[4];
                        temp[0] = ansArray[j, 0];
                        temp[1] = ansArray[j, 1];
                        temp[2] = ansArray[j, 2];
                        temp[3] = ansArray[j, 3];


                        ansArray[j,0] = ansArray[i,0];
                        ansArray[j, 1] = ansArray[i, 1];
                        ansArray[j, 2] = ansArray[i, 2];
                        ansArray[j, 3] = ansArray[i, 3];


                        ansArray[i, 0] = temp[0];
                        ansArray[i, 1] = temp[1];
                        ansArray[i, 2] = temp[2];
                        ansArray[i, 3] = temp[3];
                    }
                }
            }
            //Console.WriteLine("排列後 : {0} , {1} , {2}", ansArray[0, 3], ansArray[1, 3], ansArray[2, 3]);

            //PrintMatrix(m_Numbers);






            m_Part1[0] = ansArray[0, 0];
            m_Part1[1] = ansArray[0, 1];
            m_Part1[2] = ansArray[0, 2];
            m_Part2[0] = ansArray[1, 0];
            m_Part2[1] = ansArray[1, 1];
            m_Part2[2] = ansArray[1, 2];
            m_Part3[0] = ansArray[2, 0];
            m_Part3[1] = ansArray[2, 1];
            m_Part3[2] = ansArray[2, 2];

            /*Console.WriteLine("我的最後排序:");
            Console.WriteLine("{0} {1} {2}", m_Part1[0], m_Part1[1], m_Part1[2]);
            Console.WriteLine("{0} {1} {2}", m_Part2[0], m_Part2[1], m_Part2[2]);
            Console.WriteLine("{0} {1} {2}", m_Part3[0], m_Part3[1], m_Part3[2]);*/



          
        }
    }
}
