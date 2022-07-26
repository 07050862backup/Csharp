using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 計算總分與平均
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[10];
            int sum = 0;
            for (int i=0; i < a.Length;i++)
            {
                Console.Write("輸入第{0}位學生成績: ",i+1);
                a[i] = Convert.ToInt32(Console.ReadLine());
                sum += a[i];
            }
            Console.Write("總和:{0} \n平均:{1}", sum,(float)sum/a.Length);
        }
    }
}
