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
    public class FollowActionService : BaseService, IFollowActionService
    {   
        public FollowActionService (LarionDatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IActionResult> FollowAction(int followerId, int followedId)
        {
            try
            {
                var follow = await _context.Follows.FirstOrDefaultAsync(f => f.FollowingUserId == followerId && f.FollowedUserId == followedId);
                if (follow == null)
                {
                    var newFollow = new Follow
                    {
                        FollowingUserId = followerId,
                        FollowedUserId = followedId
                    };
                    await _context.AddAsync(newFollow);
                }
                else
                {
                    _context.Follows.Remove(follow);
                }
                await _context.SaveChangesAsync();
                return new StatusCodeResult(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return new ObjectResult("An error occurred: " + ex.Message) { StatusCode = 500 };
            }
        }

        public async Task<bool> checkFollowed(int followerId, int followedId)
        {
            try
            {
                bool rs = false;
                var follow = await _context.Follows.FirstOrDefaultAsync(f => f.FollowingUserId == followerId && f.FollowedUserId == followedId);
                if (follow != null)
                {
                    rs = true;
                }
                return rs;
            } catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }
    }
}
