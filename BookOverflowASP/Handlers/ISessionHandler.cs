using Logic = BookOverflowASP.Library.Logic;

using Microsoft.AspNetCore.Http;


namespace BookOverflowASP
{
    public interface ISessionHandler
    {
        void ClearSession(HttpContext context);
        Logic.PermissionType GetPermissionType(HttpContext context);
        int GetUserID(HttpContext context);
        void SetPermission(Logic.PermissionType permission, HttpContext context);
        void SetUserId(int userId, HttpContext context);
    }
}