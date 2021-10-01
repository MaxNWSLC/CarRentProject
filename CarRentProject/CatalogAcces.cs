using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentProject
{
    class CatalogAcces
    {
        private string connectionString;

        public CatalogAcces(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string ConnectionString { get => connectionString; set => connectionString = value; }

        public CarClass[] ReadAllCars()
        {
            List<CarClass> result = new();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $"SELECT * FROM cars";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new CarClass(id: reader.GetInt32(0),
                                                type: reader.GetString(1),
                                                make: reader.GetString(2),
                                                model: reader.GetString(3),
                                                pricePerDay: reader.GetInt32(4),
                                                passengers: reader.GetInt32(5),
                                                color: reader.GetString(6),
                                                availability: reader.GetString(7)));
                    }
                }

                connection.Close();
            }
            return result.ToArray();
        }
        public CarClass[] ReadCarByType(string type = "Compact")
        {
            List<CarClass> result = new List<CarClass>();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"SELECT * FROM cars WHERE type = @type";
                command.Parameters.AddWithValue("@type", type);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new CarClass(id: reader.GetInt32(0),
                                                make: reader.GetString(2),
                                                model: reader.GetString(3),
                                                pricePerDay: reader.GetInt32(4),
                                                passengers: reader.GetInt32(5),
                                                color: reader.GetString(6),
                                                availability: reader.GetString(7)));
                    }
                }

                connection.Close();
            }
            return result.ToArray();
        }

        //Add New Car
        public void CreateCar(CarClass newcar)
        {
            //Adds a new car to the db
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO cars (type, make, model, price_per_day, number_of_passengers, color, avail) VALUES (@type, @make, @model, @price, @numOfPass, @color, @avail)";

                command.Parameters.AddWithValue("@type", newcar.Type);
                command.Parameters.AddWithValue("@make", newcar.Make);
                command.Parameters.AddWithValue("@model", newcar.Model);
                command.Parameters.AddWithValue("@price", newcar.PricePerDay);
                command.Parameters.AddWithValue("@numOfPass", newcar.Passengers);
                command.Parameters.AddWithValue("@color", newcar.Color);
                command.Parameters.AddWithValue("@avail", newcar.Availability);

                try
                {
                    int count = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                connection.Close();
            }
        }
    }
}
