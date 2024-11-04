using System;
using System.Collections.Generic;

namespace Models;

public partial class UserFavorite
{
    public int UserId { get; set; }

    public int FavoriteId { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual Favorite Favorite { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
