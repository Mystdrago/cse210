using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Brother Poulson (or Mr./Ms./Mrs. Teaching Assistant)!");

        Console.Write("What was your grade Percentage last semester?");
        string grade_Txt = Console.ReadLine();
        int grade = int.Parse(grade_Txt);
        string letter = "";
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade < 90 && grade >= 80)
        {
            letter = "B";
        }
        else if (grade < 80 && grade >= 70)
        {
            letter = "C";
        }
        else if (grade < 70 && grade >= 60)
        {
            letter = "D";
        }
        else 
        {
            letter = "F";
        }
         if (letter == "A" || letter =="B" || letter == "C")
         {
            Console.Write($"With a {letter} you passed! Congradulations, I see bright things in your future!");
         }
         else 
         {
            Console.Write($"With a {letter}, you didn't quite make it, hopefully you can retake the class next semester.");
         }
     }

}