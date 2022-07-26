using System;
using System.Diagnostics;

namespace 費氏數列
{
    class Program
    {
        static int Fibonacci(int n)
        {
            if (n == 0 || n == 1) return n;
            else return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
        static int fib_Dict(int n)
        {
            if (n == 0 || n == 1) return fib_Dict(n);
            else
            {
                int result = fib_Dict(n - 1) + fib_Dict(n - 2)

                fib[n] = result
		        return result;
            }
        }
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            /*stopWatch.Start();
            for(int i=0;i<40;++i)
            {
                Console.Write("{0}\t", Fibonacci(i));
            }
            Console.WriteLine();
            stopWatch.Stop();*/
            Console.WriteLine("花費時間{0}ms", stopWatch.ElapsedMilliseconds);
        }
    }
}
