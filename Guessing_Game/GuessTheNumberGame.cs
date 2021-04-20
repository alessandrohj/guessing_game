//Alessandro de Jesus - April 20, 2021
using System;
namespace Guessing_Game
{
    public class GuessTheNumberGame
    {
        private int randomNumber = 0;
        private int guessCount = 0;
        private string input;
        private int MAX_MENU = 3;
        private int MIN_MENU = 0;
        private bool isValid = false;

        private RangedRandomInteger secretNumberGenerator = new RangedRandomInteger();

        public GuessTheNumberGame()
        {

        }

        private int ShowMenu()
        {
            int choice = 100;

            Console.Clear();
            Console.WriteLine("##---------------------------------------------------##");
            Console.WriteLine("##            Please choose:                         ##");
            Console.WriteLine("##                                                   ##");
            Console.WriteLine("##   1: Easy: Guess a number between 1 and 20        ##");
            Console.WriteLine("##                                                   ##");
            Console.WriteLine("##   2: Normal: Guess a number between 1 and 100     ##");
            Console.WriteLine("##                                                   ##");
            Console.WriteLine("##   3: Hard: Guess a number between 1 and 1000      ##");
            Console.WriteLine("##                                                   ##");
            Console.WriteLine("##   0: Exit                                         ##");
            Console.WriteLine("##                                                   ##");
            Console.WriteLine("##---------------------------------------------------##");

            /*At this point, user's input will be compared against the options in the menu.
             * The try/catch block will evaluate it and discard invalid entries.
             */

            do
            {
                Console.WriteLine("Enter your choice here:");
                Console.WriteLine();

                try
                {
                    input = Console.ReadLine();
                    Console.Write("\n\n");
                    choice = Convert.ToInt32(input);
                }

                catch (Exception e)
                {
                    if (e is FormatException)
                    {
                        Console.Write("Invalid input: " + e.Message);
                    }
                    else if (e is OverflowException)
                    {
                        Console.Write("Number too large: " + e.Message);
                    }
                    else
                    {
                        Console.Write("Error: " + e.Message);
                    }
                }

                if ((choice >= MIN_MENU) && (choice <= MAX_MENU))
                {
                    isValid = true;
                }

                if (!isValid)
                {
                    Console.Write("Please enter 0, 1, 2 or 3:");
                    if (choice == 0) break;

                }
        
            } while (!isValid);

            //Once a valid response is provided, the Setup method will run to generate a random number.
                return Setup(choice);
        }
        private int Setup(int rangeOption)
        {
            /*Based on the level selected by the user, one of the cases below will run.
             * A setMaximum method/setter will be called to set the maximum value.
             * Since the minimum value is the same for all levels, it's already defined in the beginning, outside the switch statement.
             */

            secretNumberGenerator.setMinimum(1);
            switch (rangeOption)
            {
                case 0:
                    return 0;
                case 1:
                    secretNumberGenerator.setMaximum(20);
                    randomNumber = secretNumberGenerator.GenerateRandomNumber();
                    break;
                case 2:
                    secretNumberGenerator.setMaximum(100);
                    randomNumber = secretNumberGenerator.GenerateRandomNumber();
                    break;
                case 3:
                    secretNumberGenerator.setMaximum(1000);
                    randomNumber = secretNumberGenerator.GenerateRandomNumber();
                    break;
            }

            return randomNumber;

        }
        private void Play(int secretNumber)
        {
            int guess = 0;

            //while loop will run till the users guesses the random number generated
            while (guess != secretNumber)
            {
                try //try / catch block to evaluate entry and discard invalid inputs
                {
                    Console.WriteLine("Enter your guess: ");
                    input = Console.ReadLine();
                    guess = Convert.ToInt32(input);
                     if (input == "n" || input == "N")
                    {
                        Console.WriteLine("That's a shame. You left!");
                        Console.WriteLine("\n");
                        Console.WriteLine($"Total guesses: {guessCount}. And the number you were suppose to guess is: {secretNumber}");
                        break;
                    }
                }

                catch (Exception e)
                {
                    if (e is FormatException)
                    {
                        Console.Write("Invalid input: " + e.Message);
                        continue;
                    }
                    else if (e is OverflowException)
                    {
                        Console.Write("Number too large: " + e.Message);
                        continue;
                    }
                    else
                    {
                        Console.Write("Error: " + e.Message);
                        continue;
                    }
                }

                //after it exits the try/catch, if will compare the number user typed agains the random number generated (secretNumber)
                if (guess < secretNumber)
                {
                    Console.WriteLine("Your guess was too low");
                    Console.WriteLine("\n");
                    guessCount++; //Counter for user's guesses. It increases at each attempt.
                }
                if (guess > randomNumber)
                {
                    Console.WriteLine("Your guess was too high");
                    Console.WriteLine("\n");
                    guessCount++;
                }
                if (guess == randomNumber)
                {
                    guessCount++;
                    Console.WriteLine("Congratulations! You guessed the correct number!");
                    Console.WriteLine($"Total guesses: {guessCount}");
                    Console.WriteLine("\n");
                    Console.WriteLine("Want to try again? Y/N?");
                    input = Console.ReadLine();
                    if (input == "n" || input == "N") break;  //At the end of the game, user can exit it or retart it.
                    if (input == "Y" || input == "y"){
                        Start(); //if the user chooses to re
                    }
                }

            }



        }

        public void Start()
        {
            //this method will loop till a valid entry (0, 1, 2, 3) is typed. While on loop, ShowMenu() will be called.
            do
            {
                ShowMenu();
               
            } while (!isValid);
            Play(randomNumber); //once it exits the loop, it will call Play() and a number will be generated, based on the option selected inside ShowMenu()
        }
    }
}
