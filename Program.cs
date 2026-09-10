// Core Rules & Mechanics
//     The computer randomly picks a secret integer within a defined range (typically 1 to 100).
//     The player is prompted to enter an integer guess in the terminal.
//     After each guess, the game responds with one of three hints:
//         "Too high!" (if the guess is greater than the secret number)
//         "Too low!" (if the guess is less than the secret number)
//         "Correct!" (if the guess matches the secret number)
//     The game tracks the number of attempts made.
//     Once the correct number is found, the game congratulates the player, reveals their total score/attempts, and asks if they want to play again.

class Program{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\t" + @"   ___                       _____ _                __                 _               ");
        Console.WriteLine("\t" + @"  / _ \_   _  ___  ___ ___  /__   \ |__   ___    /\ \ \_   _ _ __ ___ | |__   ___ _ __ ");
        Console.WriteLine("\t" + @" / /_\/ | | |/ _ \/ __/ __|   / /\/ '_ \ / _ \  /  \/ / | | | '_ ` _ \| '_ \ / _ \ '__|");
        Console.WriteLine("\t" + @"/ /_\\| |_| |  __/\__ \__ \  / /  | | | |  __/ / /\  /| |_| | | | | | | |_) |  __/ |   ");
        Console.WriteLine("\t" + @"\____/ \__,_|\___||___/___/  \/   |_| |_|\___| \_\ \/  \__,_|_| |_| |_|_.__/ \___|_|    Made by: Joshuuu");
        Console.WriteLine("\n\t=====================================================================================");
        Console.ResetColor();
        Console.WriteLine("\n\tA secret integer is randomly generated between a 1 and a number of your choice.");
        Console.WriteLine("\n\tYou have to guess the number in N guesses.");
        Console.WriteLine("");
        Console.WriteLine("\tPress any key to start the game...");
        Console.ReadKey(true);
        Console.Write("\n\tHow much should the max guesses be? ");
        
        int maxGuess;
        while (!int.TryParse(Console.ReadLine(), out maxGuess) || maxGuess <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tInvalid choice. Must be a whole number greater than 1.");
            Console.ResetColor();
            Console.Write("\n\tHow much should the max guesses be? ");
        }
        int number = GenerateNumber();
        GameLoop(number, maxGuess); 
    }
    static int GenerateNumber()
    {
        int maxRange;

        Console.Write("\n\tEnter the maximum number for the range (greater than 1): ");

        while (!int.TryParse(Console.ReadLine(), out maxRange) || maxRange <= 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tInvalid choice. Must be a whole number greater than 1.");
            Console.ResetColor();
            Console.Write("\n\tEnter the maximum number for the range (greater than 1): ");
        }

        Random random = new();
        Console.Write("\n\t");
        ShowGeneratingNumberMessage();
        System.Threading.Thread.Sleep(300);
        Console.WriteLine();
        return random.Next(1, maxRange + 1);
    }

    static void ShowGeneratingNumberMessage()
    {
        string message = "Generating number...";
        foreach (char letter in message)
        {
            Console.Write(letter);
            System.Threading.Thread.Sleep(150);
        }
    }

    static void GameLoop(int number, int maxGuess)
    {
        int guess = 0;
   
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n\tStart!");
        Console.ResetColor();

        for (int guessNum = 1; guessNum <= maxGuess + 1;)
        {
            if (guessNum == maxGuess + 1 && guess != number)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tYou lost. You've reached the max number of tries.");
                Console.ResetColor();
                return;
            }
            Console.Write($"\tAttempt {guessNum}: ");

            if (!int.TryParse(Console.ReadLine(), out int x))
            {
                Console.WriteLine("\tNumbers only. That's a guess wasted.");
            }
            else
            {
                guess = x;

                if (guess != number)
                {
                    if (guess > number)
                    {
                        Console.WriteLine("\tToo high");
                    } 
                    else 
                    {
                        Console.WriteLine("\tToo low");  
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green; 
                    Console.WriteLine($"\n\tCongratulations! You guessed {number} in {guessNum} attempts!");
                    return;
                } 
            }
            guessNum++;
            
        }
        return; 
    }
}
