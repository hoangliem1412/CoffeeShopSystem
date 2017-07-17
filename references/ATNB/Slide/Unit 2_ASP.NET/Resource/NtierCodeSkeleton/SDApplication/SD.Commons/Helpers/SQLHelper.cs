using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace SD.Commons.Helpers
{
    public static class SqlHelper
    {
        /// <summary>
        /// Execute a stored-procedure and return IDataReader
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="parameterList"></param>
        /// <returns></returns>
        public static IDataReader ExecuteReader(string storedProcedureName, Collection<SqlParameter> parameterList)
        {
            IDataReader result = null;
            try
            {
                var conn = new SqlConnection(AppConfig.ConnectionString);
                conn.Open();

                var cmd = new SqlCommand(storedProcedureName, conn) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.Clear();

                if (parameterList != null)
                {
                    for (int i = 0; i < parameterList.Count; i++)
                    {
                        cmd.Parameters.Add(parameterList[i]);
                    }
                }

                result = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (parameterList != null)
                {
                    for (int i = 0; i < parameterList.Count; i++)
                    {
                        if (parameterList[i].Direction == ParameterDirection.Output ||
                            parameterList[i].Direction == ParameterDirection.InputOutput ||
                            parameterList[i].Direction == ParameterDirection.ReturnValue) // if is output
                        {
                            parameterList[i].Value = cmd.Parameters[parameterList[i].ParameterName].Value;
                        }
                    }
                }

                return result;
            }
            catch
            {
                if (result != null)
                {
                    result.Close();
                }
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <returns></returns>
        public static IDataReader ExecuteReader(string storedProcedureName)
        {
            IDataReader result = null;
            try
            {
                var conn = new SqlConnection(AppConfig.ConnectionString);
                conn.Open();

                var cmd = new SqlCommand(storedProcedureName, conn) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.Clear();

                result = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return result;
            }
            catch
            {
                if (result != null)
                {
                    result.Close();
                }
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="parameterList"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string storedProcedureName, Collection<SqlParameter> parameterList)
        {
            var conn = new SqlConnection(AppConfig.ConnectionString);
            conn.Open();

            var cmd = new SqlCommand(storedProcedureName, conn) {CommandType = CommandType.StoredProcedure};
            cmd.Parameters.Clear();

            if (parameterList != null)
            {
                for (int i = 0; i < parameterList.Count; i++)
                {
                    cmd.Parameters.Add(parameterList[i]);
                }
            }
            int result = cmd.ExecuteNonQuery();

            if (parameterList != null)
            {
                for (int i = 0; i < parameterList.Count; i++)
                {
                    if (parameterList[i].Direction == ParameterDirection.Output ||
                        parameterList[i].Direction == ParameterDirection.InputOutput ||
                        parameterList[i].Direction == ParameterDirection.ReturnValue)
                        parameterList[i].Value = cmd.Parameters[parameterList[i].ParameterName].Value;
                }
            }
            conn.Dispose();
            return result;
        }

        ///<summary>
        /// ExecuteNonQuery
        ///</summary>
        ///<param name="conn">Connection</param>
        ///<param name="transaction"></param>
        ///<param name="storedProcedureName">Store procedure</param>
        ///<param name="parameterList">List of parameters</param>
        ///<returns></returns>
        public static int ExecuteNonQuery(SqlConnection conn, SqlTransaction transaction, string storedProcedureName,
                                          Collection<SqlParameter> parameterList)
        {
            var cmd = new SqlCommand(storedProcedureName, conn, transaction) {CommandType = CommandType.StoredProcedure};
            cmd.Parameters.Clear();

            if (parameterList != null)
            {
                for (int i = 0; i < parameterList.Count; i++)
                {
                    cmd.Parameters.Add(parameterList[i]);
                }
            }
            int result = cmd.ExecuteNonQuery();

            if (parameterList != null)
            {
                for (int i = 0; i < parameterList.Count; i++)
                {
                    if (parameterList[i].Direction == ParameterDirection.Output ||
                        parameterList[i].Direction == ParameterDirection.InputOutput ||
                        parameterList[i].Direction == ParameterDirection.ReturnValue)
                        parameterList[i].Value = cmd.Parameters[parameterList[i].ParameterName].Value;
                }
            }
            return result;
        }

        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string storedProcedureName)
        {
            var conn = new SqlConnection(AppConfig.ConnectionString);
            conn.Open();

            var cmd = new SqlCommand(storedProcedureName, conn) {CommandType = CommandType.StoredProcedure};
            cmd.Parameters.Clear();
            int result = cmd.ExecuteNonQuery();
            conn.Dispose();
            return result;
        }

        ///<summary>
        ///</summary>
        ///<param name="conn">Connection</param>
        ///<param name="transaction"></param>
        ///<param name="storedProcedureName">Store procedure</param>
        ///<returns></returns>
        public static int ExecuteNonQuery(SqlConnection conn, SqlTransaction transaction, string storedProcedureName)
        {
            var cmd = new SqlCommand(storedProcedureName, conn, transaction) {CommandType = CommandType.StoredProcedure};
            cmd.Parameters.Clear();
            int result = cmd.ExecuteNonQuery();
            return result;
        }
    }
}