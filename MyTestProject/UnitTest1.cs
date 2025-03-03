using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using Moq.EntityFrameworkCore;
using MyShop.Models;
using Repositories;
namespace MyTestProject

{
    public class UnitTest1
    {
        [Fact]
        public async Task  GetUser_ValidCredentials_ReturnsUser()
        {
            var user = new User { UserName = "Elisheva", Password = "123@Eeli" };
            var users = new List<User>() { user };
            var mockContext = new Mock<MyShopUsersContext>();
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            var userRepository = new UserRepositories(mockContext.Object);

            var result = await userRepository.Login(user.UserName, user.Password);
            Assert.Equal(user, result);
        }

        [Fact]
        public async Task Post_ShouldAddUser()
        {
            // Arrange
            var user = new User { UserName = "Leah", Password = "12@34#eE" };

            var mockSet = new Mock<DbSet<User>>();
            var mockContext = new Mock<MyShopUsersContext>();

            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var userRepository = new UserRepositories(mockContext.Object);

            // Act
            var result = await userRepository.Post(user);

            // Assert
            //mockSet.Verify(m => m.Add(It.IsAny<User>()), Times.Once);
            //mockContext.Verify(m => m.SaveChangesAsync(), Times.Once);
            Assert.Equal(user.UserName, result.UserName);
        }
    }
}