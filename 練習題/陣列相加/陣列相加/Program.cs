using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 陣列相加
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j;
            int[,] aMatrix = new int[3, 3];
            int[,] bMatrix = new int[3, 3];
            int[,] cMatrix = new int[3, 3];
            CreateMatrix(ref aMatrix);
            Console.WriteLine("Matrix A:");
            PrintMatrix(aMatrix);
            CreateMatrix(ref bMatrix);
            Console.WriteLine("Matrix B:");
            PrintMatrix(bMatrix);
            for (j = 0; j <= cMatrix.GetUpperBound(0); ++j)
            {
                for (i = 0; i <= cMatrix.GetUpperBound(1); ++i)
                {
                    cMatrix[j, i] = aMatrix[j, i] + bMatrix[j, i];
                }
            }
            Console.WriteLine("Matrix C:");
            PrintMatrix(cMatrix);
        }
        static void CreateMatrix(ref int[,] matrix)
        {
            int i, j;
            Random randomNum = new Random();
            for (j = 0; j <= matrix.GetUpperBound(0); ++j)
            {
                for (i = 0; i <= matrix.GetUpperBound(1); ++i)
                {
                    matrix[j, i] = randomNum.Next(10);
                }
            }
        }
        static void PrintMatrix(int[,] matrix)
        {
            int i, j;
            for (j = 0; j <= matrix.GetUpperBound(0); ++j)
            {
                for (i = 0; i <= matrix.GetUpperBound(1); ++i)
                {
                    Console.Write("{0:d2} ", matrix[j, i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
