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
            using (var dbConnection = OpenConnection())
            using (var dbCommand = CreateCommand(dbConnection))
            {
                return dbCommand.PrepareStoredProcedure("[dbo].[GetFriends]")
                .ExecuteReaderForEach(r => new Friend
                {
                    Name = r.GetString("FriendName"),
                    Address = r.GetString("FriendAddress"),
                    Email = r.GetString("FriendEmail"),
                    FriendGuid = r.GetGuid("FriendGuid")
                }).ToList();
            }
        }
    }
}