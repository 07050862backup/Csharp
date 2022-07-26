using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGmae
{
    class C00000000 : CPlayer
    {
        public C00000000()
        {

        }

        ~C00000000()
        {

        }

        override public void SetNumbers(int[] numbers)
        {
            base.SetNumbers(numbers);
            Arrangement();
        }

        private void Arrangement()
        {
            m_Part1[0] = m_Numbers[0];
            m_Part1[1] = m_Numbers[1];
            m_Part1[2] = m_Numbers[2];
            m_Part2[0] = m_Numbers[3];
            m_Part2[1] = m_Numbers[4];
            m_Part2[2] = m_Numbers[5];
            m_Part3[0] = m_Numbers[6];
            m_Part3[1] = m_Numbers[7];
            m_Part3[2] = m_Numbers[8];
        }
    }
}
