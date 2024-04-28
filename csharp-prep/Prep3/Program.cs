using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Brother Poulson (or Mr./Ms./Mrs. Teaching Assistant)!");
        Random randomGenerator = new Random();
        int magic = randomGenerator.Next(1, 101);
        Console.Write("Can you guess the Magic Number?");
        int guess_num = 0;
        int guess = 0;
        while (guess != magic)
        {
            Console.Write("What's your guess? ");
            guess = int.Parse(Console.ReadLine());
            guess_num ++;
            if (magic > guess)
            {
                Console.WriteLine("It's a bit higher.");
            }
            else if (magic < guess)
            {
                Console.WriteLine("Little lower");
            }
            else
            {
                Console.WriteLine($"You guessed it! Only took you {guess_num} times!");
            }
            
        }
    }
}