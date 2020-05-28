using System;
using System.Linq;
using BookOverflowASP.Library.Logic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace BookOverflowASP
{
    public class Middleware : IMiddleware
    {
        private readonly ISessionHandler _sessionHandler;

        public Middleware(ISessionHandler sessionHandler)
        {
            this._sessionHandler = sessionHandler;
        }

        public bool CheckUserPermission(PermissionType neededPermissionType, HttpContext context)
        {
            if (this._sessionHandler.GetPermissionType(context) >= neededPermissionType)
                return true;
            return false;
        }
    }
}
