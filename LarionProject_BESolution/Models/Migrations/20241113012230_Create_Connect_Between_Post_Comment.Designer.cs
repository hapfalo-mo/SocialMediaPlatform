﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Models.Migrations
{
    [DbContext(typeof(LarionDatabaseContext))]
    [Migration("20241113012230_Create_Connect_Between_Post_Comment")]
    partial class Create_Connect_Between_Post_Comment
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("comment_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CommentId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("CreateBy")
                        .HasColumnType("integer")
                        .HasColumnName("create_by");

                    b.Property<int?>("ParrentId")
                        .HasColumnType("integer")
                        .HasColumnName("parrent_id");

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.HasKey("CommentId")
                        .HasName("comments_pkey");

                    b.HasIndex("CreateBy");

                    b.HasIndex("ParrentId");

                    b.HasIndex("PostId");

                    b.ToTable("comments", (string)null);
                });

            modelBuilder.Entity("Models.Favorite", b =>
                {
                    b.Property<int>("FavoriteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("favorite_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FavoriteId"));

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CreateBy")
                        .HasColumnType("integer");

                    b.Property<string>("FavoriteName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("favorite_name");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("text");

                    b.Property<int?>("Status")
                        .HasColumnType("integer");

                    b.HasKey("FavoriteId")
                        .HasName("favorites_pkey");

                    b.ToTable("favorites", (string)null);
                });

            modelBuilder.Entity("Models.Follow", b =>
                {
                    b.Property<int>("FollowingUserId")
                        .HasColumnType("integer")
                        .HasColumnName("following_user_id");

                    b.Property<int>("FollowedUserId")
                        .HasColumnType("integer")
                        .HasColumnName("followed_user_id");

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("FollowingUserId", "FollowedUserId")
                        .HasName("follows_pkey");

                    b.HasIndex("FollowedUserId");

                    b.ToTable("follows", (string)null);
                });

            modelBuilder.Entity("Models.Likes", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<int>("PostId")
                        .HasColumnType("integer")
                        .HasColumnName("post_id");

                    b.HasKey("UserId", "PostId")
                        .HasName("likes_pkey");

                    b.HasIndex("PostId");

                    b.ToTable("likes", (string)null);
                });

            modelBuilder.Entity("Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("post_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PostId"));

                    b.Property<string>("Body")
                        .HasColumnType("text")
                        .HasColumnName("body");

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("ImgURL")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("title");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("update_at");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("PostId")
                        .HasName("post_pkey");

                    b.HasIndex("UserId");

                    b.ToTable("post", (string)null);
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("AvatarUrl")
                        .HasMaxLength(2083)
                        .HasColumnType("character varying(2083)")
                        .HasColumnName("avatar_url");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<short>("Gentle")
                        .HasColumnType("smallint")
                        .HasColumnName("gentle");

                    b.Property<string>("Introduction")
                        .HasColumnType("text")
                        .HasColumnName("introduction");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("phone_number");

                    b.Property<short>("Role")
                        .HasColumnType("smallint")
                        .HasColumnName("role");

                    b.Property<short>("Status")
                        .HasColumnType("smallint")
                        .HasColumnName("status");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("username");

                    b.HasKey("UserId")
                        .HasName("user_pkey");

                    b.HasIndex(new[] { "Email" }, "user_email_key")
                        .IsUnique();

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("Models.UserFavorite", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<int>("FavoriteId")
                        .HasColumnType("integer")
                        .HasColumnName("favorite_id");

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("UserId", "FavoriteId")
                        .HasName("user_favorites_pkey");

                    b.HasIndex("FavoriteId");

                    b.ToTable("user_favorites", (string)null);
                });

            modelBuilder.Entity("Models.Comment", b =>
                {
                    b.HasOne("Models.User", "CreateByNavigation")
                        .WithMany("Comments")
                        .HasForeignKey("CreateBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("comments_create_by_fkey");

                    b.HasOne("Models.Comment", "Parrent")
                        .WithMany("InverseParrent")
                        .HasForeignKey("ParrentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("comments_parrent_id_fkey");

                    b.HasOne("Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("comments_post_id_fkey");

                    b.Navigation("CreateByNavigation");

                    b.Navigation("Parrent");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Models.Follow", b =>
                {
                    b.HasOne("Models.User", "FollowedUser")
                        .WithMany("FollowFollowedUsers")
                        .HasForeignKey("FollowedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("follows_followed_user_id_fkey");

                    b.HasOne("Models.User", "FollowingUser")
                        .WithMany("FollowFollowingUsers")
                        .HasForeignKey("FollowingUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("follows_following_user_id_fkey");

                    b.Navigation("FollowedUser");

                    b.Navigation("FollowingUser");
                });

            modelBuilder.Entity("Models.Likes", b =>
                {
                    b.HasOne("Models.Post", "PostNavigation")
                        .WithMany("Likes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("likes_post_id_fkey");

                    b.HasOne("Models.User", "UserNavigation")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("likes_user_id_fkey");

                    b.Navigation("PostNavigation");

                    b.Navigation("UserNavigation");
                });

            modelBuilder.Entity("Models.Post", b =>
                {
                    b.HasOne("Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("post_user_id_fkey");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.UserFavorite", b =>
                {
                    b.HasOne("Models.Favorite", "Favorite")
                        .WithMany("UserFavorites")
                        .HasForeignKey("FavoriteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("user_favorites_favorite_id_fkey");

                    b.HasOne("Models.User", "User")
                        .WithMany("UserFavorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("user_favorites_user_id_fkey");

                    b.Navigation("Favorite");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Comment", b =>
                {
                    b.Navigation("InverseParrent");
                });

            modelBuilder.Entity("Models.Favorite", b =>
                {
                    b.Navigation("UserFavorites");
                });

            modelBuilder.Entity("Models.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("FollowFollowedUsers");

                    b.Navigation("FollowFollowingUsers");

                    b.Navigation("Likes");

                    b.Navigation("Posts");

                    b.Navigation("UserFavorites");
                });
#pragma warning restore 612, 618
        }
    }
}
