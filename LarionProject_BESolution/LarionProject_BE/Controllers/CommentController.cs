using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Services.Interfaces;

namespace LarionProject_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // Create Comment 
        [HttpPost("create-comment")]
        public async Task<IActionResult> createNewComment([FromBody] CommentDTO commentDTO)
        {
            try
            {
                var rs = await _commentService.createNewComment(commentDTO);
                return rs;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get Comment By PostId 
        [HttpGet("get-comment-by-postId")]
        public async Task<ActionResult<IEnumerable<CommentResponseDTO>>> getAllComment(int postId)
        {
            try
            {
                var rs = await _commentService.getAllComment(postId);
                return rs;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
