using System.Collections.Generic;

namespace BookOverflowASP.Library.Logic
{
    public interface IUserContainer
    {
        List<User> GetAllUsers(int limit = -1);
        User GetByEmailAndPassword(User user);
        User GetUserById(int id);
        bool Save(User user);
    }
}