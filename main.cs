using System;
using System.Collections.Generic;


namespace testprogram
{
	public class GuessAdministrator
	{
		private int remainingGuesses;
		private List<char> guessedCharacters;
		private string SecretWord;

		// Constructor
		public GuessAdministrator(int noMaxGuesses, string SecretWord)
		{
			this.SecretWord = SecretWord;
			this.remainingGuesses = noMaxGuesses;
			guessedCharacters = new List<char>();
		}

		public bool isOutOfGuesses()
		{
			return this.remainingGuesses == 0;
		}

		public bool wordGuessedCorrectly()
		{
			bool wholeWordMatched = true;
			foreach (char c in SecretWord)
			{
				if (! guessedCharacters.Contains(c))
				{
					wholeWordMatched = false;
					break;
				}
			}
			return wholeWordMatched;
		}


		public void makeGuess(char guess)
		{
			Console.Write("You guessed '" + guess + "'.\t");

			// Verify that the character hasn't already been guessed
			if (guessedCharacters.Contains(guess))
			{
				Console.WriteLine(" You already guessed this character! ");
			}
			else {

				// A new character guessed, add it to the list of guessed characters
				guessedCharacters.Add(guess);

				// Check if it part of the secret word
				if (SecretWord.Contains(guess.ToString()))
				{
					Console.WriteLine(" It was correct");
				}
				else {
					Console.WriteLine(" It was incorrect");
					remainingGuesses--;
				}

			}
		}

		public int getRemainingGuesses()
		{
			return remainingGuesses;
		}

		public void printMaskedWord()
		{
			foreach (char c in SecretWord)
			{
				if (guessedCharacters.Contains(c))
				{
					Console.Write(c + " ");
				}
				else {
					Console.Write("_ ");
				}
			}
		}

		public void printNumberOfRemainingGuesses()
		{
			Console.Write("Number of guesses left: " + remainingGuesses + ".\t");
		}

		public void printGuessedCharacters()
		{
			Console.Write("Guessed characters so far:");

			if (guessedCharacters.Count == 0)
			{
				Console.Write(" none");
			}
			foreach (char c in guessedCharacters)
			{
				Console.Write(" " + c);
			}

		}


}

	public class Hangman
	{
		private static bool debug_on = false;
		private int noMaxGuesses = 3;

		public void Run()
		{

			// Select a secret word
			List<string> word_list = new List<string>()
			{
				"carrot",
				"fox",
				"explorer",
				"ladder",
				"adder",
				"badger",
				"guess"
			};

			Random rnd = new Random();
			string SecretWord = word_list[rnd.Next(word_list.Count)];

			// Initialize the administrator which keeps track of number of guesses on the secret word
			GuessAdministrator guessAdministrator = new GuessAdministrator(this.noMaxGuesses, SecretWord);


			if (Hangman.debug_on)
			{
				Console.WriteLine("The secret word is: " + SecretWord);
			}

			while (true)
			{
				// Print screen	
				for (int i = Console.WindowWidth; i > 0; i--)
				{
					Console.Write("-");
				}
				guessAdministrator.printNumberOfRemainingGuesses();
				guessAdministrator.printGuessedCharacters();

				Console.WriteLine();
				guessAdministrator.printMaskedWord();
				Console.WriteLine();
				Console.WriteLine();

				Console.WriteLine("Guess a character");
				char guess = Console.ReadLine()[0];

				Console.Clear();
				guessAdministrator.makeGuess(guess);

				if (guessAdministrator.isOutOfGuesses())
				{
					Console.WriteLine("You are out of guesses. Good bye");
					break;
				}

				if (guessAdministrator.wordGuessedCorrectly())
				{

					Console.WriteLine("You have guessed correctly! The word was '" + SecretWord + "'. I guess you'll live another day. Good bye");
					break;
				}

			};
 			
		}

	}

	
	public class main
	{
		public static void Main(string[] args)
		{

			//Kallast.Run();
			//Picnick.Run();
			Hangman game = new Hangman();
			game.Run();
		}
	}
}
