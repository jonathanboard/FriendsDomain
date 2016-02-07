using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;
using FriendsDomain.Contracts.v1.Request;
using FriendsDomain.Contracts.v1.Response;

namespace FriendsDomain.Contracts.v1.Service
{
    [ServiceContract(Namespace = "http://friends.net/friendsService/2016/01", Name = "FriendService")]
    public interface IFriendsService
    {
        [OperationContract()]
        GetFriendsResponse GetFriends(GetFriendsRequest request);
    }
}
