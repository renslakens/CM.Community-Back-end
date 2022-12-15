using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CM.Community_Back_end.Models;

namespace CM.Community_Back_end.Services.UserService
{
    public class UserService : IUserService
    {
        private static List<User> users = new List<User>{
            new User{userName = "Lies", userEmail = "urMOm<3", userPassword = "Urdad<3"},
            new User{userName = "Ay", userEmail = "urMom<3", userPassword = "Urdad<3" }
        };
        private int getIndexByEmail(User user)
        {
            return users.FindIndex((u) => u.userEmail == user.userEmail);
        }
        public async Task<List<User>> addUser(User newUser)
        {
            users.Add(newUser);
            return users;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return users;
        }

        public async Task<User> getCharacterByEmail(string email)
        {
            return users.FirstOrDefault(c => c.userEmail == email);
        }

        public async Task<List<User>> updateUser(User updatedUser)
        {
            int index = getIndexByEmail(updatedUser);
            users[index] = updatedUser;
            return users;
        }
        public async Task<List<User>> deleteUser(User deletedUser)
        {
            int index = getIndexByEmail(deletedUser);
            users.RemoveAt(index);
            return users;
        }
    }
}