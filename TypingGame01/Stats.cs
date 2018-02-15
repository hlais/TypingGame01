using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingGame01
{
    class Stats
    {
        public int m_Total = 0;
        public int m_Missed = 0;
        public int m_Correct = 0;
        public int m_Accuracy = 0;

        public void Update(bool correctKey)
        {
            m_Total++;

            if (!correctKey)
            {
                m_Missed++;
            }
            else
            {
                m_Correct++;
            }
            //work out the percentage
            m_Accuracy = 100 * m_Correct / (m_Missed + m_Correct);
        }
    }
}
