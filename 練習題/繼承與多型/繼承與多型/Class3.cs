using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 繼承與多型
{
    class Wizard : Player
    {
        public Wizard()
        {
            Console.WriteLine("建立法師角色.");
        }
        override public void Attack(attackType type)
        {
            base.Attack(type);
            if (type == attackType.physical) Console.WriteLine("光箭");
            else Console.WriteLine("究極光箭");
            ExperiencePoint += 80;
        }
    }
}
