using System;
using System.Collections.Generic;

namespace EventPlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            Address address1 = new Address("123 Main St", "Anytown", "NY", "USA");
            Address address2 = new Address("456 Elm St", "Othertown", "ON", "Canada");
            Address address3 = new Address("789 Oak St", "Sometown", "CA", "USA");

            Lecture lecture = new Lecture("Tech Conference", "A conference about the latest in tech", new DateTime(2023, 7, 15), "10:00 AM", address1, "Dr. Smith", 100);
            Reception reception = new Reception("Wedding Reception", "Celebrate the union of two hearts", new DateTime(2023, 8, 20), "6:00 PM", address2, "rsvp@wedding.com");
            OutdoorGathering outdoorGathering = new OutdoorGathering("Summer Picnic", "An outdoor picnic for families", new DateTime(2023, 9, 5), "12:00 PM", address3, "Sunny and 75°F");

            List<Event> events = new List<Event> { lecture, reception, outdoorGathering };

            foreach (var ev in events)
            {
                Console.WriteLine(ev.GetStandardDetails());
                Console.WriteLine(ev.GetFullDetails());
                Console.WriteLine(ev.GetShortDescription());
                Console.WriteLine();
            }
        }
    }

    class Address
    {
        private string street;
        private string city;
        private string state;
        private string country;

        public Address(string street, string city, string state, string country)
        {
            this.street = street;
            this.city = city;
            this.state = state;
            this.country = country;
        }

        public bool IsUSA()
        {
            return country.ToLower() == "usa";
        }

        public override string ToString()
        {
            return $"{street}, {city}, {state}, {country}";
        }
    }

    abstract class Event
    {
        private string title;
        private string description;
        private DateTime date;
        private string time;
        private Address address;

        public Event(string title, string description, DateTime date, string time, Address address)
        {
            this.title = title;
            this.description = description;
            this.date = date;
            this.time = time;
            this.address = address;
        }

        public string GetStandardDetails()
        {
            return $"Event: {title}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time}\nAddress: {address}";
        }

        public abstract string GetFullDetails();

        public string GetShortDescription()
        {
            return $"Type: {this.GetType().Name}, Title: {title}, Date: {date.ToShortDateString()}";
        }
    }

    class Lecture : Event
    {
        private string speaker;
        private int capacity;

        public Lecture(string title, string description, DateTime date, string time, Address address, string speaker, int capacity)
            : base(title, description, date, time, address)
        {
            this.speaker = speaker;
            this.capacity = capacity;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nType: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
        }
    }

    class Reception : Event
    {
        private string rsvpEmail;

        public Reception(string title, string description, DateTime date, string time, Address address, string rsvpEmail)
            : base(title, description, date, time, address)
        {
            this.rsvpEmail = rsvpEmail;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nType: Reception\nRSVP Email: {rsvpEmail}";
        }
    }

    class OutdoorGathering : Event
    {
        private string weatherForecast;

        public OutdoorGathering(string title, string description, DateTime date, string time, Address address, string weatherForecast)
            : base(title, description, date, time, address)
        {
            this.weatherForecast = weatherForecast;
        }

        public override string GetFullDetails()
        {
            return $"{GetStandardDetails()}\nType: Outdoor Gathering\nWeather Forecast: {weatherForecast}";
        }
    }
}
