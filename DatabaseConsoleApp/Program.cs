using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Create connection */ 
            string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\student.SL228-03\\Source\\Repos\\DatabaseConsoleApp\\DatabaseConsoleApp\\DatabaseForApp.mdf;Integrated Security=True";

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connString;            conn.Open();            /* SELECT */
            SqlCommand command = new SqlCommand("SELECT * FROM Phones", conn);

            /* INSERT */
            SqlCommand command2 = new SqlCommand("INSERT INTO Phones(Name,Surname,Number) VALUES('Katarzyna', 'Kowalska', 222000111)", conn);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                // while there is another record present
                while (reader.Read())
                {
                    // write the data on to the screen
                    Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3}",
                    // call the objects from their index
                    reader[0], reader[1], reader[2], reader[3]));
                }
            }


            /* Execution of SQL statements */
            command.ExecuteNonQuery();            command2.ExecuteNonQuery();

            /* Close the connection */
            conn.Close();
        }
    }
}
