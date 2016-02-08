using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using FriendsDomain.Entities;
using System.Configuration;

namespace FriendsDomain.DataAccess
{
    public class FriendsSqlClient : SqlClientBase, IFriendsSqlClient
    {
        public FriendsSqlClient() 
            : this(GetConnectionString("FriendsDatabase"))
        {

        }

        

        public FriendsSqlClient(string connectionString)
            :base(connectionString)
        {

        }


        public List<Friend> GetFriends()
        {
            var returnValue = new List<Friend>();
            try
            {
                using (var dbConnection = OpenConnection())
                using (var dbCommand = CreateCommand(dbConnection)) // new SqlCommand("[dbo].[GetFriends]", dbConnection))
                {
                    dbCommand.PrepareStoredProcedure("[dbo].[GetFriends]")
                    .ExecuteReaderForEach(r => new Friend
                     {
                        Name = (string)r["FriendName"],
                        Address = (string)r["FriendAddress"],
                        Email = (string)r["FriendEmail"],
                        FriendGuid = (Guid)r["FriendGuid"]
                     });


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