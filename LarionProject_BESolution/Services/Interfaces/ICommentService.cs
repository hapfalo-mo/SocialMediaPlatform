using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICommentService
    {
        Task<IActionResult> createNewComment(CommentDTO commentDTO);
        Task<ActionResult<IEnumerable<CommentResponseDTO>>> getAllComment(int postId);
    }
}
