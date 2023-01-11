using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CM.Community_Back_end.Models;
using CM.Community_Back_end.Services;
using CM.Community_Back_end.Services.PostService;
using Microsoft.AspNetCore.Mvc;

namespace CM.Community_Back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Post>>> get()
        {
            return Ok(await _postService.GetAllPosts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Post>>> GetGroupPost(int id)
        {
            return Ok(await _postService.GetPostByGroupId(id));
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<List<Post>>> GetUserPost(int id)
        {
            return Ok(await _postService.GetPostByUserId(id));
        }

        [HttpPost("New")]
        public async Task<ActionResult<List<Post>>> AddPost(int userID, Post newPost, int groupID)
        {
            return CreatedAtAction(nameof(AddPost), await _postService.AddPost(userID, newPost, groupID));
        }

        [HttpPut]
        public async Task<ActionResult<Post>> UpdatePost(int postID, Post updatedPost)
        {
            return Ok(await _postService.UpdatePost(postID, updatedPost));
        }

        [HttpDelete]
        public async Task<ActionResult<Post>> DeletePost(int postID)
        {
            return Ok(await _postService.DeletePost(postID));
        }

    }
}