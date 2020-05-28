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

            if (context.Session.GetInt32("permission") != null)
                permission = (PermissionType)context.Session.GetInt32("permission");

            return permission;
        }
    }
}
