using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CM.Community_Back_end.Models;

namespace CM.Community_Back_end.Services.PostService
{
    public class PostService : IPostService
    {

        private static List<Post> posts = new List<Post>{
            new Post{
                postID = 1,
                postTitle = "I'm the first post",
                postText = "This post is the first post of the page! Exciting right?",
                publicationDate = new DateTime(),
                Subject = "Subject one"
            },
            new Post{
                postID = 2,
                postTitle = "I'm the second post",
                postText = "To top it off, we've got not one, but two posts!!",
                publicationDate = new DateTime(),
                Subject = "Subject two"}
        };

        public async Task<List<Post>> GetAllPosts()
        {
            return posts;
        }

        public async Task<Post> GetPostById(int postID)
        {
            return posts.FirstOrDefault(p => p.postID == postID);
        }

        public async Task<List<Post>> AddPost(Post newPost)
        {
            posts.Add(newPost);
            return posts;
        }

        private int GetIndexById(Post post)
        {
            return posts.FindIndex(t => t.postID == post.postID);
        }

        public async Task<Post> UpdatePost(Post updatedPost)
        {
            var index = GetIndexById(updatedPost);
            posts[index] = updatedPost;
            return updatedPost;
        }

        public async Task<Post> DeletePost(Post deletedPost)
        {
            var index = GetIndexById(deletedPost);
            posts.RemoveAt(index);
            return deletedPost;
        }
    }
}