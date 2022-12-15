using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CM.Community_Back_end.Models;
using Microsoft.AspNetCore.Mvc;

namespace CM.Community_Back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
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

        [HttpGet("GetAll")]
        public ActionResult<List<Post>> get()
        {
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public ActionResult<Post> GetSingle(int id)
        {
            return Ok(posts.FirstOrDefault(p => p.postID == id));
        }

        [HttpPost]
        public ActionResult<List<Post>> AddPost(Post newPost)
        {
            posts.Add(newPost);
            return Ok(posts);
        }

    }
}