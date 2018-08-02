using System;
using System.Text;

namespace Project1
{
    public class Board
    {
        private readonly int r_TotalNumberOfGuesses;
        private const int k_TotalGuessSize = 4;
        private const int k_MaxNumberOfGuesses = 10;
        public int m_CurrentNumberOfGuesses;
        private readonly char[,] r_Pins;
        private readonly char[,] r_Result;

        public Board(int i_NumberOfGuesses)
        {
            m_CurrentNumberOfGuesses = 0;
            r_TotalNumberOfGuesses = i_NumberOfGuesses;
            r_Pins = new char[i_NumberOfGuesses, k_TotalGuessSize];
            r_Result = new char[i_NumberOfGuesses, k_TotalGuessSize];
        }

	    public int TotalNumberOfGuesses
	    {
		    get
		    {
			    return r_TotalNumberOfGuesses;
		    }

	    }

	    public void AddNewBoardLine(char[] i_NewPinsLine, char[] i_NewResultLine)
        {
            for (int i = 0; i < k_TotalGuessSize; i++)
            {
                if (i < i_NewPinsLine.Length)
                {
                    r_Pins[m_CurrentNumberOfGuesses, i] = i_NewPinsLine[i];
                }

                else
                {
                    r_Pins[m_CurrentNumberOfGuesses, i] = ' ';
                }

                if (i < i_NewResultLine.Length)
                {
                    r_Result[m_CurrentNumberOfGuesses, i] = i_NewResultLine[i];
                }

                else
                {
                    r_Result[m_CurrentNumberOfGuesses, i] = ' ';
                }

            }

            m_CurrentNumberOfGuesses++;
        }

        private static void apppendLineBreaker(StringBuilder i_Output)
        {
            i_Output.Append("\n|==========|=======|\n");
        }

        private static void appendArrayData(StringBuilder i_Output, char[,] i_ArrayData, int i_RowNumber, bool i_IsPinsArray)
        {
            for (int i = 0; i < k_TotalGuessSize; i++)
            {
                bool isEndOfLine = (i + 1 == k_TotalGuessSize);
                i_Output.Append(i_ArrayData[i_RowNumber, i]);
	            if(!isEndOfLine)
	            {
		            i_Output.Append(" ");
	            }

            }

            i_Output.Append(!i_IsPinsArray ? "|" : "  |");
        }

        public void PrintBoard()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            StringBuilder output = new StringBuilder("Current board status:\n\n|Pins:	   |Result:|\n|==========|=======|\n| # # # #  |       |\n|==========|=======|\n");
            // Print current board status pins and results
            for (int i = 0; i < m_CurrentNumberOfGuesses; i++)
            {
                output.Append("| ");
                appendArrayData(output, r_Pins, i, true);
                appendArrayData(output, r_Result, i, false);
                apppendLineBreaker(output);
            }

            // Print empty board pins and results
            for (int i = 0; i < k_MaxNumberOfGuesses - m_CurrentNumberOfGuesses; i++)
            {
                output.Append("|");
                output.Append("          |       |");
                apppendLineBreaker(output);
            }

            Console.WriteLine(output);
        }

    }

}