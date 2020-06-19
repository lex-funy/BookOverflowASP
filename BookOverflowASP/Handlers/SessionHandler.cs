using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using BookOverflowASP.Library.Logic;

namespace BookOverflowASP
{
    public class SessionHandler : ISessionHandler
    {
        public void SetUserId(int userId, HttpContext context)
        {
            context.Session.SetInt32("id", userId);
        }

        public void SetPermission(PermissionType permission, HttpContext context)
        {
            context.Session.SetInt32("permission", (int)permission);

            int? temp = context.Session.GetInt32("permission");
        }

        public void ClearSession(HttpContext context)
        {
            context.Session.Clear();
        }

        public int GetUserID(HttpContext context)
        {
            int userId = 0;

            if (context.Session.GetInt32("id") != null)
                userId = (int)context.Session.GetInt32("id");

            return userId;
        }

        public PermissionType GetPermissionType(HttpContext context)
        {
            PermissionType permission = PermissionType.None;

            int? temp = context.Session.GetInt32("permission");

            if (temp != null)
                permission = (PermissionType)temp;

            return permission;
        }

        public void AddBookToCart(int bookId, HttpContext context) 
        {
            if (context.Session.GetString("cart") != null)
            {
                context.Session.SetString("cart", $"{context.Session.GetString("cart")},{bookId}");
            } 
            else
            {
                context.Session.SetString("cart", bookId.ToString());
            }
        }

        public List<int> GetBooksFromCart(HttpContext context)
        {
            if (context.Session.GetString("cart") != null)
            {
                List<int> output = new List<int>();

                string books = context.Session.GetString("cart");
                foreach (string book in books.Split(','))
                {
                    output.Add(int.Parse(book));
                }

                return output;
            }
            return new List<int>();
        }

        public void ClearBooks(HttpContext context) 
        {
            context.Session.Remove("cart");
        }
    }
}
