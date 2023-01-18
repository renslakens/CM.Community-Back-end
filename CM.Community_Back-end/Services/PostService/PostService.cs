using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CM.Community_Back_end.Models;
using CM.Community_Back_end.Services.GroupService;
using CmCommunityBackend.Data;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CM.Community_Back_end.Services.PostService
{
    public class PostService : IPostService
    {

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

            var groupsnew = testing.Posts.FromSql($"SELECT Posts.postID, Posts.postTitle, Posts.postText, Posts.publicationDate, Posts.Subject, Posts.groupID, Posts.userID, Users.userFirstName, Users.userLastName, Groups.groupName FROM Posts INNER JOIN Users ON Posts.userID=Users.UserId INNER JOIN Groups ON Posts.groupID=Groups.groupID WHERE Posts.groupID = {groupID};").ToList<Post>();

            groupsnew.Reverse();
            return groupsnew;
        }

        public async Task<List<Post?>> GetPostByUserId(int userID)
        {
            var testing = _context;
            var testing1 = _groupService;
            var userPosts = new List<object>();

            var userPosts3 = testing.Posts.FromSql($"SELECT Posts.postID, Posts.postTitle, Posts.postText, Posts.publicationDate, Posts.Subject, Posts.groupID, Posts.userID, Users.userFirstName, Users.userLastName, Posts.groupName FROM Posts LEFT JOIN Users ON Posts.userID=Users.UserId WHERE Posts.groupID is null;").ToList<Post>();

            //getting groupid's
            var taskgroups = testing1.getGroupByUserID(userID).Result;


            foreach (var user in taskgroups)
            {
                var groupPostsnew = testing.Posts.FromSql($"SELECT Posts.postID, Posts.postTitle, Posts.postText, Posts.publicationDate, Posts.Subject, Posts.groupID, Posts.userID, Users.userFirstName, Users.userLastName, Groups.groupName FROM Posts INNER JOIN Users ON Posts.userID=Users.UserId INNER JOIN Groups ON Posts.groupID=Groups.groupID WHERE Posts.groupID = {user.groupID};").ToList();

                userPosts3.AddRange(groupPostsnew);
            }
            var sortedList = userPosts3.OrderBy(t => t.postID).ToList();
            sortedList.Reverse();

            return sortedList;
        }

        public async Task<List<Post>> AddPost(int? userID, Post newPost, int? groupID)
        {
            groupID = newPost.groupID;
            userID = newPost.userID;

            if (newPost.groupID == null)
            {
                newPost.groupName = "General";
            }

            _context.Posts.Add(newPost);
            await _context.SaveChangesAsync();
            return await _context.Posts.ToListAsync();

        }

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