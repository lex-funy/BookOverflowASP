using System;
using System.Linq;
using BookOverflowASP.Logic;
using BookOverflowASP.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace BookOverflowASP.Logic
{
    public class Middleware
    {       
        public static bool CheckUserPermission(PermissionType neededPermissionType, HttpContext context) 
        {
            if (SessionHandler.GetPermissionType(context) >= neededPermissionType) 
                return true;
            return false;
        }
    }
}
