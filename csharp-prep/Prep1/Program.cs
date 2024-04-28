using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Brother Poulson (or Mr./Ms./Mrs. Teaching Assistant)!");
        
        Console.Write("Though I might already know it, what might your your first name be? ");
        string first_name = Console.ReadLine();

        Console.Write("and your last name? ");
        string last_name = Console.ReadLine();

        Console.WriteLine($"So your our name is {last_name}, {first_name} {last_name}.");
    
    }
    
}