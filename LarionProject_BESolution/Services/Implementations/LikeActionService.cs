using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class LikeActionService : BaseService, ILikeActionService
    {
        public LikeActionService(LarionDatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IActionResult> LikePostAction(int postId, int userId)
        {
            try
            {
                var exstingLike = await _context.Likes.FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId);
                if (exstingLike == null)
                {
                    var like = new Likes
                    {
                        PostId = postId,
                        UserId = userId
                    };
                    await _context.AddAsync(like);
                } else
                {
                    _context.Likes.Remove(exstingLike);
                }
                await _context.SaveChangesAsync();
                return new StatusCodeResult(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return new ObjectResult("An error occurred: " + ex.Message) { StatusCode = 500 };
            }
        }
    }
}
