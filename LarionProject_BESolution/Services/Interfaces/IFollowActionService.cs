using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IFollowActionService
    {
        Task <IActionResult> FollowAction (int followerId, int followedId);
        Task<bool> checkFollowed (int followerId, int followedId);
    }
}
