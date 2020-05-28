using Logic = BookOverflowASP.Library.Logic;

using Moq;
using BookOverflowASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using BookOverflowASP.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace BookOverflowASP.Test
{
    [TestClass]
    public class BookControllerTest
    {
        [TestMethod]
        public void IndexReturnsAllBooks()
        {
            // Arrange
            List<Logic.Book> books = new List<Logic.Book>() {
                new Logic.Book(),
                new Logic.Book()
            };

            var mockBookContainer = new Mock<Logic.IBookContainer>();
            mockBookContainer.Setup(m => m.GetAllBooks(It.IsAny<int>())).Returns(books);

            var mockSessionHandler = new Mock<ISessionHandler>();
            mockSessionHandler.Setup(m => m.GetPermissionType(It.IsAny<HttpContext>())).Returns(
                Logic.PermissionType.User
            );

            var mockMiddleware = new Mock<IMiddleware>();
            mockMiddleware.Setup(m => m.CheckUserPermission(It.IsAny<Logic.PermissionType>(), It.IsAny<HttpContext>())).Returns(true);

            // bookController
            BookController target = new BookController(mockBookContainer.Object, mockSessionHandler.Object, mockMiddleware.Object);

            // Act
            var result = target.Index();

            // Assert

            // Result is an IActionResult but we need the BookIndexViewModel so we have to cast the model.
            var returnModel = (result as ViewResult).Model as BookIndexViewModel;

            Assert.IsInstanceOfType(returnModel, typeof(BookIndexViewModel));
            Assert.AreEqual(books.Count, returnModel.Books.Count);
        }

        // IndexReturnCorrectData
    }
}
