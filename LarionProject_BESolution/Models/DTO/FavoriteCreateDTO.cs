using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class FavoriteCreateDTO
    {   
        public int CreateBy { get; set; }
        public string FavoriteName { get;set; }
        public string? FavoriteImgUrl { get; set; }
    }
}
