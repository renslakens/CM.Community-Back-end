using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CM.Community_Back_end.Models;
using CmCommunityBackend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CM.Community_Back_end.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        
        //private static List<User> users = new List<User>{
        //    new User{userFirstName = "Lies", userEmail = "urMOm<3", userPassword = "Urdad<3"},
        //    new User{userFirstName = "Ay", userEmail = "urMom<3", userPassword = "Urdad<3" }
        //};

        private readonly IConfiguration _configuration;
        public UserService(IConfiguration configuration, ApplicationDbContext context) {
            _configuration = configuration;
            _context = context;
        }

        public async Task<User> addUser(User newUser)
        {
            newUser.userPassword = BCrypt.Net.BCrypt.HashPassword(newUser.userPassword);
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }

        public Task<List<User>> updateUser(User updatedUser) {
            throw new NotImplementedException();
        }

        public Task<List<User>> deleteUser(User deletedUser) {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> getUserById(int Id) 
        {
            return await _context.Users.FindAsync(Id);
        }

        //public async Task<List<User>> updateUser(User updatedUser) {
        //    int index = getIndexById(updatedUser);
        //    users[index] = updatedUser;
        //    return users;
        //}
        //public async Task<List<User>> deleteUser(User deletedUser) {
        //    int index = getIndexById(deletedUser);
        //    _context.Users.RemoveAt(index);
        //    return users;
        //}

        public async Task<String> loginUser(User user) {
            //Gehashte wachtwoord checken met het ingevoerde wachtwoord
            var oUser = _context.Users.FirstOrDefault(c => c.UserId == user.UserId);
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(user.userPassword, oUser.userPassword);

            string token = CreateToken(user);

            if (isValidPassword) {
                return token;
            }

            return "Invalid login";
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.userFirstName)
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