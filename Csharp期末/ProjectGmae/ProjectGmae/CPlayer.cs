using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGmae
{
    class CPlayer
    {
        protected int[] m_Numbers = new int[9];
        protected int[] m_Part1 = new int[3];
        protected int[] m_Part2 = new int[3];
        protected int[] m_Part3 = new int[3];

        public CPlayer()
        {

        }
        ~CPlayer()
        {

        }

        virtual public void SetNumbers(int[] numbers)
        {
            for(int i=0; i<9; ++i)
                m_Numbers[i] = numbers[i];
        }

        public void GetPart1(ref int[] part)
        {
            for (int i = 0; i < 3; ++i)
                part[i] = m_Part1[i];
            Array.Sort(part);
        }

        public void GetPart2(ref int[] part)
        {
            for (int i = 0; i < 3; ++i)
                part[i] = m_Part2[i];
            Array.Sort(part);
        }

        public void GetPart3(ref int[] part)
        {
            for (int i = 0; i < 3; ++i)
                part[i] = m_Part3[i];
            Array.Sort(part);
        }
    }
}
