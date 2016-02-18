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

        public static SqlCommand WithParameter(this SqlCommand command, string parameterName, SqlDbType parameterType, object parameterValue)
        {
            var sqlParamater = GetParameter(parameterName, parameterType);

            SetParamaterValue(ref sqlParamater, parameterType, parameterValue);
           
            return command;            
        }

        public static SqlCommand WithOutputParameter(this SqlCommand command, string parameterName, SqlDbType parameterType, object parameterValue)
        {
            var sqlParamater = GetParameter(parameterName, parameterType);
            sqlParamater.Direction = ParameterDirection.Output;

            SetParamaterValue(ref sqlParamater, parameterType, parameterValue);

            return command;
        }

        private static SqlParameter GetParameter(string parameterName, SqlDbType parameterType)
        {
            return new SqlParameter(parameterName, parameterType);
        }

        private static void SetParamaterValue(ref SqlParameter sqlParameter, SqlDbType parameterType, object parameterValue)
        {
            switch (parameterType)
            {
                case SqlDbType.BigInt:
                    sqlParameter.Value = (long)parameterValue;
                    break;
                case SqlDbType.Binary:
                case SqlDbType.Bit:
                    sqlParameter.Value = (bool)parameterValue;
                    break;
                case SqlDbType.Char:
                case SqlDbType.NVarChar:
                case SqlDbType.NText:
                case SqlDbType.NChar:
                case SqlDbType.Text:
                case SqlDbType.VarChar:
                    sqlParameter.Value = (string)parameterValue;
                    break;
                case SqlDbType.Date:
                case SqlDbType.DateTime:
                case SqlDbType.SmallDateTime:
                    sqlParameter.Value = (DateTime)parameterValue;
                    break;
                case SqlDbType.Decimal:
                case SqlDbType.Money:
                case SqlDbType.SmallMoney:
                    sqlParameter.Value = (decimal)parameterValue;
                    break;
                case SqlDbType.Float:
                    sqlParameter.Value = (double)parameterValue;
                    break;
                case SqlDbType.Int:
                    sqlParameter.Value = (int)parameterValue;
                    break;
                case SqlDbType.Real:
                    sqlParameter.Value = (float)parameterValue;
                    break;
                case SqlDbType.SmallInt:
                    sqlParameter.Value = (short)parameterValue;
                    break;
                case SqlDbType.UniqueIdentifier:
                    sqlParameter.Value = (Guid)parameterValue;
                    break;
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