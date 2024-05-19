using System;

public class ListingActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration) : base(duration) { }

    public void Run()
    {
        StartActivity("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);
        ShowCountdown(3);

        int elapsed = 0;
        int itemCount = 0;
        while (elapsed < duration)
        {
            Console.Write("List an item: ");
            Console.ReadLine();
            itemCount++;
            elapsed += 5; // Each item takes approximately 5 seconds to list
        }

        Console.WriteLine($"You listed {itemCount} items.");
        EndActivity("Listing");
    }
}
