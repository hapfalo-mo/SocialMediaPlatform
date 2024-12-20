﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core;
using Models.DTO;
using Services.Interfaces;

namespace LarionProject_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        /// <summary>
        ///  Create New Post
        /// </summary>
        /// <param name="postDTO"></param>
        /// <returns></returns>
        [HttpPost("create-post")]
        public async Task<IActionResult> CreateNewPost (PostCreateDTO postDTO)
        {
            var rs = await _postService.CreateNewPost(postDTO);
            if (rs is StatusCodeResult result && result.StatusCode == 201)
            {
                return Ok(new { Message = "Tạo thành công" });
            }
            else
            {
                return BadRequest(new { Message = "Tạo thất bại" });
            }
        }

        /// <summary>
        ///  Get Post By Post ID
        /// </summary>
        /// <param name="postDTO"></param>
        /// <returns></returns>
        [HttpGet("get-post-by-id/{postId}")]
        public async Task<ActionResult<PostResponseDTO>> getPostByPostID (int postId)
        {
            var result = await _postService.GetPostByPostID(postId);
            return Ok(new {PostResponseDTO = result });
        }

        /// <summary>
        ///  Get All  Post
        /// </summary>
        /// <param name="postDTO"></param>
        /// <returns></returns>
        [HttpGet("get-all-post")]
        public async Task<ActionResult<IEnumerable<PostResponseDTO>>> GetAllPosts()
        {
            var result = await _postService.GetAllPosts();
            return Ok(new { PostResponseDTO = result });
        }

        /// <summary>
        /// Check Like or Unlike 
        /// </summary>
        [HttpGet("check-like-post/{postId}/{userId}")]
        public async Task<bool> checkLikeOrUnlike (int postId, int userId)
        {
            try
            {
                var result =  await _postService.CheckIsLikedPost(userId, postId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
