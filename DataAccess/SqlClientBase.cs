using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace FriendsDomain.DataAccess
{
    public class SqlClientBase
    {
        private readonly string _connectionString;
        private SqlConnection _sqlConnection;
        private SqlCommand _sqlCommand;

        public SqlClientBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected SqlConnection OpenConnection()
        {
            var _sqlConnection =  new SqlConnection(_connectionString);
            
            return _sqlConnection;
        }

        protected SqlCommand CreateCommand(SqlConnection sqlConnection)
        {
            _sqlCommand = new SqlCommand();
            _sqlCommand.Connection = sqlConnection;
            _sqlCommand.Connection.Open();

            return _sqlCommand;
        }



        protected static string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }

    public static class SqlClientExension
    {
        public static SqlCommand PrepareStoredProcedure(this SqlCommand command, string procedureName)
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = procedureName;
            return command;
        }

        public static void ExecuteReaderForEach(this SqlCommand command, Func<IDataRecord, object> lambda)
        {           
            //this does nothing for now.
        }
    }
}