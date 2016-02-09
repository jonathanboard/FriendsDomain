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

        public static IEnumerable<T> ExecuteReaderForEach<T>(this SqlCommand command, Func<IDataRecord, T> lambda)
        {
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return lambda(reader);                
            }
        }

        public static string GetString(this IDataRecord record, string key)
        {
            return (string)record[key];
        }

        public static int GetInt(this IDataRecord record, string key)
        {
            return (int)record[key];
        }

        public static Guid GetGuid(this IDataRecord record, string key)
        {
            return (Guid)record[key];
        }
    }
}