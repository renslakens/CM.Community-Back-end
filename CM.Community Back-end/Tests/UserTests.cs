using CM.Community_Back_end.Services.UserService;
using CmCommunityBackend.Data;
using CM.Community_Back_end.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using System.Linq.Expressions;
using CM.Community_Back_end.DTO;
using System;

namespace CM.Community_Back_end.Tests
{
    public class UserTests
    {
        [Fact]
        public void SignUpUser()
        {
            //arrange
            var User = new List<User>
            {
            }.AsQueryable();

            var AddUser = new User
            {
                UserId = 1,
                userEmail = "testing@email.com",
                userFirstName = "TestFirstName",
                userLastName = "TestLastName",
                userBirthDate = new DateTime(2000, 01, 01),
                userPassword = "P@ssw0rd"
            };

            var mockSetUser = new Mock<DbSet<User>>(); //tabel

            // Mock packet tabel via IQueryable zie microsoft documentatie: https://learn.microsoft.com/en-us/ef/ef6/fundamentals/testing/mocking
            // Seed
            mockSetUser.As<IQueryable<User>>().Setup(m => m.Provider).Returns(User.Provider);
            mockSetUser.As<IQueryable<User>>().Setup(m => m.Expression).Returns(User.Expression);
            mockSetUser.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(User.ElementType);
            mockSetUser.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => User.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();//database
            mockContext.Setup(m => m.Users).Returns(mockSetUser.Object);

            var configuration = new Mock<IConfiguration>();//configuration

            var userService = new UserService(configuration.Object, mockContext.Object);

            //act
            var result = userService.addUser(AddUser);

            //assert
            Assert.NotNull(result);
            Assert.Equal(result.Result, "User added succesfully");
        }

        [Fact]
        public void LoginUser()
        {
            //arrange
            var User = new List<User>
            {
                new User {
                    UserId = 1,
                    userEmail = "testing@email.com",
                    userFirstName = "TestFirstName",
                    userLastName = "TestLastName",
                    userBirthDate = new DateTime(2000, 01, 01),
                    userPassword = "P@ssw0rd"
                }
            }.AsQueryable();

            var LoginUser = new UserDTO
            {
                userEmail = "testingsecond@email.com",
                userPassword = "P@ssw0rd"
            };

            var mockSetUser = new Mock<DbSet<User>>(); //tabel

            // Mock packet tabel via IQueryable zie microsoft documentatie: https://learn.microsoft.com/en-us/ef/ef6/fundamentals/testing/mocking
            // Seed
            mockSetUser.As<IQueryable<User>>().Setup(m => m.Provider).Returns(User.Provider);
            mockSetUser.As<IQueryable<User>>().Setup(m => m.Expression).Returns(User.Expression);
            mockSetUser.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(User.ElementType);
            mockSetUser.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => User.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();//database
            mockContext.Setup(m => m.Users).Returns(mockSetUser.Object);

            var configuration = new Mock<IConfiguration>();//configuration

            var userService = new UserService(configuration.Object, mockContext.Object);

            //act
            var result = userService.loginUser(LoginUser);

            //assert
            Assert.NotNull(result);
            Assert.IsType<Task<String>>(result);

        }
    }
}
