using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CM.Community_Back_end.DTO;
using CM.Community_Back_end.Models;

namespace CM.Community_Back_end.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> getUserById(int Id);
        Task<User> addUser(User newUser);
        Task<List<User>> updateUser(User updatedUser);
        Task<User> deleteUser(int userID);
        Task<String> loginUser(UserDTO user);
    }
}