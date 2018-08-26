using System;
using System.Text;

namespace Project1
{
    public class GuessGame
    {
        private const int k_SizeOfGuesses = 4;
        RangeOfLetters m_Letters;
        private char[] m_RandomSolution;
        int m_NumberOfGuesses;
        UserGuess m_NewUserGuess;
        Board m_Board;

        public void StartGame()
        {
            m_NumberOfGuesses = GetNumberOfGuessesFromUser();
            initGame(m_NumberOfGuesses);
            runGame();
        }

        private void runGame()
        {
	        bool needToCheckDesireOfUserForExitStatus = false;
            Console.WriteLine("Please type your next guess <A B C D> or 'Q' to quit");
            for (int theCurrentGuess = 0; theCurrentGuess <= m_NumberOfGuesses; theCurrentGuess++)
            {
                bool theUserLose = (theCurrentGuess == m_NumberOfGuesses);
                if (theUserLose)
                {
                    Console.WriteLine("No more Guesses allowed. You Lost.");
                    needToCheckDesireOfUserForExitStatus = true;
                    break;
                }

                m_NewUserGuess.UpdateGuessFromUser(m_NewUserGuess, m_RandomSolution);
                if (m_NewUserGuess.WishToQuit)
                {
                    Console.WriteLine("You choose to quit the game, thanks for participate, Bye Bye!");
                    break;
                }

                m_Board.AddNewBoardLine(m_NewUserGuess.GetGuess(), m_NewUserGuess.GetFeedBack());
                m_Board.PrintBoard();

                if (m_NewUserGuess.Win)
                {
                    StringBuilder winMessege = new StringBuilder("You guessed after ");
                    winMessege.Append(theCurrentGuess);
                    winMessege.Append(" steps!");
					Console.WriteLine(winMessege);
                    needToCheckDesireOfUserForExitStatus = true;
                    break;
                }

	            bool keepOnPlaying = theCurrentGuess+1 < m_NumberOfGuesses;
				if (keepOnPlaying)
	            {
		            Console.WriteLine("Please type your next guess <A B C D> or 'Q' to quit");
	            }

            }

            if (needToCheckDesireOfUserForExitStatus)
            {
	            bool userWantstoPlay = checkTheDesireOfTheUserForNext();
	            if (!userWantstoPlay)
                {
                    Console.WriteLine("You choose to end the game, thanks for participate, Bye Bye!");
	                Console.ReadLine();
                }

                else
                {
                    StartGame();
                }

            }

        }

        private void setRandomSolution()
        {
	        string chars = "ABCDEFGH";
            char[] solution = new char[k_SizeOfGuesses];
            m_RandomSolution = new char[k_SizeOfGuesses];
            Random random = new Random();
            for (int i = 0; i < k_SizeOfGuesses; i++)
            {
                int sizeOfList = m_Letters.m_ListOfLetterToChoose.Count;
                // check if the range of the letters is correct
				m_RandomSolution[i] = chars[random.Next(sizeOfList)];

                m_Letters.m_ListOfLetterToChoose.Remove(solution[i]);
            }

            m_Letters = new RangeOfLetters();
        }

        private static bool checkTheDesireOfTheUserForNext()
        {
            bool inValidRespone = true;
            bool wishToContinuePlay = false;
            Console.WriteLine("Would you like to start a new game? (Y/N)");
            while (inValidRespone)
            {
                string whatToDoNext = Console.ReadLine();
                if ((whatToDoNext == "Y") || (whatToDoNext == "y"))
                {
                    inValidRespone = false;
                    wishToContinuePlay = true;
                }

                else if ((whatToDoNext == "N") || (whatToDoNext == "n"))
                {
                    inValidRespone = false;
                }

            }

            return wishToContinuePlay;
        }


        public static int GetNumberOfGuessesFromUser()
        {
            int intNumberOfGuesses = 0;
            bool validNumberOfGuess = false;
            while (!validNumberOfGuess)
            {
                Console.WriteLine("Please enter your desired number of guesses for the game, the number should be between 4-10: ");
                string numberOfGuesses = Console.ReadLine();
                validNumberOfGuess = int.TryParse(numberOfGuesses, out intNumberOfGuesses);
                if (!validNumberOfGuess)
                {
                    Console.WriteLine("Invalid number of guesses");
                }

                else
                {
                    validNumberOfGuess = ((intNumberOfGuesses >= 4) && (intNumberOfGuesses <= 10));
                    if (!validNumberOfGuess)
                    {
                        Console.WriteLine("number of guesses is out of boundes, please enter number between 4-10: ");
                    }

                }

            }

            return intNumberOfGuesses;
        }

        private void initGame(int i_NumberOfGuesses)
        {
            m_Board = new Board(i_NumberOfGuesses);
            m_Board.PrintBoard();
            m_Letters = new RangeOfLetters();
            setRandomSolution();
            m_NewUserGuess = new UserGuess(k_SizeOfGuesses, m_Letters.m_ListOfLetterToChoose);
        }

    }

}
