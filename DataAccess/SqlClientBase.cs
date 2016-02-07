using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace FriendsDomain.DataAccess
{
    public class SqlClientBase
    {
        private readonly string _connectionString;

        public SqlClientBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        SqlConnection OpenConnection()
        {
            var connection =  new SqlConnection(_connectionString);
            return connection;
        }

        private static SqlCommand CreateCommand(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            return command;
        }

        

    }
}