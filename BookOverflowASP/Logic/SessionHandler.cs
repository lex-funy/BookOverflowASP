using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using BookOverflowASP.Logic;
using System.Threading.Tasks;
using BookOverflowASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookOverflowASP.Logic
{
    public class SessionHandler
    {       
        public static void SetUserId(int userId, HttpContext context)
        {
            context.Session.SetInt32("id", userId);
        }

        public static void SetPermission(PermissionType permission, HttpContext context)
        {
            context.Session.SetInt32("permission", (int)permission);
        }

        public static void ClearSession(HttpContext context)
        {
            context.Session.Clear();
        }

        public static int GetUserID(HttpContext context)
        {
            int userId = 0;

            if (context.Session.GetInt32("id") != null)
                userId = (int)context.Session.GetInt32("id");

            return userId;
        }

        public static PermissionType GetPermissionType(HttpContext context)
        {
            PermissionType permission = PermissionType.None;

            if (context.Session.GetInt32("permission") != null)
                permission = (PermissionType)context.Session.GetInt32("permission");

            return permission;
        }
    }
}
