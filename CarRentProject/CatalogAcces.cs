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

        public CarClass[] ReadCarByMake(string make = "BMW")
        {
            List<CarClass> result = new List<CarClass>();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"SELECT * FROM cars WHERE make = @make";
                command.Parameters.AddWithValue("@make", make);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new CarClass(id: reader.GetInt32(0),
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
        public void CreateCar(CarClass car)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO cars (type, make, model, 
                price_per_day, number_of_passengers, color, avail) 
                VALUES (@type, @make, @model, @price, @numOfPass, @color, @avail)";

                command.Parameters.AddWithValue("@type", car.Type);
                command.Parameters.AddWithValue("@make", car.Make);
                command.Parameters.AddWithValue("@model", car.Model);
                command.Parameters.AddWithValue("@price", car.PricePerDay);
                command.Parameters.AddWithValue("@numOfPass", car.Passengers);
                command.Parameters.AddWithValue("@color", car.Color);
                command.Parameters.AddWithValue("@avail", car.Availability);

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
        //Update a Car
        public void UpdateCar(CarClass car)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"UPDATE cars 
                SET 
                type = @type, make = @make, model = @model, price_per_day = @price, 
                number_of_passengers = @numOfPass, color = @color, avail = @avail
                WHERE id = @id";

                command.Parameters.AddWithValue("@id", car.Id);
                command.Parameters.AddWithValue("@type", car.Type);
                command.Parameters.AddWithValue("@make", car.Make);
                command.Parameters.AddWithValue("@model", car.Model);
                command.Parameters.AddWithValue("@price", car.PricePerDay);
                command.Parameters.AddWithValue("@numOfPass", car.Passengers);
                command.Parameters.AddWithValue("@color", car.Color);
                command.Parameters.AddWithValue("@avail", car.Availability);

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
       

        //Delete a Car
        public void DeleteCar(CarClass car)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"DELETE FROM cars
                                      WHERE id = @id";

                command.Parameters.AddWithValue("@id", car.Id);

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
        //Rent a Car
        public void RentCar(CarClass car)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    @"UPDATE cars SET avail = CASE avail WHEN @true THEN @false ELSE @true END WHERE id = @id";

                command.Parameters.AddWithValue("@id", car.Id);
                command.Parameters.AddWithValue("@true", "true");
                command.Parameters.AddWithValue("@false", "false");

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
