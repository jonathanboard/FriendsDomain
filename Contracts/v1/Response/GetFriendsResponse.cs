using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using FriendsDomain.Entities;

namespace FriendsDomain.Contracts.v1.Response
{
    [DataContract(Namespace= "http://friends.net/friendsDomain/2016/01")]
    public class GetFriendsResponse
    {
        [DataMember(Order = 0, Name = "Friends")]
        public List<Friend> Friends { get; set; }

    }
}