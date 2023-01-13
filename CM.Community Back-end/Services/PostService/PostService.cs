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

            var groups = testing.Posts
            .Where(t => groupID.Equals(t.groupID)).ToList<Post>();

            groups.Reverse();
            return groups;
        }

        public async Task<List<Post?>> GetPostByUserId(int userID)
        {
            var testing = _context;
            var testing1 = _groupService;
            var userPosts = new List<Post>();

            var userPosts2 = testing.Posts
                            .Where(t => t.groupID == null).ToList<Post>();

            //var userGroups = testing.UserGroups
            //.Where(t => userID.Equals(t.userID)).ToList<UserGroup>();





            //getting groupid's, same as in groupservice

            //var testinggroups = testing1.getGroupByUserID(userID);

            var groups = new List<Group>();
            var groupsnotdistinct = new List<Group>();

            var userGroups = testing.UserGroups
                            .Where(t => userID.Equals(t.userID)).ToList<UserGroup>();

            if (userGroups.Count > 0)
            {
                foreach (var user in userGroups)
                {
                    var joinedgroups = testing.Groups
                                       .Where(t => user.groupID.Equals(t.groupID)).ToList<Group>();

                    groupsnotdistinct.AddRange(joinedgroups);

                }

                foreach (var group in groupsnotdistinct)
                {
                    groups.Add(group);
                }
            }

            //getting groupid's, same as in groupservice



            foreach (var user in userGroups)
            {
                var groupPosts = testing.Posts
                .Where(t => user.groupID.Equals(t.groupID)).ToList<Post>();
                
                userPosts2.AddRange(groupPosts);
            }
            var sortedList = userPosts2.OrderBy(t => t.postID).ToList();
            sortedList.Reverse();
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