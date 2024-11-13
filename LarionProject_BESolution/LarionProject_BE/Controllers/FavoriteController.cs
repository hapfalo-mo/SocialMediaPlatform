using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using Services.Interfaces;

namespace LarionProject_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;
        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }
        // Get All Favorite Unregistered
        [HttpGet("get-all-favorite-except/{registeredId}")]
        public async Task<ActionResult<IEnumerable<FavoriteAddNewDTO>>> getAllFavoriteUnregistered(int registeredId)
        {
            try
            {
                var favorites = await _favoriteService.getAllFavoriteUnregistered(registeredId);
                return Ok(favorites);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Add Favorite By List 
        [HttpPost("add-favorite-by-list")]
        public async Task<IActionResult> AddFavoriteByUser([FromQuery] int userid, [FromBody] List<int> favoriteId)
        {
            try
            {
                var rs = await _favoriteService.AddFavoritebyUser(userid, favoriteId);
                return rs;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get User Favorite By UserId
        [HttpGet("get-all-user-favorite/{userId}")]
        public async Task<ActionResult<IEnumerable<Favorite>>> getAllUserFavoriteByUserId(int userId)
        {
            try
            {
                var favorites = await _favoriteService.getAllUserFavoriteByUserId(userId);
                return Ok(favorites);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
