using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();

        bool quit = false;
        while (!quit)
        {
            Console.WriteLine("Eternal Quest");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. Show goals");
            Console.WriteLine("4. Save goals");
            Console.WriteLine("5. Load goals");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(goalManager);
                    break;
                case "2":
                    RecordEvent(goalManager);
                    break;
                case "3":
                    goalManager.DisplayGoals();
                    break;
                case "4":
                    SaveGoals(goalManager);
                    break;
                case "5":
                    LoadGoals(goalManager);
                    break;
                case "6":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }

    static void CreateGoal(GoalManager goalManager)
    {
        Console.WriteLine("Select Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        string choice = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter goal points: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                goalManager.AddGoal(new SimpleGoal(name, description, points));
                break;
            case "2":
                goalManager.AddGoal(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Enter target count: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goalManager.AddGoal(new ChecklistGoal(name, description, points, targetCount, bonusPoints));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    static void RecordEvent(GoalManager goalManager)
    {
        goalManager.DisplayGoals();
        Console.Write("Enter goal number to record event: ");
        int goalNumber = int.Parse(Console.ReadLine());
        goalManager.RecordEvent(goalNumber - 1);
    }

    static void SaveGoals(GoalManager goalManager)
    {
        Console.Write("Enter filename to save goals: ");
        string filename = Console.ReadLine();
        goalManager.SaveGoals(filename);
    }

    static void LoadGoals(GoalManager goalManager)
    {
        Console.Write("Enter filename to load goals: ");
        string filename = Console.ReadLine();
        goalManager.LoadGoals(filename);
    }
}
