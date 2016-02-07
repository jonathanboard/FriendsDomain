using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using FriendsDomain.Entities;

namespace FriendsDomain.Contracts.v1.Request
{
    [DataContract(Namespace = "http://friends.net/friendsDomain/2016/01")]
    public class GetFriendsRequest
    {
        [DataMember()]
        public int Count { get; set; }
    }
}