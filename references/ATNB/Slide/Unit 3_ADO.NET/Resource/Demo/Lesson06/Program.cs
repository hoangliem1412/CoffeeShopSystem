using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Lesson06
{
    class ParamDemo
    {
        static void Main()
        {
            // conn and reader declared outside try
            // block for visibility in finally block
            SqlConnection connection = null;
            SqlDataReader dataReader = null;

            string inputCity = "London";

            try
            {
                // instantiate and open connection
                connection = new SqlConnection("Server=(local);DataBase=Northwind;Integrated Security=SSPI");
                connection.Open();

                // don't ever do this!
                //SqlCommand cmd = new SqlCommand("SELECT * FROM CUSTOMERS WHERE CITY = '" + inputCity + "'");

                // 1. declare command object with parameter
                SqlCommand cmd = new SqlCommand("SELECT * FROM CUSTOMERS WHERE CITY = @CITY", connection);

                // 2. define parameters used in command object
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@CITY";
                param.Value = inputCity;

                // 3. add new parameter to command object
                cmd.Parameters.Add(param);

                // get data stream
                dataReader = cmd.ExecuteReader();

                // write each record
                while (dataReader.Read())
                {
                    Console.WriteLine("{0}, {1}",
                        dataReader["CompanyName"],
                        dataReader["ContactName"]);
                }
            }
            finally
            {
                // close reader
                if (dataReader != null)
                {
                    dataReader.Close();
                }

                // close connection
                if (connection != null)
                {
                    connection.Close();
                }
            }

            Console.ReadLine();
        }
    }
}
