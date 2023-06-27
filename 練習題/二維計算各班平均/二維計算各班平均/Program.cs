using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*現有3個班各5位學生，請寫一程式可以輸入每位學生成績，並計算出各班平均。
*/
namespace 二維計算各班平均
{
    class Program
    {
        static void Main(string[] args)
        {

            
            int[,] a  = new int[3, 5];
            int[] sum = new int[3];
            for (int i = 0; i <= a.GetUpperBound(0); ++i)
            {
                for (int j = 0; j <= a.GetUpperBound(1); ++j)
                {
                    Console.Write("輸入第{0}班，第{1}位學生成績: ", i+1, j+1);
                    a[i,j] = Convert.ToInt32(Console.ReadLine());
                    sum[i] += a[i, j];
                }
                Console.WriteLine();
            }
            for (int i=0; i <= a.GetUpperBound(0);i++)
            Console.WriteLine("第{0}班總和:{1}\n平均:{2}", i+1, sum[i],sum[i]/(a.GetUpperBound(1)+1));

        }
    }
}
