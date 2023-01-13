using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CM.Community_Back_end.Models;
using CM.Community_Back_end.Services.GroupService;
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
        private readonly IGroupService _groupService;
        public PostService(ApplicationDbContext context, IGroupService groupService)
        {
            _context = context;
            _groupService = groupService;   
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

            //var groups = testing.Posts
            //            .Where(t => groupID.Equals(t.groupID)).ToList<Post>();

            var groupsnew = testing.Posts.FromSql($"SELECT Posts.*, Users.userFirstName, Users.userLastName FROM Posts INNER JOIN Users ON Posts.userID=Users.UserId WHERE Posts.groupID = {groupID};").ToList<Post>();

            groupsnew.Reverse();
            return groupsnew;
        }

        public async Task<List<Post?>> GetPostByUserId(int userID)
        {
            var testing = _context;
            var testing1 = _groupService;
            var userPosts = new List<Post>();

            var userPosts2 = testing.Posts
                            .Where(t => t.groupID == null).ToList();


            //getting groupid's
            var taskgroups = testing1.getGroupByUserID(userID).Result;


            foreach (var user in taskgroups)
            {
                var groupPostsnew = testing.Posts.FromSql($"SELECT Posts.*, Users.userFirstName, Users.userLastName FROM Posts INNER JOIN Users ON Posts.userID=Users.UserId WHERE Posts.groupID = {user.groupID};").ToList<Post>();



                //var groupPosts = testing.Posts
                //.Where(t => user.groupID.Equals(t.groupID)).ToList<Post>();
                //// add username 
                userPosts2.AddRange(groupPostsnew);
            }
            var sortedList = userPosts2.OrderBy(t => t.postID).ToList();
            sortedList.Reverse();


            //foreach (var post in sortedList)
            //{
            //    var username = testing.UsersAlth
            //                   .Where(t => post.userID.Equals(t.UserId));
            //                   //.Select(userFirstName);


                               
            //}


            return sortedList;



            //var testing = _context;
            //var userPosts = new List<Post>();
            //var userPostsGroups = new List<Post>();
            //var generalPosts = testing.Posts
            //                    .Where(t => t.groupID.Equals(null)).ToList<Post>();

            //var userGroups = testing.UserGroups
            //.Where(t => userID.Equals(t.userID)).ToList<UserGroup>();

            //foreach (var user in userGroups)
            //{
            //    userPostsGroups = testing.Posts
            //    .Where(t => user.groupID.Equals(t.groupID)).ToList<Post>();
            //}
            //userPosts.AddRange(userPostsGroups);
            //userPosts.AddRange(generalPosts);
            //userPosts.OrderBy(t => t.postID);

            //userPosts.Reverse();
            //return userPosts;



        }

        public async Task<List<Post>> AddPost(int? userID, Post newPost, int? groupID)
        {
            groupID = newPost.groupID;
            userID = newPost.userID;

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