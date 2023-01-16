using CM.Community_Back_end.Models;
using CmCommunityBackend.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Data;
using System.Net.Sockets;
using Xunit;

namespace CM.Community_Back_end.Services.tests
{
    public class GroupServiceTests
    {

        [Fact]
        public void GroupIsRetreivedUsingGroupId()
        {
            var Group = new Group()
            {
                groupID = 1,
                groupName = "TestGroup"
            };

            var User = new User()
            {
                UserId= 1,
                userEmail = "",
                userFirstName = "",
                userLastName= "",
                userBirthDate= DateTime.Now,
                userPassword = ""

            };

            var mockSetGroup = new Mock<DbSet<Group>>(); //tabel
            var mockSetUser = new Mock<DbSet<User>>();

            // Mock packet tabel via IQueryable zie microsoft documentatie: https://learn.microsoft.com/en-us/ef/ef6/fundamentals/testing/mocking
            // Seed
            mockSetGroup.As<IQueryable<Group>>().Setup(m => m.Provider).Returns(Group.Provider);
            mockSetGroup.As<IQueryable<Group>>().Setup(m => m.Expression).Returns(Group.Expression);
            mockSetGroup.As<IQueryable<Group>>().Setup(m => m.ElementType).Returns(Group.ElementType);
            mockSetGroup.As<IQueryable<Group>>().Setup(m => m.GetEnumerator()).Returns(() => Group.GetEnumerator());

            mockSetUser.As<IQueryable<User>>().Setup(m => m.Provider).Returns(User.Provider);
            mockSetUser.As<IQueryable<User>>().Setup(m => m.Expression).Returns(User.Expression);
            mockSetUser.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(User.ElementType);
            mockSetUser.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => User.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();//database
            mockContext.Setup(m => m.Groups).Returns(mockSetGroup.Object);
            mockContext.Setup(m => m.Users).Returns(mockSetUser.Object);

            var groupService = new GroupService(mockContext.Object);


            var result = groupService.getGroupById(/*groupid*/);

            Assert.False(result?.AdultsOnly);
            // Arrange

            // Act

            // assert
        }
    }
}
