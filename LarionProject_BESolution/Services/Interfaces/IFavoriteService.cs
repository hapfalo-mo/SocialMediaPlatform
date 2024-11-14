using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IFavoriteService
    {
        Task<IActionResult> CreateNewFavorite(FavoriteCreateDTO favoriteCreateDTO);
        Task<ActionResult<IEnumerable<FavoriteAddNewDTO>>> getAllFavoriteUnregistered(int userId);
        Task<IActionResult> AddFavoritebyUser(int userId, List<int> favoriteId);
        Task<ActionResult<IEnumerable<Favorite>>> getAllUserFavoriteByUserId(int userId);
        Task<ActionResult<IEnumerable<Favorite>>> getAllFavorite();
    }
}
