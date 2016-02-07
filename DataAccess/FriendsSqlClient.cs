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
            return new List<Friend>();
        }
    }
}