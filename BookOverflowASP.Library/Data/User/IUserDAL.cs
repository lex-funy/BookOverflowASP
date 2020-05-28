using System.Collections.Generic;

namespace BookOverflowASP.Library.Data
{
    public interface IUserDAL
    {
        List<UserDTO> GetAll(int limit);
        List<UserDTO> GetAllByName(string firstName, string insertion, string lastName);
        UserDTO GetByEmailAndPassword(UserDTO userDTO);
        UserDTO GetById(int id);
        bool Save(UserDTO user);
    }
}