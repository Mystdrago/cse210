class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
            if (_currentCount == _targetCount)
            {
                _isComplete = true;
            }
        }
    }

    public override string GetDetailsString()
    {
        return $"[ {(IsComplete() ? "X" : " ")} ] {_name} ({_description}) -- Completed {_currentCount}/{_targetCount} times";
    }

    public override string Serialize()
    {
        return $"ChecklistGoal:{_name},{_description},{_points},{_currentCount},{_targetCount},{_bonusPoints},{_isComplete}";
    }
}
