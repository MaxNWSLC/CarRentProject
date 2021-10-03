using System;

namespace CarRentProject
{
    class CarClass
    {
        private int id;
        private string type;
        private string make;
        private string model;
        private int pricePerDay;
        private int passengers;
        private string color;
        private string availability;

        public CarClass(int id, string type, string make, string model, int pricePerDay, int passengers, string color, string availability)
        {
            this.id = id;
            this.type = type;
            this.make = make;
            this.model = model;
            this.pricePerDay = pricePerDay;
            this.passengers = passengers;
            this.color = color;
            this.availability = availability;
        }

        public CarClass(int id, string make, string model, int pricePerDay, int passengers, string color, string availability)
        {
            this.id = id;
            this.make = make;
            this.model = model;
            this.pricePerDay = pricePerDay;
            this.passengers = passengers;
            this.color = color;
            this.availability = availability;
        }
        public CarClass(string type, string make, string model, int pricePerDay, int passengers, string color, string availability)
        {
            this.type = type;
            this.make = make;
            this.model = model;
            this.pricePerDay = pricePerDay;
            this.passengers = passengers;
            this.color = color;
            this.availability = availability;
        }
        public CarClass(int id, string model, int pricePerDay, int passengers, string color, string availability)
        {
            this.id = id;
            this.model = model;
            this.pricePerDay = pricePerDay;
            this.passengers = passengers;
            this.color = color;
            this.availability = availability;
        }
        public CarClass(int id)
        {
            this.id = id;
        }


        public int Id { get => id; set => id = value; }
        public string Type { get => type; set => type = value; }
        public string Make { get => make; set => make = value; }
        public string Model { get => model; set => model = value; }
        public int PricePerDay { get => pricePerDay; set => pricePerDay = value; }
        public int Passengers { get => passengers; set => passengers = value; }
        public string Availability { get => availability; set => availability = value; }
        public string Color { get => color; set => color = value; }

        public String AsString(int i = 0)
        {
            switch (i)
            {
                case 1:
                    return $"ID: {Id}|| Make : {Make}||  Model : {Model}|| " +
                $"Price: {PricePerDay}|| Number of passengers: {Passengers}|| Colour : {Color}||" +
                $" Available: {availability}||{Environment.NewLine}";
                case 2:
                    return $"ID: {Id}|| Model : {Model}|| " +
                $"Price: {PricePerDay}|| Number of passengers: {Passengers}|| Colour : {Color}||" +
                $" Available: {availability}||{Environment.NewLine}";
                default:
                    return $"ID: {Id}|| Type: {Type}|| Make : {Make}||  Model : {Model}|| " +
                $"Price: {PricePerDay}|| Number of passengers: {Passengers}|| Colour : {Color}||" +
                $" Available: {availability}||{Environment.NewLine}";
            }
        }
    }
}
