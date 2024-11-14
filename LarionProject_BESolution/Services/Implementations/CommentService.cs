using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class CommentService : BaseService, ICommentService
    {
        public CommentService(LarionDatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        // Create Comment
        public async Task<IActionResult> createNewComment(CommentDTO commentDTO)
        {
            try
            {
                var comment = _mapper.Map<Comment>(commentDTO);
                comment.CreateAt = DateTime.Now;
                comment.CreateBy = commentDTO.CreateBy;
                comment.ParrentId = commentDTO.ParrentId;
                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
                return new StatusCodeResult(201);

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        // Get Comment By PostId 
        public async Task<ActionResult<IEnumerable<CommentResponseDTO>>> getAllComment(int postId)
        {
            try
            {
                var comments = await _context.Comments
                    .Include(x => x.CreateByNavigation)
                    .Include(x => x.InverseParrent)
                    .ThenInclude(x => x.CreateByNavigation)
                    .Where(x => x.PostId == postId && x.ParrentId == null).ToListAsync();
                if (comments.Count == 0)
                {
                    return new List<CommentResponseDTO>();
                }
                var result = comments.Select(x => getSubComment(x)).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*--------- Internal Site ---------*/
        // Get Sub Comment By CommentId
        private CommentResponseDTO getSubComment(Comment comment)
        {
            try
            {
                var commentResponseDTO = _mapper.Map<CommentResponseDTO>(comment);
                commentResponseDTO.UserName = comment.CreateByNavigation.Username;
                commentResponseDTO.UserAvatar = comment.CreateByNavigation.AvatarUrl;

                // Get All Children in Children Comment 
                var subComments = _context.Comments
               .Where(x => x.ParrentId == comment.CommentId)
               .Include(x => x.CreateByNavigation)
               .ToList();
                // Get All Children Comment
                commentResponseDTO.SubComments = subComments.Select(x => getSubComment(x)).ToList();
                return commentResponseDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
