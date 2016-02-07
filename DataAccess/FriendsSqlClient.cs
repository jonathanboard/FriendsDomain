using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using FriendsDomain.Entities;

namespace FriendsDomain.DataAccess
{
    public class FriendsSqlClient : SqlClientBase, IFriendsSqlClient
    {
        public FriendsSqlClient() 
            : this(GetConnectionString())
        {

        }

        

        public FriendsSqlClient(string connectionString)
            :base(connectionString)
        {

        }


        private static string GetConnectionString()
        {
            return "hello";
        }

        public List<Friend> GetFriends()
        {
            var returnValue = new List<Friend>();
            try
            {
                using (var dbConnection = new SqlConnection("Data Source=DESKTOP-GO1EQNG; Initial Catalog=Friendly; Integrated Security=SSPI;"))
                using (var dbCommand = new SqlCommand("[dbo].[GetFriends]", dbConnection))
                {
                    dbConnection.Open();
                    dbCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    var reader = dbCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var name = reader["FriendName"];
                        var address = reader["FriendAddress"];
                        var email = reader["FriendEmail"];
                        var friendGuid = reader["FriendGuid"];
                        var team = reader["TeamName"];

                        returnValue.Add(new Friend { Name = (string)name, Address = (string)address, Email = (string)email, FriendGuid = (Guid)friendGuid });
                    }
                }
            }
            finally
            {
                
            }
                return returnValue;
        }
    }
}