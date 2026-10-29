using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarServiceConsole.Service
{
    internal class Car
    {
        public static void Add()
        {
            using var connection = new NpgsqlConnection(Program.CONNECTION_STR);

            try
            {
                int selected_client;

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("==========ADD=NEW=CAR==========\n\nclients:\n");
                    List<int> clients = Client.GetAll();

                    Console.Write("  -1. EXIT\n\nclient << ");

                    try
                    {
                        selected_client = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.Clear();
                        Console.WriteLine("Error: Invalid Input!");
                        Console.ReadLine();
                        continue;
                    }

                    if (selected_client == -1)
                    {
                        return;
                    }
                    
                    if (clients.Contains(selected_client))
                    {
                        break;
                    }

                    Console.Clear();
                    Console.WriteLine("Error: No such client!");
                    Console.ReadLine();
                }

                connection.Open();

                string sql = """
                    INSERT INTO vehicles
                    (customer_id, make, model, production_year, plate_number)
                    VALUES
                    (@customer_id, @make, @model, @production_year, @plate_number);
                """;

                using var command = new NpgsqlCommand(sql, connection);

                string[] columns = new string[] { "customer_id", "make", "model", "production_year", "plate_number" };

                Console.Clear();
                Console.WriteLine("[================ADDING=NEW=CAR================]\n");

                foreach (string i in columns)
                {
                    if (i == "customer_id")
                    {
                        command.Parameters.AddWithValue(i, selected_client);
                        Console.WriteLine("  Customer id >> " + selected_client);
                        continue;
                    }
                    
                    if (i == "production_year")
                    {
                        while (true)
                        {
                            try
                            {
                                Console.Write("  Production Year << ");
                                int _user_inp = Convert.ToInt32(Console.ReadLine());

                                if (_user_inp >= 1950 &&  _user_inp < 2100)
                                {
                                    command.Parameters.AddWithValue(i, _user_inp);
                                    break;
                                }
                                Console.WriteLine("  Invalid year!");
                            }
                            catch
                            {
                                Console.WriteLine("  Invalid input!");
                            }
                        }

                        continue;
                    }

                    try
                    {
                        Console.Write($"  {i.ToString()} << ");
                        string _user_inp = Console.ReadLine();

                        if (_user_inp != "")
                        {
                            command.Parameters.AddWithValue(i, _user_inp);
                            continue;
                        }
                        Console.WriteLine("  Invalid string!");
                    }
                    catch
                    {
                        Console.WriteLine("  Invalid input!");
                    }
                }

                int affectedRows = command.ExecuteNonQuery();
                Console.Clear();
                Console.WriteLine($"Added new car: {affectedRows}");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Error: " + ex.ToString());
                Console.ReadLine();
            }
        }
    }
}
