# Bulls-and-Cows
C# console implementation of the famous game Bulls and Cows.

Game:
The computer selects a sequence of 4 letters randomly from the first 8 letters of the English alphabet (H-A) so that a letter can not appear twice.
At each stage the player guesses what is the sequence chosen by the computer, and the computer gives him "feedback" on guessing the player
Improve the next guess until you run out of guesswork or until you guessed correctly.
the plan:
The computer will first ask the user the maximum number of guesses (the number of rows), minimum 4,
Maximum 10.
The initial state will be a table containing empty lines according to the maximum number of guesses, with the first row appearing
Instead of the choice of a computer. ) See Figure 1.)
At each stage, the user will be prompted to select a sequence of 4 letters between A and H. After the user has guessed, the board will be displayed again with
The user's choice of the right line and the "right" to his guess.

How to score:
A letter that appears at the same location in the sequence that the computer has selected ("Bull") will win "V" and a letter that appears in the sequence of the computer
Not in the same sequence position ("hit") you will win "X." Note that the result does not show which of the letters received V or X.
The result is always aligned to the left side and always displays the "V" preceded by the "X" (see Figure 2).
If the user guesses correctly, a message is displayed and asks whether to play again. ) See Figure 3.)
If the guesswork is over, an appropriate message will be displayed and asked whether to play again. In this mode, the user will be exposed
The choice of computer. ) See Figure 4.)
After a game is over, the user will be asked if he wants to start another round.
At any time, instead of entering a guess, you can leave the game by entering "Q"
And the program will end.
