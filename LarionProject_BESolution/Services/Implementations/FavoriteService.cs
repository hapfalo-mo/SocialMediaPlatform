using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    public class FavoriteService : BaseService, IFavoriteService
    {
        public FavoriteService(LarionDatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        /*---------Create New Favorite---------*/

        public async Task<IActionResult> CreateNewFavorite(FavoriteCreateDTO favoriteCreateDTO)
        {
            var favorite = _mapper.Map<Favorite>(favoriteCreateDTO);
            favorite.CreateAt =DateTime.Now;
            favorite.Status = (Int32) FavoriteEnum.Active;
            favorite.CreateBy = favoriteCreateDTO.CreateBy;
            _context.Favorites.Add(favorite);
            await _context.SaveChangesAsync();
            return new OkObjectResult(favorite);
        }

        public async Task<IActionResult> AddFavoritebyUser(int userId, List<int> favoriteId)
        {
            foreach (var item in favoriteId)
            {
                var userFavorite = new UserFavorite()
                {
                    UserId = userId,
                    FavoriteId = item,
                    CreateAt = DateTime.Now,
                };
                _context.UserFavorites.Add(userFavorite);
            }
            await _context.SaveChangesAsync();
            return new OkObjectResult("Add favorite success");
        }
    }
}
