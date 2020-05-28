using Logic = BookOverflowASP.Library.Logic;
using Data = BookOverflowASP.Library.Data;

using BookOverflowASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookOverflowASP
{
    public class UserConverter
    {
        public Logic.User ToUser(UserModel userModel)
        {
            Logic.User user = new Logic.User
            {
                Id = userModel.Id,
                FirstName = userModel.FirstName,
                Insertion = userModel.Insertion,
                LastName = userModel.LastName,
                Email = userModel.LastName,
                Password = userModel.Password
            };

            return user;
        }

        public Logic.User ToUser(UserLoginModel userLoginModel)
        {
            Logic.User user = new Logic.User
            {
                Email = userLoginModel.Email,
                Password = userLoginModel.Password
            };

            return user;
        }

        public UserModel ToUserModel(Logic.User user)
        {
            UserModel userModel = new UserModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                Insertion = user.Insertion,
                LastName = user.LastName,
                Email = user.LastName,
                Password = user.Password
            };

            return userModel;
        }
    }
}
