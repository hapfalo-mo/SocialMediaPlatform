using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace LarionProject_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeActionController : ControllerBase
    {
        private readonly ILikeActionService _likeActionService;
        public LikeActionController(ILikeActionService likeActionService)
        {
            _likeActionService = likeActionService;
        }
        /// <summary>
        /// Like and Unlike Post
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost("like-post/{postId}/{userId}")]
        public async Task<IActionResult> LikePostAction (int postId , int userId)
        {
            var rs = await _likeActionService.LikePostAction(postId, userId);
            return Ok(new { Message = "Thành công" });
        }
    }
}
