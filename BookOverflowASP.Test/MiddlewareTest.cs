using Moq;
using Microsoft.AspNetCore.Http;
using BookOverflowASP.Library.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Collections.Generic;

namespace BookOverflowASP.Test
{
    [TestClass]
    public class MiddlewareTest
    {
        [TestMethod]
        public void AdminCanGoToAdminPage()
        {
            // Arrange
            PermissionType currentPermissionType = PermissionType.Admin;
            PermissionType neededPermissiongType = PermissionType.Admin;

            var mockSessionHandler = new Mock<ISessionHandler>();
            mockSessionHandler.Setup(m => m.GetPermissionType(It.IsAny<HttpContext>())).Returns(currentPermissionType);

            Middleware middleware = new Middleware(mockSessionHandler.Object);

            // Act
            bool result = middleware.CheckUserPermission(neededPermissiongType, null);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UserCanGoToAdminPage()
        {
            // Arrange
            PermissionType currentPermissionType = PermissionType.User;
            PermissionType neededPermissiongType = PermissionType.Admin;

            var mockSessionHandler = new Mock<ISessionHandler>();
            mockSessionHandler.Setup(m => m.GetPermissionType(It.IsAny<HttpContext>())).Returns(currentPermissionType);

            Middleware middleware = new Middleware(mockSessionHandler.Object);

            // Act
            bool result = middleware.CheckUserPermission(neededPermissiongType, null);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void NoneCanGoToAdminPage()
        {
            // Arrange
            PermissionType currentPermissionType = PermissionType.None;
            PermissionType neededPermissiongType = PermissionType.Admin;

            var mockSessionHandler = new Mock<ISessionHandler>();
            mockSessionHandler.Setup(m => m.GetPermissionType(It.IsAny<HttpContext>())).Returns(currentPermissionType);

            Middleware middleware = new Middleware(mockSessionHandler.Object);

            // Act
            bool result = middleware.CheckUserPermission(neededPermissiongType, null);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void AdminCanGoToUserPage()
        {
            // Arrange
            PermissionType currentPermissionType = PermissionType.Admin;
            PermissionType neededPermissiongType = PermissionType.User;

            var mockSessionHandler = new Mock<ISessionHandler>();
            mockSessionHandler.Setup(m => m.GetPermissionType(It.IsAny<HttpContext>())).Returns(currentPermissionType);

            Middleware middleware = new Middleware(mockSessionHandler.Object);

            // Act
            bool result = middleware.CheckUserPermission(neededPermissiongType, null);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void UserCanGoToUserPage()
        {
            // Arrange
            PermissionType currentPermissionType = PermissionType.User;
            PermissionType neededPermissiongType = PermissionType.User;

            var mockSessionHandler = new Mock<ISessionHandler>();
            mockSessionHandler.Setup(m => m.GetPermissionType(It.IsAny<HttpContext>())).Returns(currentPermissionType);

            Middleware middleware = new Middleware(mockSessionHandler.Object);

            // Act
            bool result = middleware.CheckUserPermission(neededPermissiongType, null);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void NoneCanGoToUserPage()
        {
            // Arrange
            PermissionType currentPermissionType = PermissionType.None;
            PermissionType neededPermissiongType = PermissionType.User;

            var mockSessionHandler = new Mock<ISessionHandler>();
            mockSessionHandler.Setup(m => m.GetPermissionType(It.IsAny<HttpContext>())).Returns(currentPermissionType);

            Middleware middleware = new Middleware(mockSessionHandler.Object);

            // Act
            bool result = middleware.CheckUserPermission(neededPermissiongType, null);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void AdminCanGoToNonePage()
        {
            // Arrange
            PermissionType currentPermissionType = PermissionType.Admin;
            PermissionType neededPermissiongType = PermissionType.None;

            var mockSessionHandler = new Mock<ISessionHandler>();
            mockSessionHandler.Setup(m => m.GetPermissionType(It.IsAny<HttpContext>())).Returns(currentPermissionType);

            Middleware middleware = new Middleware(mockSessionHandler.Object);

            // Act
            bool result = middleware.CheckUserPermission(neededPermissiongType, null);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void UserCanGoToNonePage()
        {
            // Arrange
            PermissionType currentPermissionType = PermissionType.User;
            PermissionType neededPermissiongType = PermissionType.None;

            var mockSessionHandler = new Mock<ISessionHandler>();
            mockSessionHandler.Setup(m => m.GetPermissionType(It.IsAny<HttpContext>())).Returns(currentPermissionType);

            Middleware middleware = new Middleware(mockSessionHandler.Object);

            // Act
            bool result = middleware.CheckUserPermission(neededPermissiongType, null);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void NoneCanGoToNonePage()
        {
            // Arrange
            PermissionType currentPermissionType = PermissionType.None;
            PermissionType neededPermissiongType = PermissionType.None;

            var mockSessionHandler = new Mock<ISessionHandler>();
            mockSessionHandler.Setup(m => m.GetPermissionType(It.IsAny<HttpContext>())).Returns(currentPermissionType);

            Middleware middleware = new Middleware(mockSessionHandler.Object);

            // Act
            bool result = middleware.CheckUserPermission(neededPermissiongType, null);

            // Assert
            Assert.AreEqual(true, result);
        }
    }
}
