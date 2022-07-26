using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 類別練習一.HelloCSharp;

namespace 類別練習一
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass myclass = new MyClass();
            Console.WriteLine("請選擇職業:\n1.戰士\t2.精靈\t3.法師");
            myclass.Occupation = (occupation)Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("請輸入角色名稱");
            myclass.Name = Console.ReadLine();
            Console.WriteLine();
            myclass.Attack(attackType.physical);
            myclass.Attack(attackType.magic);
        }
    }
}
