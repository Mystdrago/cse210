using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public DateTime Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public JournalEntry(DateTime date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }
}

class Journal
{
    private List<JournalEntry> _entries = new List<JournalEntry>();
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void WriteNewEntry()
    {
        Random random = new Random();
        int promptIndex = random.Next(_prompts.Count);
        string prompt = _prompts[promptIndex];

        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        _entries.Add(new JournalEntry(DateTime.Now, prompt, response));
    }

    public void DisplayJournal()
    {
        foreach (var entry in _entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine();
        }
    }

    public void SaveJournalToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine($"Date: {entry.Date}");
                writer.WriteLine($"Prompt: {entry.Prompt}");
                writer.WriteLine($"Response: {entry.Response}");
                writer.WriteLine();
            }
        }
    }

    public void LoadJournalFromFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            _entries.Clear();

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                DateTime currentDate = DateTime.MinValue;
                string currentPrompt = string.Empty;
                string currentResponse = string.Empty;

                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("Date: "))
                    {
                        currentDate = DateTime.Parse(line.Substring("Date: ".Length));
                    }
                    else if (line.StartsWith("Prompt: "))
                    {
                        currentPrompt = line.Substring("Prompt: ".Length);
                    }
                    else if (line.StartsWith("Response: "))
                    {
                        currentResponse = line.Substring("Response: ".Length);
                    }
                    else if (string.IsNullOrWhiteSpace(line))
                    {
                        _entries.Add(new JournalEntry(currentDate, currentPrompt, currentResponse));
                        currentPrompt = string.Empty;
                        currentResponse = string.Empty;
                        currentDate = DateTime.MinValue;
                    }
                }
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a New Entry");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Save Journal to File");
            Console.WriteLine("4. Load Journal from File");
            Console.WriteLine("5. Exit");

            Console.Write("Select an option (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.WriteNewEntry();
                    break;
                case "2":
                    Console.WriteLine("Journal Entries:");
                    journal.DisplayJournal();
                    break;
                case "3":
                    Console.Write("Enter the filename to save the journal: ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveJournalToFile(saveFileName);
                    break;
                case "4":
                    Console.Write("Enter the filename to load the journal: ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadJournalFromFile(loadFileName);
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }
}
//added to the end to give an edit for push