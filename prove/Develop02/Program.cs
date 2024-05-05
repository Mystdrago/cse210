using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public override string ToString()
    {
        return $"{Date}: {Prompt}\nResponse: {Response}\n";
    }
}

class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void WriteNewEntry(string prompt)
    {
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Response: ");
        string response = Console.ReadLine();
        string date = DateTime.Now.ToShortDateString();
        Entry entry = new Entry(prompt, response, date);
        entries.Add(entry);
        Console.WriteLine("Entry added successfully!");
    }

    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("Journal is empty.");
            return;
        }

        Console.WriteLine("Journal Entries:\n");
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveJournalToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                outputFile.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
            }
        }

        Console.WriteLine($"Journal saved to {filename}");
    }

    public void LoadJournalFromFile(string filename)
    {
        entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split(",");
            if (parts.Length == 3)
            {
                Entry entry = new Entry(parts[1], parts[2], parts[0]);
                entries.Add(entry);
            }
        }
        Console.WriteLine($"Journal loaded from {filename}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        string filename = "journal.txt";

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");

            Console.Write("\nEnter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nWrite a new entry:");
                    journal.WriteNewEntry(GetRandomPrompt());
                    break;
                case "2":
                    Console.WriteLine("\nDisplaying journal entries:");
                    journal.DisplayJournal();
                    break;
                case "3":
                    Console.WriteLine("\nSaving journal to file...");
                    journal.SaveJournalToFile(filename);
                    break;
                case "4":
                    Console.WriteLine("\nLoading journal from file...");
                    journal.LoadJournalFromFile(filename);
                    break;
                case "5":
                    Console.WriteLine("\nExiting program...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Please enter a number from 1 to 5.");
                    break;
            }
        }
    }

    static string GetRandomPrompt()
    {
        string[] prompts = {
            "So how did everything go?",
            "What could you have done to have a better day?",
            "WHat are you thankful for Today?",
            "How did you feel today, if you felt bad what made you feel that way?",
            "If I had one thing I could do over today, what would it be?",
            "What could you have done today to make things easier?"
        };
        Random rnd = new Random();
        int index = rnd.Next(prompts.Length);
        return prompts[index];
    }
}
