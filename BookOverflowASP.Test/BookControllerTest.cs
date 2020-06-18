using Moq;
using BookOverflowASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using BookOverflowASP.Controllers;
using BookOverflowASP.Library.Logic;
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
            List<Book> books = new List<Book>() {
                new Book(),
                new Book()
            };

            var mockBookContainer = new Mock<IBookContainer>();
            mockBookContainer.Setup(m => m.GetAllBooks(It.IsAny<int>())).Returns(books);

            var mockSessionHandler = new Mock<ISessionHandler>();
            mockSessionHandler.Setup(m => m.GetPermissionType(It.IsAny<HttpContext>())).Returns(
                PermissionType.User
            );

            var mockMiddleware = new Mock<IMiddleware>();
            mockMiddleware.Setup(m => m.CheckUserPermission(It.IsAny<PermissionType>(), It.IsAny<HttpContext>())).Returns(true);

            BookController target = new BookController(mockBookContainer.Object, mockSessionHandler.Object, mockMiddleware.Object);

            // Act
            var result = target.Index();

            // Assert
            // Result is an IActionResult but we need the BookIndexViewModel so we have to cast the model but that result also needs to be casted to a ViewResult to get the Model.
            var returnModel = (result as ViewResult).Model as BookIndexViewModel;

            Assert.IsInstanceOfType(returnModel, typeof(BookIndexViewModel));
            Assert.AreEqual(books.Count, returnModel.Books.Count);
        }

        // IndexReturnsCorrectData
    }
}
