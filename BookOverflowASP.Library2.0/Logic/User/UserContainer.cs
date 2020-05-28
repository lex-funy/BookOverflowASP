using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookOverflowASP.Library.Data;

namespace BookOverflowASP.Library.Logic
{
    public class UserContainer
    {
        public static List<User> GetAllUsers(int limit = -1)
        {
            List<UserDTO> usersDto = UserDAL.GetAll(limit);

            List<User> users = new List<User>();
            foreach (UserDTO user in usersDto)
            {
                users.Add(new User(user));
            }

            return users;
        }

        public static User GetUserById(int id)
        {
            if (id == 0) {
                return new User();
            }

            UserDTO userDto = UserDAL.GetById(id);

            
            User user = new User(userDto);

            return user;
        }

        public static User GetByEmailAndPassword(User user) 
        {
            UserDTO userDto = UserDAL.GetByEmailAndPassword(new UserDTO(user));

            return new User(userDto);
        }

        public static bool Save(User user)
        {
            return UserDAL.Save(new UserDTO(user));
        }
    }
}
