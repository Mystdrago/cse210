using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _totalPoints = 0;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal goal = _goals[goalIndex];
            goal.RecordEvent();
            _totalPoints += goal.GetPoints();
            if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                _totalPoints += checklistGoal.GetPoints(); // Adding bonus points
            }
        }
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        Console.WriteLine($"Total Points: {_totalPoints}");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.Serialize());
            }
        }
    }

    public void LoadGoals(string filename)
    {
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split(':');
                string goalType = parts[0];
                string[] details = parts[1].Split(',');

                if (goalType == "SimpleGoal")
                {
                    SimpleGoal goal = new SimpleGoal(details[0], details[1], int.Parse(details[2]));
                    if (bool.Parse(details[3]))
                    {
                        goal.RecordEvent();
                    }
                    AddGoal(goal);
                }
                else if (goalType == "EternalGoal")
                {
                    EternalGoal goal = new EternalGoal(details[0], details[1], int.Parse(details[2]));
                    AddGoal(goal);
                }
                else if (goalType == "ChecklistGoal")
                {
                    ChecklistGoal goal = new ChecklistGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[4]), int.Parse(details[5]));
                    for (int i = 0; i < int.Parse(details[3]); i++)
                    {
                        goal.RecordEvent();
                    }
                    AddGoal(goal);
                }
            }
        }
    }
}
