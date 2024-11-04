using System;
using System.Collections.Generic;

namespace Models;

public partial class Follow
{
    public int FollowingUserId { get; set; }

    public int FollowedUserId { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual User FollowedUser { get; set; } = null!;

    public virtual User FollowingUser { get; set; } = null!;
}
