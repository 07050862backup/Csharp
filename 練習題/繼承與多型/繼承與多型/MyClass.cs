using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 繼承與多型
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
    class Player
    {
        public Player()
        {
            m_Name = "";
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
        virtual public void Attack(attackType type)
        {
            Console.Write("{0}使出", m_Name);
        }
    }
}
