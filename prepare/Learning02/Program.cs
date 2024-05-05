using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Brother Poulson (or Mr./Ms./Mrs. Teaching Assistant)!");
        Job job1 = new Job();
        job1._jobTitle = "Cashire";
        job1._company = "Tacobell";
        job1._startYear = 2015;
        job1._endYear = 2016;

        Job job2 = new Job();
        job2._jobTitle = "Cashire";
        job2._company = "Burgerking";
        job2._startYear = 2020;
        job2._endYear = 2020;

        Resume myResume = new Resume();
        myResume._name = "James Curtis Halls II";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}