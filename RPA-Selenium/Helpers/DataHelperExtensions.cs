using System;
using System.Data;
using System.Data.SqlClient;

namespace RPAFramework.Helpers
{
    public static class DataHelperExtensions
    {
        public static SqlConnection DBConnect(this SqlConnection sqlConnection, string ConnectionString)
        {
            try
            {
                sqlConnection = new SqlConnection(ConnectionString);
                sqlConnection.Open();
                return sqlConnection;

            }
            catch (Exception e)
            {
                LogHelpers.Write($"Error: {e.Message}");
            }

            return null;
        }


        public static void DBClose(this SqlConnection sqlConnection)
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                LogHelpers.Write($"Error: {e.Message}");
            }
        }

        //Execution
        public static DataTable ExecuteQuery(this SqlConnection sqlConnection, string queryString)
        {
            DataSet dataSet;
            try
            {
                if (sqlConnection == null || ((sqlConnection != null &&
                                               (sqlConnection.State == ConnectionState.Closed ||
                                                sqlConnection.State == ConnectionState.Broken))))
                    sqlConnection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand(queryString, sqlConnection);
                dataAdapter.SelectCommand.CommandType = CommandType.Text;

                dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "table");
                sqlConnection.Close();
                return dataSet.Tables["table"];
            }
            catch (Exception e)
            {
                dataSet = null;
                sqlConnection.Close();
                LogHelpers.Write($"Error: {e.Message}");
                return null;
            }
            finally
            {
                sqlConnection.Close();
                dataSet = null;
            }
        }
    }
}
