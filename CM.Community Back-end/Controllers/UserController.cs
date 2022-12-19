using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CM.Community_Back_end.Models;
using CM.Community_Back_end.Services.UserService;
using CmCommunityBackend.Data;
using Microsoft.AspNetCore.Mvc;

namespace CM.Community_Back_end.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ApplicationDbContext _context;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> getAll()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<User>> getSingle(string email)
        {
            return Ok(await _userService.getCharacterByEmail(email));
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> addUser(User newUser)
        {
            await 
            return Ok(await _userService.addUser(newUser));
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> updateUser(User updatedUser)
        {
            return Ok(await _userService.updateUser(updatedUser));
        }

        [HttpDelete]
        public async Task<ActionResult<List<User>>> deleteUser(User deletedUser){
            return Ok(await _userService.deleteUser(deletedUser));
        }

        [HttpPost]
        [Route("auth")]
        public async Task<ActionResult<String>> loginUser(User user) {
            return Ok(await _userService.loginUser(user));
        }
    }
}