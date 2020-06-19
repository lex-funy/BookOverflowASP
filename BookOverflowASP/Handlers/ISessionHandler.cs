using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using BookOverflowASP.Library.Logic;

namespace BookOverflowASP
{
    public interface ISessionHandler
    {
        void ClearSession(HttpContext context);
        PermissionType GetPermissionType(HttpContext context);
        int GetUserID(HttpContext context);
        void SetPermission(PermissionType permission, HttpContext context);
        void SetUserId(int userId, HttpContext context);
        void AddBookToCart(int bookId, HttpContext context);
        List<int> GetBooksFromCart(HttpContext context);
        void ClearBooks(HttpContext context);
    }
}