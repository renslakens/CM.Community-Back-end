using CM.Community_Back_end;
using CM.Community_Back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace CmCommunityBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<AttachmentPost>? AttachmentPosts { get; set; }
        public DbSet<Comment>? Comments { get; set; }
        public DbSet<CommentPost>? CommentPosts { get; set; }
        public DbSet<Group>? Groups { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<ProfilePicture>? Picture { get; set; }
        public DbSet<Tag>? Tags { get; set; }
        public DbSet<TagPost>? TagPosts { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<UserGroup>? UserGroups { get; set; }
        public DbSet<UserPost>? UserPosts { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommentPost>().HasKey(vf => new { vf.commentID, vf.postID });
            modelBuilder.Entity<TagPost>().HasKey(vf => new { vf.tagID, vf.postID });
            modelBuilder.Entity<UserGroup>().HasKey(vf => new { vf.userID, vf.groupID });
            modelBuilder.Entity<UserPost>().HasKey(vf => new { vf.userID, vf.postID });
            modelBuilder.Entity<AttachmentPost>().Property(p => p.attachment).HasColumnType("MediumBlob");
            modelBuilder.Entity<ProfilePicture>().Property(p => p.profilePicture).HasColumnType("MediumBlob");
        }
    }
}