using System;
using System.Collections.Generic;

namespace Project1
{
    class UserGuess
    {
        private readonly char[] r_Guess;
        private readonly char[] r_FeedBack;
	    readonly List<char> r_CollectionToChooseFrom;
        public int m_SizeOfGuess;

        public UserGuess(int i_SizeOfGuessInTheGame, List<char> i_CollectionToChooseFrom)
        {
            r_Guess = new char[i_SizeOfGuessInTheGame];
            r_FeedBack = new char[i_SizeOfGuessInTheGame];
            Win = false;
            WishToQuit = false;
            r_CollectionToChooseFrom = new List<char>();
            r_CollectionToChooseFrom = i_CollectionToChooseFrom;
            m_SizeOfGuess = i_SizeOfGuessInTheGame;
        }

        public void UpdateGuessFromUser(UserGuess i_GuessFromUser, char[] i_WantedSolution)
        {
            bool invalidGuess = true;

	        while(invalidGuess)
            {
                invalidGuess = false;
                string inputStringFromUser = Console.ReadLine();
	            while(inputStringFromUser == null)
	            {
					Console.WriteLine("Invalid input please enter 4 charecters between A-H.");
					inputStringFromUser = Console.ReadLine();
	            }

	            bool userDecideToQuit = inputStringFromUser[0] =='q' || inputStringFromUser[0] == 'Q';
                if(userDecideToQuit)
                {
                    break;
                }

                for(int i = 0; i < inputStringFromUser.Length; i++)
                {
					bool validString = CheckIfContain(inputStringFromUser[i]);
					bool validStringLength = (inputStringFromUser.Length == 4);
					if (!validString || !validStringLength)
                    {
                        invalidGuess = true;
                        Console.WriteLine();
                        Console.WriteLine("Invalid input please enter 4 charecters between A-H.");
                        break;
                    }

	                // convert into char array
	                char[] newGuess = inputStringFromUser.ToCharArray();
	                removeLetterFromList(inputStringFromUser[i]);
	                i_GuessFromUser.SetGuess(newGuess);
	                i_GuessFromUser.setFeedBack(new String(i_GuessFromUser.GetGuess()).ToUpper().ToCharArray(), i_WantedSolution);
                }
            }
        }

        private void setFeedBack(char[] i_Guess, char[] i_WantedSolution)
        {
            int numberV = 0;
            int numberX = 0;
            for(int i = 0; i < i_Guess.Length; i++)
            {
                for (int j = 0; j < i_WantedSolution.Length; j++)
                {
                    if (i_Guess[i] == i_WantedSolution[j])
                    {
                        if (i == j)
                        {
                            numberV++;
                        }
                        else
                        {
                            numberX++;
                        }
                    }
                }
            }

            for(int k = 0; k < i_Guess.Length; k++)
            {
                if(numberV > 0)
                {
                    r_FeedBack[k] = 'V';
                    numberV--;
                }
                else if(numberX > 0)
                {
                    r_FeedBack[k] = 'X';
                    numberX--;
                }
                else
                {
                    r_FeedBack[k] = ' ';
                }
            }
            checkWin(m_SizeOfGuess);
        }

        private void checkWin(int i_SizeOfGuessInTheGame)
        {
            bool winStatus = true;
            for(int i = 0; i < i_SizeOfGuessInTheGame; i++)
            {
                winStatus = (r_FeedBack[i] == 'V');
                if(!winStatus)
                {
                    break;
                }

            }
            Win = winStatus;
        }

        public char[] GetGuess()
        {
            return r_Guess;
        }

        public void SetGuess(char[] i_NewGuess)
        {
            for(int i = 0; i < i_NewGuess.Length; i++)
            {
                r_Guess[i] = i_NewGuess[i];
            }
        }

        public char[] GetFeedBack()
        {
            return r_FeedBack;
        }

        public bool CheckIfContain(char i_SingleCharacter)
        {
	        bool ifContains = "ABCDEFGHabcdefgh".Contains(i_SingleCharacter.ToString());
	        return ifContains;
        }

        private void removeLetterFromList(char i_SingleCharacter)
        {
            if(CheckIfContain(i_SingleCharacter))
            {
                r_CollectionToChooseFrom.Remove(i_SingleCharacter);
            }
            else
            {
                r_CollectionToChooseFrom.Remove((char)(i_SingleCharacter - 32));
            }
        }

        public bool WishToQuit { get; set; }

	    public bool Win { get; set; }
    }
}