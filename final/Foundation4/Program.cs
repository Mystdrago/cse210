using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Activity> activities = new List<Activity>
            {
                new Running(new DateTime(2024, 5, 1), 30, 3.0),
                new Cycling(new DateTime(2024, 5, 2), 45, 20.0),
                new Swimming(new DateTime(2024, 5, 3), 60, 30)
            };

            foreach (var activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }

    abstract class Activity
    {
        private DateTime date;
        private int lengthInMinutes;

        public Activity(DateTime date, int lengthInMinutes)
        {
            this.date = date;
            this.lengthInMinutes = lengthInMinutes;
        }

        public DateTime Date => date;
        public int LengthInMinutes => lengthInMinutes;

        public virtual double GetDistance() => 0;
        public virtual double GetSpeed() => 0;
        public virtual double GetPace() => 0;

        public string GetSummary()
        {
            return $"Date: {date.ToShortDateString()}, Duration: {lengthInMinutes} minutes, Distance: {GetDistance()} km, Speed: {GetSpeed()} km/h, Pace: {GetPace()} min/km";
        }
    }

    class Running : Activity
    {
        private double distance;

        public Running(DateTime date, int lengthInMinutes, double distance)
            : base(date, lengthInMinutes)
        {
            this.distance = distance;
        }

        public override double GetDistance() => distance;

        public override double GetSpeed() => (GetDistance() / LengthInMinutes) * 60;

        public override double GetPace() => LengthInMinutes / GetDistance();
    }

    class Cycling : Activity
    {
        private double speed;

        public Cycling(DateTime date, int lengthInMinutes, double speed)
            : base(date, lengthInMinutes)
        {
            this.speed = speed;
        }

        public override double GetDistance() => (speed * LengthInMinutes) / 60;

        public override double GetSpeed() => speed;

        public override double GetPace() => 60 / speed;
    }

    class Swimming : Activity
    {
        private int laps;
        private const double LapDistance = 0.05; // Distance per lap in km (assuming 50 meters per lap)

        public Swimming(DateTime date, int lengthInMinutes, int laps)
            : base(date, lengthInMinutes)
        {
            this.laps = laps;
        }

        public override double GetDistance() => laps * LapDistance;

        public override double GetSpeed() => (GetDistance() / LengthInMinutes) * 60;

        public override double GetPace() => LengthInMinutes / GetDistance();
    }
}
