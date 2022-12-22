using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CM.Community_Back_end.Models;

namespace CM.Community_Back_end.Services.PostService
{
    public interface IPostService
    {
        Task<List<Post>> GetAllPosts();

        Task<List<Post?>> GetPostById(int postID);

        Task<List<Post>> AddPost(Post newPost, int groupID);

        Task<Post?> UpdatePost(int postID, Post updatedPost);

        Task<Post?> DeletePost(int postId);
    }
}