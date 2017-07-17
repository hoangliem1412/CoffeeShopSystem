using System;
using System.Data.SqlClient;

namespace Lesson02
{
    /// <summary>
    /// Refactor class
    /// </summary>
    class Refactor
    {
        //private const string connectionString = "Data Source=(local);Initial Catalog=Northwind;Integrated Security=SSPI";
        private const string connectionString = "Data Source=(local);Initial Catalog=Northwind;Integrated Security=SSPI";
        private const string selectFromCustomers = "SELECT * FROM CUSTOMERS";

        /// <summary>
        /// Mains the refactor.
        /// </summary>
        public static void MainRefactor()
        {
            // 1. Instantiate the connection

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // 2. Open the connection
                    connection.Open();

                    // 3. Pass the connection to a command object
                    using (SqlCommand command = new SqlCommand(selectFromCustomers, connection))
                    {
                        //
                        // 4. Use the connection
                        //

                        // get query results
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            // print the CustomerID of each record
                            if (dataReader != null)
                            {
                                while (dataReader.Read())
                                {
                                    Console.WriteLine(dataReader[0]);
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception exception)
            {
               Console.WriteLine(exception.Message);
            }
        }
    }
}
