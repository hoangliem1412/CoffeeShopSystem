using System.Data;
using System.Data.SqlClient;
using NUnit.Framework;
namespace LoginDemo.DataAccess
{


    public class UserDao
    {
        private const string DB_CONNECTION = @"Data Source=.\sqlexpress;Initial Catalog=TEST;Integrated Security=True";
        public bool IsValidLogin(string userName, string password)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            try
            {
                con = new SqlConnection(DB_CONNECTION);
                con.Open();
                string cmdtext = string.Format("SELECT * FROM [Users]" +
                    " WHERE [UserName]='{0}' AND [Password]='{1}' ",
                                               userName, password);
                cmd = new SqlCommand(cmdtext);
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                reader = cmd.ExecuteReader();
                if (reader != null) return reader.HasRows;
                return true;
            }
            catch (SqlException)
            {return false;}
            finally
            {
                if (reader != null) reader.Dispose();
                if (cmd != null) cmd.Dispose();
                if (con != null) con.Dispose();
            }
        }
    }
}