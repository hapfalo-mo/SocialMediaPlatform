using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPostService
    {
        Task<IActionResult> CreateNewPost(PostCreateDTO postDTO);
        Task<ActionResult<PostResponseDTO>> GetPostByPostID(int postId);
        Task<ActionResult<IEnumerable<PostResponseDTO>>> GetAllPosts();
    }
}
