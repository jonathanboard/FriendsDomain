using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FriendsDomain.Contracts.v1.Request;
using FriendsDomain.Contracts.v1.Response;
using FriendsDomain.DataAccess;
using FriendsDomain.Contracts.v1.Service;
using System.ServiceModel;

namespace FriendsDomain.Core.v1
{
    [ServiceBehavior(Namespace = "http://friends.net/friendsDomain/2016/01")]
    public class FriendsService : IFriendsService
    {
        private readonly IFriendsSqlClient _friendSqlClient; 
        public FriendsService(IFriendsSqlClient friendSqlClient)
        {
            _friendSqlClient = friendSqlClient;
        }

        public FriendsService() : this (new FriendsSqlClient())
        {

        }

        public GetFriendsResponse GetFriends(GetFriendsRequest request)
        {
            return new GetFriendsResponse();
        }
    }
}