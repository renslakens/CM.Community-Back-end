using System;
using System.Collections.Generic;
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
        
        private static List<User> users = new List<User>{
            new User{userFirstName = "Lies", userEmail = "urMOm<3", userPassword = "Urdad<3"},
            new User{userFirstName = "Ay", userEmail = "urMom<3", userPassword = "Urdad<3" }
        };
        private readonly IConfiguration _configuration;
        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private int getIndexById(User user)
        {
            return users.FindIndex((u) => u.userID == user.userID);
        }
        public async Task<List<User>> addUser(User newUser)
        {
            newUser.userPassword = BCrypt.Net.BCrypt.HashPassword(newUser.userPassword);
            users.Add(newUser);
            return users;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return users;
        }

        public async Task<User> getUserById(int Id) 
        {
            return users.FirstOrDefault(c => c.userID == Id);
        }

        public async Task<List<User>> updateUser(User updatedUser)
        {
            int index = getIndexById(updatedUser);
            users[index] = updatedUser;
            return users;
        }
        public async Task<List<User>> deleteUser(User deletedUser)
        {
            int index = getIndexById(deletedUser);
            users.RemoveAt(index);
            return users;
        }

        public async Task<String> loginUser(User user) {
            //Gehashte wachtwoord checken met het ingevoerde wachtwoord
            var oUser = users.FirstOrDefault(c => c.userEmail == user.userEmail);
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(user.userPassword, oUser.userPassword);

            //TODO: Token genereren en terugsturen

            string token = CreateToken(user);

            //if (isValidPassword) {
            //    await _context.Users.AddAsync(user);
            //    await _context.SaveChangesAsync();
            //}

            return "Invalid";
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.userFirstName)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes())

            return string.Empty;
        }
    }
}