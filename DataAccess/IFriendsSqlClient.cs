using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendsDomain.Entities;

namespace FriendsDomain.DataAccess
{
    public interface IFriendsSqlClient
    {
        List<Friend> GetFriends();
    }
}
