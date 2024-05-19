using System;

class Program
{
    static void Main(string[] args)
    {
         while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Activities Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");

            Console.Write("Choose an activity: ");
            string choice = Console.ReadLine();

            if (choice == "4")
                break;

            Console.Write("Enter the duration in seconds: ");
            if (!int.TryParse(Console.ReadLine(), out int duration))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity(duration);
                    breathingActivity.Run();
                    break;
                case "2":
                    ReflectionActivity reflectionActivity = new ReflectionActivity(duration);
                    reflectionActivity.Run();
                    break;
                case "3":
                    ListingActivity listingActivity = new ListingActivity(duration);
                    listingActivity.Run();
                    break;
                default:
                    Console.WriteLine("Invalid choice, please select a valid option.");
                    break;
            }
        }
    }
}