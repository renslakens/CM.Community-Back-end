using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CM.Community_Back_end.DTO;
using CM.Community_Back_end.Models;
using CmCommunityBackend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CM.Community_Back_end.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        private readonly IConfiguration _configuration;
        public UserService(IConfiguration configuration, ApplicationDbContext context) {
            _configuration = configuration;
            _context = context;
        }

        public async Task addingUser(User newUser)
        {
            var existingUsers = _context.Users.FirstOrDefault(t => t.userEmail == newUser.userEmail);

            newUser.userPassword = BCrypt.Net.BCrypt.HashPassword(newUser.userPassword);
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
        }

        public async Task<String> addUser(User newUser)
        {
            var existingUsers = _context.Users.FirstOrDefault(t => t.userEmail == newUser.userEmail);
            var returnSucces = "User added succesfully";
            var returnFail = "User already exists";

            if (existingUsers != null)
            {
                return returnFail;
            }
            else if (existingUsers == null)
            {
                addingUser(newUser);
                return returnSucces;
            }
            else
            {
                return "fail";
            }
        }

        public Task<List<User>> updateUser(User updatedUser) {
            throw new NotImplementedException();
        }

        public async Task<User?> deleteUser(int userID) {
            var users = await _context.Users.FindAsync(userID);
            if (users is null)
                return null;

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return users;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> getUserById(int Id) 
        {
            return await _context.Users.FindAsync(Id);
        }

        public async Task<String> loginUser(UserDTO user) {
            //Gehashte wachtwoord checken met het ingevoerde wachtwoord
            var oUser = _context.Users.FirstOrDefault(c => c.userEmail == user.userEmail);

            if (oUser == null) {
                return "User does not exist";
            }

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(user.userPassword, oUser.userPassword);

            string token = CreateToken(user);

            if (isValidPassword) {
                return token;
            }

            return "Invalid login";
        }

        private string CreateToken(UserDTO user)
        {
            var oUser = _context.Users.FirstOrDefault(c => c.userEmail == user.userEmail);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, oUser.UserId.ToString()),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}