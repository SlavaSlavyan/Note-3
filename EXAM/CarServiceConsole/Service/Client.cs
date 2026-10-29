using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CarServiceConsole.Service
{
    internal class Client
    {
        public static List<int> GetAll()
        {
            using var connection = new NpgsqlConnection(Program.CONNECTION_STR);

            try
            {
                connection.Open();

                string sql = "SELECT customer_id, first_name\r\nFROM customers;";

                using var command = new Npgsql.NpgsqlCommand(sql, connection);

                using var reader = command.ExecuteReader();

                List<int> clients = new List<int>();

                while (reader.Read())
                {
                    int client = reader.GetInt32(0);
                    clients.Add(client);
                    Console.WriteLine($"  {client}. {reader.GetString(1)}");
                }

                reader.Close();

                return clients;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<int>();
            }

        }
    }
}
