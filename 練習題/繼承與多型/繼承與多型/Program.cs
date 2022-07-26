using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 繼承與多型
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Console.WriteLine("請選擇職業:\n1.戰士\t2.精靈\t3.法師");
            occupation playerOccupation = (occupation)Convert.ToInt32(Console.ReadLine());
            switch (playerOccupation)
            {
                case occupation.warrior:
                    player = new Warrior();
                    break;
                case occupation.elf:
                    player = new Elf();
                    break;
                case occupation.wizard:
                    player = new Wizard();
                    break;
                default:
                    Console.WriteLine("新手請輸入1~3");
                    break;
            }
            Console.WriteLine("請輸入角色名稱");
            player.Name = Console.ReadLine();
            Console.WriteLine();
            player.Attack(attackType.physical);
            player.Attack(attackType.magic);
        }
    }
}
