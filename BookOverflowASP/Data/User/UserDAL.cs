using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using BookOverflowASP.Logic;
using System.Linq;
using System.Threading.Tasks;

namespace BookOverflowASP.Data
{
    public class UserDAL
    {
        public static bool Save(UserDTO user)
        {
            Database database = new Database();

            if (!database.OpenConnection())
                return false;

            database.command.CommandText = "INSERT INTO users(image_id, email, password, first_name, insertion, last_name, permission, zip_code) VALUES (@image_id, @email, @password, @first_name, @insertion, @last_name, @permission, @zip_code)";

            database.command.Parameters.AddWithValue("@image_id", user.Image);
            database.command.Parameters.AddWithValue("@email", user.Email);
            database.command.Parameters.AddWithValue("@password", user.Password);
            database.command.Parameters.AddWithValue("@first_name", user.FirstName);
            database.command.Parameters.AddWithValue("@insertion", user.Insertion);
            database.command.Parameters.AddWithValue("@last_name", user.LastName);
            database.command.Parameters.AddWithValue("@permission", (int)PermissionType.User);
            database.command.Parameters.AddWithValue("@zip_code", user.ZipCode);

            int affectedRows = database.command.ExecuteNonQuery();

            database.CloseConnection();

            if (affectedRows > 0)
                return true;
            return false;
        }

        public static List<UserDTO> GetAll(int limit)
        {
            Database database = new Database();

            if (!database.OpenConnection())
                // FIXME: throw exception;
                return null;

            
            if (limit == -1) 
            {
                database.command.CommandText = "SELECT * FROM users WHERE deleted_at IS NULL";
            } 
            else 
            {
                database.command.CommandText = "SELECT * FROM users WHERE deleted_at IS NULL LIMIT @limit";

                database.command.Parameters.AddWithValue("limit", limit);
            }

            MySqlDataReader result = database.command.ExecuteReader();

            List<UserDTO> users = new List<UserDTO>();
            while (result.Read())
            {
                UserDTO temp = new UserDTO();

                temp.Id = result.GetInt16(0); // ID
                temp.Image = result.GetInt16(1); // image_id
                temp.Email = result.GetString(2); // email
                temp.Password = result.GetString(3); // password
                temp.FirstName = result.GetString(4); // first_name
                temp.Insertion = result.GetString(5); // insertion
                temp.LastName = result.GetString(6); // last_name
                temp.Permission = result.GetInt16(7); // permission
                temp.ZipCode = result.GetString(8); // zip_code
                temp.CreatedAt = result.GetDateTime(9); // created_at

                users.Add(temp);
            }

            return users;
        }

        public static UserDTO GetById(int id)
        {
            Database database = new Database();

            if (!database.OpenConnection())
                // FIXME: Throw exception;
                return new UserDTO();

            database.command.CommandText = "SELECT * FROM users WHERE ID = @id AND deleted_at IS NULL";
            database.command.Parameters.AddWithValue("id", id);

            MySqlDataReader result = database.command.ExecuteReader();

            UserDTO user = new UserDTO();

            while (result.Read())
            {
                user.Id = result.GetInt16(0); // ID
                user.Image = result.GetInt16(1); // image_id
                user.Email = result.GetString(2); // email
                user.Password = result.GetString(3); // password
                user.FirstName = result.GetString(4); // first_name
                user.Insertion = result.GetString(5); // insertion
                user.LastName = result.GetString(6); // last_name
                user.Permission = result.GetInt16(7); // permission
                user.ZipCode = result.GetString(8); // zip_code
                user.CreatedAt = result.GetDateTime(9); // created_at
            }

            return user;
        }

        public static List<UserDTO> GetAllByName(string firstName, string insertion, string lastName)
        {
            Database database = new Database();

            if (!database.OpenConnection())
                // FIXME: Throw exception
                return new List<UserDTO>();

            database.command.CommandText = "SELECT * FROM users WHERE first_name = @firstName AND insertion = @insertion AND last_name = @lastName AND deleted_at IS NULL";

            database.command.Parameters.AddWithValue("firstName", firstName);
            database.command.Parameters.AddWithValue("insertion", insertion);
            database.command.Parameters.AddWithValue("lastName", lastName);

            MySqlDataReader result = database.command.ExecuteReader();

            List<UserDTO> users = new List<UserDTO>();
            while (result.Read())
            {
                UserDTO temp = new UserDTO();

                temp.Id = result.GetInt16(0); // ID
                temp.Image = result.GetInt16(1); // image_id
                temp.Email = result.GetString(2); // email
                temp.Password = result.GetString(3); // password
                temp.FirstName = result.GetString(4); // first_name
                temp.Insertion = result.GetString(5); // insertion
                temp.LastName = result.GetString(6); // last_name
                temp.Permission = result.GetInt16(7); // permission
                temp.ZipCode = result.GetString(8); // zip_code
                temp.CreatedAt = result.GetDateTime(9); // created_at

                users.Add(temp);
            }

            return users;
        }
    }
}
