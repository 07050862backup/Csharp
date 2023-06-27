using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 繼承與多型
{
    class Elf : Player
    {
        public Elf()
        {
            Console.WriteLine("建立精靈角色.");
        }
        override public void Attack(attackType type)
        {
            base.Attack(type);
            if (type == attackType.physical) Console.WriteLine("射擊");
            else Console.WriteLine("三連發");
            ExperiencePoint += 80;
        }
    }
}
