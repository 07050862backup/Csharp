using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 等差級數之和_while
{
    class Program
    {
        static void Series(int start,int end,int gap = 1)
        {
            int i,sum = 0;
            i = start;
            while(i<=end)
            {
                sum += i;
                Console.Write("{0}+", i);
                i += gap;
            }
            Console.WriteLine("\b={0}", sum);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Series(1,10)");
            Series(1, 10);
            Console.WriteLine("Series(2,20,2)");
            Series(2, 20 ,2);
        }
    }
}
