using System;
using System.Collections.Generic;

class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public void Unhide()
    {
        IsHidden = false;
    }

    public override string ToString()
    {
        return IsHidden ? "_".PadRight(Text.Length) : Text;
    }
}

class Reference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int StartVerse { get; private set; }
    public int EndVerse { get; private set; }

    public Reference(string book, int chapter, int startVerse, int endVerse = -1)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse == -1 ? startVerse : endVerse;
    }

    public override string ToString()
    {
        if (StartVerse == EndVerse)
        {
            return $"{Book} {Chapter}:{StartVerse}";
        }
        else
        {
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
        }
    }
}

class Scripture
{
    private Reference reference;
    private List<Word> words;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        words = new List<Word>();
        string[] tokens = text.Split(' ');
        foreach (string token in tokens)
        {
            words.Add(new Word(token));
        }
    }

    public void Display()
    {
        Console.WriteLine(reference);
        foreach (Word word in words)
        {
            Console.Write(word + " ");
        }
        Console.WriteLine();
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int count = random.Next(1, words.Count / 2);
        for (int i = 0; i < count; i++)
        {
            int index = random.Next(words.Count);
            words[index].Hide();
        }
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in words)
        {
            if (!word.IsHidden)
            {
                return false;
            }
        }
        return true;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("James", 1, 4);
        string text = "But let patience have her perfect work, that ye may be perfect and entire, wanting nothing.";
        Scripture scripture = new Scripture(reference, text);

        while (!scripture.AllWordsHidden())
        {
            Console.ReadLine();
            Console.Clear();
            scripture.HideRandomWords();
            scripture.Display();
        }

        Console.WriteLine("All words hidden. Press Enter to exit.");
        Console.ReadLine();
    }
}