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
            try
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
                return new StatusCodeResult(201);
            } catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        public async Task<ActionResult<IEnumerable<FavoriteAddNewDTO>>> getAllFavoriteUnregistered(int userId)
        {
            try
            {   
                var resultList = new List<FavoriteAddNewDTO>();
                var listFavorite = await _context.Favorites.Where(f => f.Status == (Int32)FavoriteEnum.Active && !_context.UserFavorites.Any(uf => uf.FavoriteId == f.FavoriteId && uf.UserId == userId)).ToListAsync();
                foreach (var item in listFavorite)
                {
                    FavoriteAddNewDTO favoriteAddNewDTO = new FavoriteAddNewDTO()
                    {
                        favoriteId = item.FavoriteId,
                        favoriteName = item.FavoriteName
                    };
                    resultList.Add(favoriteAddNewDTO);
                }
                return resultList;
            } catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public async Task<ActionResult<IEnumerable<Favorite>>> getAllUserFavoriteByUserId (int userId)
        {
            try
            {
                var listFavorite = await _context.Favorites.Where(f => f.Status == (Int32)FavoriteEnum.Active && _context.UserFavorites.Any(uf => uf.FavoriteId == f.FavoriteId && uf.UserId == userId)).ToListAsync();
                if (listFavorite == null)
                {
                    return null;
                }
                else
                {
                    return listFavorite;
                }

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
