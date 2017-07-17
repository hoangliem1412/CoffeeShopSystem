using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Lesson03
{

    /// <summary>
    /// Demonstrates how to work with SqlCommand objects
    /// </summary>
    class SqlCommandDemo
    {
        SqlConnection connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlCommandDemo"/> class.
        /// </summary>
        public SqlCommandDemo()
        {
            // Instantiate the connection
            connection = new SqlConnection("Data Source=(local);Initial Catalog=Northwind;Integrated Security=SSPI");
        }

        // call methods that demo SqlCommand capabilities
        static void Main()
        {
            SqlCommandDemo commandDemo = new SqlCommandDemo();

            Console.WriteLine();
            Console.WriteLine("Categories Before Insert");
            Console.WriteLine("------------------------");

            // use ExecuteReader method
            commandDemo.ReadData();

            // use ExecuteNonQuery method for Insert
            commandDemo.Insertdata();
            Console.WriteLine();
            Console.WriteLine("Categories After Insert");
            Console.WriteLine("------------------------------");

            commandDemo.ReadData();

            // use ExecuteNonQuery method for Update
            commandDemo.UpdateData();

            Console.WriteLine();
            Console.WriteLine("Categories After Update");
            Console.WriteLine("------------------------------");

            commandDemo.ReadData();

            // use ExecuteNonQuery method for Delete
            commandDemo.DeleteData();

            Console.WriteLine();
            Console.WriteLine("Categories After Delete");
            Console.WriteLine("------------------------------");

            commandDemo.ReadData();

            // use ExecuteScalar method
            int numberOfRecords = commandDemo.GetNumberOfRecords();

            Console.WriteLine();
            Console.WriteLine("Number of Records: {0}", numberOfRecords);

            Console.ReadLine();
        }

        /// <summary>
        /// use ExecuteReader method
        /// </summary>
        public void ReadData()
        {
            SqlDataReader dataReader = null;

            try
            {
                // Open the connection
                connection.Open();

                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand("select CategoryName from Categories", connection);

                // 2. Call Execute reader to get query results
                dataReader = cmd.ExecuteReader();

                // print the CategoryName of each record
                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        Console.WriteLine(dataReader[0]);
                    }
                }
            }
            finally
            {
                // close the reader
                if (dataReader != null)
                {
                    dataReader.Close();
                }

                // Close the connection
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// use ExecuteNonQuery method for Insert
        /// </summary>
        public void Insertdata()
        {
            try
            {
                // Open the connection
                connection.Open();

                // prepare command string
                string insertString = @"
                 INSERT INTO CATEGORIES
                 (CATEGORYNAME, DESCRIPTION)
                 VALUES ('Miscellaneous', 'Whatever doesn''t fit elsewhere')";

                // 1. Instantiate a new command with a query and connection
                SqlCommand cmd = new SqlCommand(insertString, connection);

                // 2. Call ExecuteNonQuery to send command
                cmd.ExecuteNonQuery();
            }
            finally
            {
                // Close the connection
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// use ExecuteNonQuery method for Update
        /// </summary>
        public void UpdateData()
        {
            try
            {
                // Open the connection
                connection.Open();

                // prepare command string
                string updateString = @"
                 UPDATE CATEGORIES
                 SET CATEGORYNAME = 'Other'
                 WHERE CATEGORYNAME = 'Miscellaneous'";

                // 1. Instantiate a new command with command text only
                SqlCommand cmd = new SqlCommand(updateString);

                // 2. Set the Connection property
                cmd.Connection = connection;

                // 3. Call ExecuteNonQuery to send command
                cmd.ExecuteNonQuery();
            }
            finally
            {
                // Close the connection
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// use ExecuteNonQuery method for Delete
        /// </summary>
        public void DeleteData()
        {
            try
            {
                // Open the connection
                connection.Open();

                // prepare command string
                string deleteString = @"
                 DELETE FROM CATEGORIES
                 WHERE CATEGORYNAME = 'Other'";

                // 1. Instantiate a new command
                SqlCommand cmd = new SqlCommand();

                // 2. Set the CommandText property
                cmd.CommandText = deleteString;

                // 3. Set the Connection property
                cmd.Connection = connection;

                // 4. Call ExecuteNonQuery to send command
                cmd.ExecuteNonQuery();
            }
            finally
            {
                // Close the connection
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// use ExecuteScalar method
        /// </summary>
        /// <returns>number of records</returns>
        public int GetNumberOfRecords()
        {
            int numberOfRecords = -1;

            try
            {
                // Open the connection
                connection.Open();

                // 1. Instantiate a new command
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM CATEGORIES", connection);

                // 2. Call ExecuteScalar to send command
                numberOfRecords = (int)cmd.ExecuteScalar();
            }
            finally
            {
                // Close the connection
                if (connection != null)
                {
                    connection.Close();
                }
            }
            return numberOfRecords;
        }
    }
}
