using CM.Community_Back_end;
using CM.Community_Back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace CmCommunityBackend.Data
{
    public class ApplicationDbContext : DbContext  
    {
        public DbSet<Comment>? Comments { get; set; }
        public DbSet<CommentPost>? CommentPosts { get; set; }
        public DbSet<Group>? Groups { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<Tag>? Tags { get; set; }
        public DbSet<TagPost>? TagPosts { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<UserGroup>? UserGroups { get; set; }
        public DbSet<UserPost>? UserPosts { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}