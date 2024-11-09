using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Models.EnityEnum.ObjectEnum;

namespace Services.Implementations
{
    public class PostService : BaseService, IPostService
    {
        /*---------Config Site--------*/
        public PostService(LarionDatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        /*---------Code Site---------*/

        // Add New Post
        public async Task<IActionResult> CreateNewPost(PostCreateDTO postDTO)
        {
            try
            {
                var post = _mapper.Map<Post>(postDTO);
                post.CreateAt = DateTime.Now;
                post.Status = (Int32)PostEnum.Active;
                await _context.AddAsync(post);
                await _context.SaveChangesAsync();
                return new StatusCodeResult(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return new ObjectResult("An error occurred: " + ex.Message) { StatusCode = 500 };
            }
        }
        // Get Post Result 
        public async Task<ActionResult<PostResponseDTO>> GetPostByPostID (int postId)
        {
            try
            {
                var postResponse = _context.Posts.FirstOrDefault(p => p.PostId == postId);
                var user = _context.Users.FirstOrDefault(u => u.UserId == postResponse.UserId);
                var result = _mapper.Map<PostResponseDTO>(postResponse);
                result.TotalLike = await _context.Likes.CountAsync( l => l.PostId == postId);
                result.TotalComment = await _context.Comments.CountAsync(c => c.ParrentId == postId);
                result.FullName = user.FullName;
                result.Avatar_Url = user.AvatarUrl;
                return result;
            } catch(Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }

        // Get All Posts
        public async Task<ActionResult<IEnumerable<PostResponseDTO>>> GetAllPosts()
        {
            try
            {
                var posts = await _context.Posts.ToListAsync();
                var result = new List<PostResponseDTO>();
                foreach (var post in posts)
                {
                    var user = _context.Users.FirstOrDefault(u => u.UserId == post.UserId);
                    var postResponse = _mapper.Map<PostResponseDTO>(post);
                    postResponse.TotalLike = await _context.Likes.CountAsync(l => l.PostId == post.PostId);
                    postResponse.TotalComment = await _context.Comments.CountAsync(c => c.ParrentId == post.PostId);
                    postResponse.FullName = user.FullName;
                    postResponse.Avatar_Url = user.AvatarUrl;
                    result.Add(postResponse);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }   
    }
}