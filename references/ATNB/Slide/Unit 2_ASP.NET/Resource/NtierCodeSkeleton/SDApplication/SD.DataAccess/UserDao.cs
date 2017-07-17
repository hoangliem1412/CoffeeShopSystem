using System;
using System.Data;
using System.Data.SqlClient;
using SD.Commons.Constants;
using SD.Commons.Helpers;
using SD.Entities;

namespace SD.DataAccess
{
 /// <summary>
 /// Example code
 /// Create by HAIPT
 /// </summary>
    public class UserDao
    {
        private static User ExtractRawData(IDataRecord dataReader)
        {
            return new User
                       {
                           Account = dataReader["Account"].ToString(),
                           Email = dataReader["Email"].ToString(),
                           Password = dataReader["Password"].ToString(),
                           Role = dataReader["Role"].ToString(),
                           Id = Convert.ToInt32(dataReader["Id"])
                       };
        }

        public User GetUser(string userName, string password)
        {
            try
            {
                using (IDataReader reader = SqlHelper.ExecuteReader(DBSchemas.ProcedureStores.GET_USER))
                {
                    User result = ExtractRawData(reader);
                    return result;
                }
            }
            catch (SqlException ex)
            {
                // Write to log ... here
                Console.WriteLine(ex.StackTrace);

                return null;
            }
        }

       
    }
}