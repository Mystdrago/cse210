class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        // Eternal goals are never complete, so no need to set _isComplete
    }

    public override string GetDetailsString()
    {
        return $"[ ] {_name} ({_description})";
    }

    public override string Serialize()
    {
        return $"EternalGoal:{_name},{_description},{_points}";
    }
}
