using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 繼承與多型
{
    class Warrior : Player
    {
        public Warrior()
        {
            Console.WriteLine("建立戰士角色.");
        }
        override public void Attack(attackType type)
        {
            base.Attack(type);
            if (type == attackType.physical) Console.WriteLine("斬擊");
            else Console.WriteLine("堅固防禦");
            ExperiencePoint += 80;
        }
    }
}
