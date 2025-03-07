using Entities;
using Moq;
using System.Reflection.Metadata;
using Repositories;
using Repositories;
using Moq.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using MyShop.Models;
using Services;

namespace TestProject2
{
    public class UnitTest1
    {
        [Fact]
        public async Task GetUser_ValidCredentials_ReturnsUser()
        {
            //Arrange
            var user = new User { UserName = "Elisheva", Password = "12@34#eE" };
            var mockContext = new Mock<MyShopUsersContext>();
            var users = new List<User>() { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            var userRepository = new UserRepositories(mockContext.Object);

            //Act
            var result = await userRepository.Login(user.UserName, user.Password);

            //Assert
            Assert.Equal(user, result);
        }
        [Fact]
        public async Task Post_ShouldAddUser()
        {
            // Arrange
            var user = new User { UserName = "Elisheva", Password = "12@34#eE" };

            var mockSet = new Mock<DbSet<User>>();
            var mockContext = new Mock<MyShopUsersContext>();

            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var userRepository = new UserRepositories(mockContext.Object);

            // Act
            var result = await userRepository.Post(user);

            // Assert
            Assert.Equal(user.UserName, result.UserName);
        }
        
    }

}