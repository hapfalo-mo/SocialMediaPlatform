using System;
using System.Collections.Generic;

namespace Models;

public partial class Favorite
{
    public int FavoriteId { get; set; }

    public string FavoriteName { get; set; }

    public DateTime? CreateAt { get; set; }

    public int? CreateBy { get; set; }

    public string? ImgUrl { get; set; }

    public int? Status { get; set; }

    public virtual ICollection<UserFavorite> UserFavorites { get; set; } = new List<UserFavorite>();
}
