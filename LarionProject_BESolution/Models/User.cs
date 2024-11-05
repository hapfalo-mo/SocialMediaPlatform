using System;
using System.Collections.Generic;

namespace Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? FullName { get; set; } = null!;

    public string? Address { get; set;} = null!;

    public string? Introduction { get; set; }

    public string? AvatarUrl { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public short Role { get; set; }

    public DateTime CreatedAt { get; set; }

    public short Gentle { get; set; }

    public short Status { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Follow> FollowFollowedUsers { get; set; } = new List<Follow>();

    public virtual ICollection<Follow> FollowFollowingUsers { get; set; } = new List<Follow>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<UserFavorite> UserFavorites { get; set; } = new List<UserFavorite>();

    public virtual ICollection<Likes> Likes { get; set; } = new List<Likes>();
}
