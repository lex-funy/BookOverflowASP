using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookOverflowASP.Library.Data;

namespace BookOverflowASP.Library.Logic
{
    public class UserContainer : IUserContainer
    {
        private readonly IUserDAL _userDAL;

        public UserContainer(IUserDAL userDAL)
        {
            this._userDAL = userDAL;
        }

        public List<User> GetAllUsers(int limit = -1)
        {
            List<UserDTO> usersDto = this._userDAL.GetAll(limit);

            List<User> users = new List<User>();
            foreach (UserDTO user in usersDto)
            {
                User deletedBy = this.GetUserById(user.DeletedBy);

                users.Add(new User(user, deletedBy));
            }

            return users;
        }

        public User GetUserById(int id)
        {
            if (id == 0)
                return new User();

            UserDTO userDto = this._userDAL.GetById(id);

            // Possible infinite loop
            User deletedBy = this.GetUserById(userDto.DeletedBy);

            User user = new User(userDto, deletedBy);

            return user;
        }

        public User GetByEmailAndPassword(User user)
        {
            UserDTO userDto = this._userDAL.GetByEmailAndPassword(new UserDTO(user));

            User deletedBy = this.GetUserById(userDto.DeletedBy);

            return new User(userDto, deletedBy);
        }

        public bool Save(User user)
        {
            return this._userDAL.Save(new UserDTO(user));
        }
    }
}
