using System.Collections.Generic;

namespace Project1
{
    class RangeOfLetters
    {
        public List<char> m_ListOfLetterToChoose;

        public RangeOfLetters()
        {
            m_ListOfLetterToChoose = new List<char>();
            for (int i = 65; i < 73; i++)
            {
                m_ListOfLetterToChoose.Add((char)i);
            }

        }

    }

}
