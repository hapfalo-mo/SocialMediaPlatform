using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Models;

public partial class LarionDatabaseContext : DbContext
{
    public LarionDatabaseContext()
    {
    }

    public LarionDatabaseContext(DbContextOptions<LarionDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<Follow> Follows { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserFavorite> UserFavorites { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      /*  => optionsBuilder.UseNpgsql(GetConnetionString());*/
      => optionsBuilder.UseNpgsql("Host =localhost;Port=5432;Database=LarionDatabase;Username=postgres;Password= HJ10xugb123*");

    private string GetConnetionString()
    {   
        var basePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
        var config = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .Build();
        return config.GetConnectionString("DefaultConnection");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("comments_pkey");

            entity.ToTable("comments");

            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.Content)
                .HasMaxLength(1000)
                .HasColumnName("content");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.CreateBy).HasColumnName("create_by");
            entity.Property(e => e.ParrentId).HasColumnName("parrent_id");

            entity.HasOne(d => d.CreateByNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.CreateBy)
                .HasConstraintName("comments_create_by_fkey");

            entity.HasOne(d => d.Parrent).WithMany(p => p.InverseParrent)
                .HasForeignKey(d => d.ParrentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("comments_parrent_id_fkey");
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.FavoriteId).HasName("favorites_pkey");

            entity.ToTable("favorites");

            entity.Property(e => e.FavoriteId).HasColumnName("favorite_id");
            entity.Property(e => e.FavoriteName)
                .HasMaxLength(255)
                .HasColumnName("favorite_name");
        });

        modelBuilder.Entity<Follow>(entity =>
        {
            entity.HasKey(e => new { e.FollowingUserId, e.FollowedUserId }).HasName("follows_pkey");

            entity.ToTable("follows");

            entity.Property(e => e.FollowingUserId).HasColumnName("following_user_id");
            entity.Property(e => e.FollowedUserId).HasColumnName("followed_user_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");

            entity.HasOne(d => d.FollowedUser).WithMany(p => p.FollowFollowedUsers)
                .HasForeignKey(d => d.FollowedUserId)
                .HasConstraintName("follows_followed_user_id_fkey");

            entity.HasOne(d => d.FollowingUser).WithMany(p => p.FollowFollowingUsers)
                .HasForeignKey(d => d.FollowingUserId)
                .HasConstraintName("follows_following_user_id_fkey");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("post_pkey");

            entity.ToTable("post");

            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Body).HasColumnName("body");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("post_user_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("user_pkey");

            entity.ToTable("user");

            entity.HasIndex(e => e.Email, "user_email_key").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.AvatarUrl)
                .HasMaxLength(2083)
                .HasColumnName("avatar_url");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Gentle).HasColumnName("gentle");
            entity.Property(e => e.Introduction).HasColumnName("introduction");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasColumnName("phone_number");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
        });

        modelBuilder.Entity<UserFavorite>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.FavoriteId }).HasName("user_favorites_pkey");

            entity.ToTable("user_favorites");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.FavoriteId).HasColumnName("favorite_id");
            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");

            entity.HasOne(d => d.Favorite).WithMany(p => p.UserFavorites)
                .HasForeignKey(d => d.FavoriteId)
                .HasConstraintName("user_favorites_favorite_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.UserFavorites)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("user_favorites_user_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
