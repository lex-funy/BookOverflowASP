using System;
using BookOverflowASP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookOverflowASP.Data;
using BookOverflowASP.Logic;

namespace BookOverflowASP.Logic
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

        public static User GetByEmailAndPassword(UserLoginModel userLoginModel) 
        {
            UserDTO userDto = UserDAL.GetByEmailAndPassword(userLoginModel);

            return new User(userDto);
        }

        public static bool Save(UserModel user)
        {
            return UserDAL.Save(new UserDTO(user));
        }
    }
}
