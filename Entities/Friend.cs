using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace FriendsDomain.Entities
{
    [DataContract(Namespace = "friends.net/friendsDomain/2016/01")]
    public class Friend
    {
        [DataMember(Order = 0)]
        public string Name { get; set; }

        [DataMember(Order = 1)]
        public string Address { get; set; }

        [DataMember(Order = 2)]
        public string Email { get; set; }

        [DataMember(Order = 3)]
        public Guid FriendGuid { get; set; }

    }
}