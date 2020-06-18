using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookOverflowASP.Library.Data;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using BookOverflowASP.Library.Logic;

namespace BookOverflowASP.Test
{
    [TestClass]
    public class UserContainerTest
    {
        [TestMethod]
        public void GetUserByIDNegative()
        {
            // Arrange
            int userID = -1;
            User newUser = new User();

            var mockUserDAL = new Mock<IUserDAL>();

            UserContainer userContainer = new UserContainer(mockUserDAL.Object);

            // Act
            User returnedUser = userContainer.GetUserById(userID);

            // Assert
            Assert.AreEqual(newUser.Id, returnedUser.Id);
        }

        [TestMethod]
        public void GetUserByIDZero()
        {
            // Arrange
            int userID = 0;

            var mockUserDAL = new Mock<IUserDAL>();

            UserContainer userContainer = new UserContainer(mockUserDAL.Object);

            // Act
            User returnedUser = userContainer.GetUserById(userID);

            // Assert
            Assert.AreEqual(userID, returnedUser.Id);
        }

        [TestMethod]
        public void GetUserByIDOne()
        {
            // Arrange
            int userID = 1;
            UserDTO testUser = new UserDTO()
            {
                FirstName = "Lex",
            };

            var mockUserDAL = new Mock<IUserDAL>();
            mockUserDAL.Setup(m => m.GetById(It.IsAny<int>())).Returns(testUser);

            UserContainer userContainer = new UserContainer(mockUserDAL.Object);

            // Act
            User returnedUser = userContainer.GetUserById(userID);

            // Assert
            Assert.AreEqual(testUser.FirstName, returnedUser.FirstName);
        }
    }
}
