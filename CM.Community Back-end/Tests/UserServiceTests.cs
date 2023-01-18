using CM.Community_Back_end.Services.UserService;
using CmCommunityBackend.Data;
using CM.Community_Back_end.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using System.Linq.Expressions;

namespace CM.Community_Back_end.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public void NewUserIsAdded()
        {
            //arrange
            var User = new List<User>
            {
                new User {
                UserId = 1,
                userEmail = "",
                userFirstName = "",
                userLastName = "",
                userBirthDate = DateTime.Now,
                userPassword = ""
                }

            }.AsQueryable();

            var AddUser = new User
            {
                UserId = 2,
                userEmail = "",
                userFirstName = "",
                userLastName = "",
                userBirthDate = new DateTime(2000, 01, 01),
                userPassword = ""
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
        }
    }
}
