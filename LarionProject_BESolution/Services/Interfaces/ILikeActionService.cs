using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ILikeActionService
    {
        Task<IActionResult> LikePostAction(int postId, int userId);
        /*Task<IActionResult> UnLikePost(int postId, int userId);*/
    }
}
