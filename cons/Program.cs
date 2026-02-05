// See https://aka.ms/new-console-template for more information
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System.Data;

namespace cons {
    
    class Program {
        static void Main(string[] args) {
            string connectionString = "server=host.docker.internal;port=3333;uid=root;pwd=a;database=FlightData";

            using (var connection = new MySqlConnection(connectionString)) {
                connection.Open();

                printQuery("select * from deltas limit 1;",connection);
                printQuery("select * from southwests limit 1;",connection);
            }            
        }

        static void printQuery(string query, MySqlConnection con) {
            Console.WriteLine(query + "\n------------------------------------");

            using (var q = new MySqlCommand(query,con))
            using (var r = q.ExecuteReader())
            {
                while (r.Read()) {
                    int i = 0;
                    while (i < r.FieldCount) {
                        Console.Write(r.GetValue(i));
                        i++;
                    }
                    Console.WriteLine("\n");
                }
            }
        }
    }
}
