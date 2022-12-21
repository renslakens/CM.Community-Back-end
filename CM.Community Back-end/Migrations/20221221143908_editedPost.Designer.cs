﻿// <auto-generated />
using System;
using CmCommunityBackend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CM.CommunityBackend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221221143908_editedPost")]
    partial class editedPost
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CM.Community_Back_end.Models.AttachmentPost", b =>
                {
                    b.Property<int>("postID")
                        .HasColumnType("int");

                    b.Property<byte[]>("attachment")
                        .IsRequired()
                        .HasMaxLength(8000)
                        .HasColumnType("varbinary");

                    b.HasKey("postID");

                    b.ToTable("AttachmentPosts");
                });

            modelBuilder.Entity("CM.Community_Back_end.Models.Comment", b =>
                {
                    b.Property<int>("commentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("commentID"));

                    b.Property<string>("commentText")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("commentID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("CM.Community_Back_end.Models.CommentPost", b =>
                {
                    b.Property<int>("commentID")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<int>("postID")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("commentID", "postID");

                    b.HasIndex("postID");

                    b.ToTable("CommentPosts");
                });

            modelBuilder.Entity("CM.Community_Back_end.Models.Group", b =>
                {
                    b.Property<int>("groupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("groupID"));

                    b.Property<string>("groupName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("groupID");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("CM.Community_Back_end.Models.Post", b =>
                {
                    b.Property<int>("postID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("postID"));

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("groupID")
                        .HasColumnType("int");

                    b.Property<string>("postText")
                        .IsRequired()
                        .HasMaxLength(360)
                        .HasColumnType("nvarchar(360)");

                    b.Property<string>("postTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("publicationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("postID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("CM.Community_Back_end.Models.ProfilePicture", b =>
                {
                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.Property<byte[]>("profilePicture")
                        .IsRequired()
                        .HasMaxLength(8000)
                        .HasColumnType("varbinary");

                    b.HasKey("userID");

                    b.ToTable("ProfilePicture");
                });

            modelBuilder.Entity("CM.Community_Back_end.Models.Tag", b =>
                {
                    b.Property<int>("tagID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tagID"));

                    b.Property<string>("tagName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("tagID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("CM.Community_Back_end.Models.TagPost", b =>
                {
                    b.Property<int>("tagID")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<int>("postID")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("tagID", "postID");

                    b.HasIndex("postID");

                    b.ToTable("TagPosts");
                });

            modelBuilder.Entity("CM.Community_Back_end.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("userBirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("userEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("userFirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("userLastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("userPassword")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CM.Community_Back_end.Models.UserGroup", b =>
                {
                    b.Property<int>("userID")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<int>("groupID")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("userID", "groupID");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("CM.Community_Back_end.Models.UserPost", b =>
                {
                    b.Property<int>("userID")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("postID")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.HasKey("userID", "postID");

                    b.HasIndex("postID");

                    b.ToTable("UserPosts");
                });

            modelBuilder.Entity("CM.Community_Back_end.Models.AttachmentPost", b =>
                {
                    b.HasOne("CM.Community_Back_end.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("postID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("CM.Community_Back_end.Models.CommentPost", b =>
                {
                    b.HasOne("CM.Community_Back_end.Models.Comment", "Comment")
                        .WithMany()
                        .HasForeignKey("commentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CM.Community_Back_end.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("postID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("CM.Community_Back_end.Models.ProfilePicture", b =>
                {
                    b.HasOne("CM.Community_Back_end.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CM.Community_Back_end.Models.TagPost", b =>
                {
                    b.HasOne("CM.Community_Back_end.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("postID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CM.Community_Back_end.Models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("tagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("CM.Community_Back_end.Models.UserPost", b =>
                {
                    b.HasOne("CM.Community_Back_end.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("postID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CM.Community_Back_end.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
