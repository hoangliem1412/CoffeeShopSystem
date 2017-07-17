using System;
using System.Data.SqlClient;

namespace Lesson02
{
    /// <summary>
    /// Demonstrates how to work with SqlConnection objects
    /// </summary>
    class SqlConnectionDemo
    {
        //private const string connectionString = "Data Source=(local);Initial Catalog=Northwind;Integrated Security=SSPI";
        private const string connectionString = "Data Source=(local);Initial Catalog=Northwind;Integrated Security=SSPI";
        private const string selectFromCustomers = "SELECT * FROM CUSTOMERS";

        /// <summary>
        /// Mains this instance.
        /// </summary>
        static void Main()
        {
            // 1. Instantiate the connection
            SqlConnection connection = new SqlConnection(connectionString);

            SqlDataReader dataReader = null;

            try
            {
                // 2. Open the connection
                connection.Open();

                // 3. Pass the connection to a command object
                SqlCommand command = new SqlCommand(selectFromCustomers, connection);


                //
                // 4. Use the connection
                //

                // get query results
                dataReader = command.ExecuteReader();

                // print the CustomerID of each record
                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        Console.WriteLine(dataReader[0]);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                // close the reader
                if (dataReader != null)
                {
                    dataReader.Close();
                }

                // 5. Close the connection
                if (connection != null)
                {
                    connection.Close();
                }

                Console.ReadLine();
            }
        }
    }
}
