using Microsoft.AspNetCore.Http;
using Logic = BookOverflowASP.Library.Logic;

namespace BookOverflowASP
{
    public interface IMiddleware
    {
        bool CheckUserPermission(Logic.PermissionType neededPermissionType, HttpContext context);
    }
}