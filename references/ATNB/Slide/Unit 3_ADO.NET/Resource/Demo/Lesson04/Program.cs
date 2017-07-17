using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Lesson04
{
    class ReaderDemo
    {
        static void Main()
        {
            ReaderDemo rd = new ReaderDemo();
            rd.SimpleRead();
            Console.ReadLine();
        }

        public void SimpleRead()
        {
            // declare the SqlDataReader, which is used in
            // both the try block and the finally block
            SqlDataReader dataReader = null;

            // create a connection object
            SqlConnection connection = new SqlConnection("Data Source=(local);Initial Catalog=Northwind;Integrated Security=SSPI");

            // create a command object
            SqlCommand cmd = new SqlCommand("select * from Customers", connection);

            try
            {
                // open the connection
                connection.Open();

                // 1.  get an instance of the SqlDataReader
                dataReader = cmd.ExecuteReader();

                // print a set of column headers
                Console.WriteLine("Contact Name             City                Company Name");
                Console.WriteLine("------------             ------------        ------------");

                // 2.  print necessary columns of each record
                if (dataReader != null)
                {
                    while (dataReader.Read())
                    {
                        // get the results of each column
                        string contact = (string) dataReader["ContactName"];
                        string company = (string) dataReader["CompanyName"];
                        string city = (string) dataReader["City"];

                        // print out the results
                        Console.Write("{0,-25}", contact);
                        Console.Write("{0,-20}", city);
                        Console.Write("{0,-25}", company);
                        Console.WriteLine();
                    }
                }
            }
            finally
            {
                // 3. close the reader
                if (dataReader != null)
                {
                    dataReader.Close();
                }

                // close the connection
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
    }
}
