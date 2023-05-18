
using System;
using MySql.Data.MySqlClient;
namespace ConexionDbCSharp
{
    class Program
    {
        static string connectionString = "server=localhost; port=3306; uid=root;" +
                                         "pwd=1allahuakbar123; database=pruebaasp; sslMode=none;";

        static MySqlConnection connection = new MySqlConnection(connectionString);

        public static void Main(string[] args)
        {

            Console.WriteLine("Connectado ");

            using (connection)
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection is: " + connection.State.ToString() + " " + Environment.NewLine);

                    MySqlCommand command = connection.CreateCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select * from usuario";

                    MySqlDataReader reader = command.ExecuteReader();

                    var data = "[id]\t[nombre]\t[rol]" + Environment.NewLine;

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            data += reader.GetInt32(0) + "\t" + reader.GetString(1) + "\t" + reader.GetBoolean(2) + Environment.NewLine;
                        }
                        Console.WriteLine(data);
                    }
                    else
                    {
                        Console.WriteLine("--Data Empty --");
                    }


                    connection.Close();
                    Console.WriteLine("Connection is " + connection.State.ToString() + " " + Environment.NewLine);
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    Console.WriteLine("Error " + ex.Message.ToString());
                }
                finally
                {
                    Console.WriteLine("Press the key to exit...");
                    Console.ReadKey();
                }
            }

        }

    }
}