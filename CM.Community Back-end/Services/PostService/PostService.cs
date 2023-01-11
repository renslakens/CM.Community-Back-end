using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CM.Community_Back_end.Models;
using CmCommunityBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace CM.Community_Back_end.Services.PostService
{
    public class PostService : IPostService
    {

        // private static List<Post> posts = new List<Post>{
        //     new Post{
        //         postID = 1,
        //         postTitle = "I'm the first post",
        //         postText = "This post is the first post of the page! Exciting right?",
        //         publicationDate = new DateTime(),
        //         Subject = "Subject one"
        //     },
        //     new Post{
        //         postID = 2,
        //         postTitle = "I'm the second post",
        //         postText = "To top it off, we've got not one, but two posts!!",
        //         publicationDate = new DateTime(),
        //         Subject = "Subject two"}
        // };

        private readonly ApplicationDbContext _context;
        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Post>> GetAllPosts()
        {
            var posts = await _context.Posts.ToListAsync();
            posts.Reverse();
            return posts;
        }

        public async Task<List<Post?>> GetPostByGroupId(int groupID)
        {
            var testing = _context;

            var groups = testing.Posts
            .Where(t => groupID.Equals(t.groupID)).ToList<Post>();

            groups.Reverse();
            return groups;
        }

        public async Task<List<Post?>> GetPostByUserId(int userID)
        {
            var testing = _context;
            var userPosts = new List<Post>();

            var userGroups = testing.UserGroups
            .Where(t => userID.Equals(t.userID)).ToList<UserGroup>();

            foreach (var user in userGroups)
            {
                userPosts = testing.Posts
                .Where(t => user.groupID.Equals(t.groupID)).ToList<Post>();
            }
            userPosts.Reverse();
            return userPosts;
        }

        public async Task<List<Post>> AddPost(int userID, Post newPost, int? groupID)
        {
            groupID = newPost.groupID;

            _context.Posts.Add(newPost);
            await _context.SaveChangesAsync();
            return await _context.Posts.ToListAsync();

        }

        // private async Task<int> GetIndexById(Post post)
        // {
        //     var posts = await _context.Posts.FindAsync(post);
        //     return posts.FindIndex(t => t.postID == post.postID);
        // }

        public async Task<Post?> UpdatePost(int postID, Post updatedPost)
        {
            var posts = await _context.Posts.FindAsync(postID);
            if (posts is null)
                return null;

            posts.postTitle = updatedPost.postTitle;
            posts.postText = updatedPost.postText;
            posts.publicationDate = updatedPost.publicationDate;
            posts.Subject = updatedPost.Subject;

            await _context.SaveChangesAsync();

            return updatedPost;
        }

        public async Task<Post?> DeletePost(int postID)
        {
            var posts = await _context.Posts.FindAsync(postID);
            if (posts is null)
                return null;

            _context.Posts.Remove(posts);
            await _context.SaveChangesAsync();

            return posts;
        }
    }
}