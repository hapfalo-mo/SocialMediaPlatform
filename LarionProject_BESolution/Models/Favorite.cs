using System;
using System.Collections.Generic;

namespace Models;

public partial class Favorite
{
    public int FavoriteId { get; set; }

    public string FavoriteName { get; set; } = null!;

    public virtual ICollection<UserFavorite> UserFavorites { get; set; } = new List<UserFavorite>();
}
