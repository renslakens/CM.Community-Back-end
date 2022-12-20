using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CM.Community_Back_end.Models;
using CmCommunityBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace CM.Community_Back_end.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        
        //private static List<User> users = new List<User>{
        //    new User{userFirstName = "Lies", userEmail = "urMOm<3", userPassword = "Urdad<3"},
        //    new User{userFirstName = "Ay", userEmail = "urMom<3", userPassword = "Urdad<3" }
        //};

        public UserService(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<User> addUser(User newUser)
        {
            newUser.userPassword = BCrypt.Net.BCrypt.HashPassword(newUser.userPassword);
            _context.Users.AddAsync(newUser);
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
            var oUser = _context.Users.FirstOrDefault(c => c.userEmail == user.userEmail);
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(user.userPassword, oUser.userPassword);

            //TODO: Token genereren en terugsturen

            if (isValidPassword) {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }

            return "Invalid";
        }
    }
}