using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace LarionProject_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowActionController : ControllerBase
    {
        private readonly IFollowActionService _followActionService;
        public FollowActionController(IFollowActionService followActionService)
        {
            _followActionService = followActionService;
        }

        [HttpPost("follow-action/{followerId}/{followedId}")]
        public async Task<IActionResult> FollowAction(int followerId, int followedId)
        {
            var rs = await _followActionService.FollowAction(followerId, followedId);
            return Ok(new { Message = "Thành công" });
        }

        [HttpGet("check-followed/{followerId}/{followedId}")]
        public async Task<IActionResult> checkFollowed(int followerId, int followedId)
        {
            var rs = await _followActionService.checkFollowed(followerId, followedId);
            if (rs == true)
            {
                return Ok(new { Message = "Đã theo dõi", Data = "Đã theo dõi" });
            }
            else
            {
                return NotFound(new { Message = "Chưa theo dõi", Data = "Chưa theo dõi" });
            }
        }
    }
}
