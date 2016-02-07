using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace FriendsDomain.Entities
{
    [DataContract(Namespace = "friends.net/friendsDomain/2016/01")]
    public class Team
    {
        [DataMember()]
        public string Name { get; set; }
    }
}