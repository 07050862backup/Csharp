using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 類別練習一
{
    namespace HelloCSharp
    {
        enum occupation
        {
            none,
            warrior,
            elf,
            wizard
        }
        enum attackType
        {
            physical,
            magic,
        }
        delegate void LevelUpEvent();
        class MyClass
        {
            public MyClass()
            {
                m_Name = "";
                m_Occupation = occupation.none;
                m_ExperiencePointToNextLevel = 100;
                m_ExperiencePoint = 0;
                levelUp += new LevelUpEvent(LevelUp);
            }
            private string m_Name;
            public string Name
            {
                get
                {
                    return m_Name;
                }
                set
                {
                    m_Name = value;
                }
            }
            private occupation m_Occupation;
            public occupation Occupation
            {
                get
                {
                    return m_Occupation;
                }
                set
                {
                    m_Occupation = value;
                }
            }
            public event LevelUpEvent levelUp;
            private static double m_ExperiencePointToNextLevel;
            private int m_ExperiencePoint;
            public int ExperiencePoint
            {
                get
                {
                    return m_ExperiencePoint;
                }
                set
                {
                    m_ExperiencePoint = value;
                    if (m_ExperiencePoint >= m_ExperiencePointToNextLevel)
                        if (levelUp != null) levelUp();
                }
            }
            static void LevelUp()
            {
                Console.WriteLine("等級提升.");
                m_ExperiencePointToNextLevel *= 1.2;
            }
            public void Attack(attackType type)
            {
                Console.Write("{0}使出", m_Name);
                switch (m_Occupation)
                {
                    case occupation.warrior:
                        if (type == attackType.physical) Console.WriteLine("斬擊");
                        else Console.WriteLine("堅固防禦");
                        break;
                    case occupation.elf:
                        if (type == attackType.physical) Console.WriteLine("射擊");
                        else Console.WriteLine("三連發");
                        break;
                    case occupation.wizard:
                        if (type == attackType.physical) Console.WriteLine("光箭");
                        else Console.WriteLine("究極光箭");
                        break;
                    default:
                        Console.WriteLine("新手攻擊");
                        break;
                }
                ExperiencePoint += 80;
            }
        }
    }
}
