using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using BookOverflowASP.Logic;
using System.Linq;
using System.Threading.Tasks;

namespace BookOverflowASP.Data
{
    public class CourseDAL
    {
        public static bool Save(CourseDTO courseDto)
        {
            Database database = new Database();

            if (!database.OpenConnection())
                // FIXME: throw exception;
                return false;

            // Insert items into database
            database.command.CommandText = "INSERT INTO courses(name) VALUES (@name)";

            // bind some shit
            database.command.Parameters.AddWithValue("name", courseDto.Name);

            int result = database.command.ExecuteNonQuery();

            if (result > 0)
                return true;
            return false;
        }

        public static List<CourseDTO> GetAll(int limit)
        {
            Database database = new Database();

            if (!database.OpenConnection())
                // FIXME: throw exception;
                return null;

            if (limit == -1) 
            {
                database.command.CommandText = "SELECT * FROM courses WHERE deleted_at IS NULL";
            } 
            else 
            {
                database.command.CommandText = "SELECT * FROM courses WHERE deleted_at IS NULL LIMIT @limit";

                database.command.Parameters.AddWithValue("limit", limit);
            }

            MySqlDataReader result = database.command.ExecuteReader();

            List<CourseDTO> items = new List<CourseDTO>();
            while (result.Read())
            {
                CourseDTO temp = new CourseDTO();

                temp.Id = result.GetInt16(0);
                temp.Name = result.GetString(1);
                temp.CreatedAt = result.GetDateTime(2);
                try {
                    temp.DeletedAt = result.GetDateTime(3);
                } catch (Exception) {}

                items.Add(temp);
            }

            return items;
        }

        public static CourseDTO GetById(int id)
        {
            Database database = new Database();

            if (!database.OpenConnection())
                // FIXME: throw exception;
                return null;

            database.command.CommandText = "SELECT * FROM courses WHERE id = @id AND deleted_at IS NULL";

            database.command.Parameters.AddWithValue("id", id);

            MySqlDataReader result = database.command.ExecuteReader();

            CourseDTO item = new CourseDTO();
            while (result.Read())
            {
                item.Id = result.GetInt16(0); // ID
                item.Name = result.GetString(1); // Name
                item.CreatedAt = result.GetDateTime(2); // CreatedAt
                try {
                    item.DeletedAt = result.GetDateTime(3); // DeletedAt
                } catch (Exception) {}
                try {
                    item.DeletedBy = result.GetInt32(4); // DeletedBy
                } catch (Exception) {}
            }

            return item;
        }

        public static bool Update(CourseDTO courseDto)
        {
            // TODO: Doe de shit
            Database database = new Database();

            if (!database.OpenConnection())
                // FIXME: throw exception;
                return false;

            // Insert items into database
            database.command.CommandText = "UPDATE courses SET name=@name WHERE ID = @id";

            // bind some shit
            database.command.Parameters.AddWithValue("name", courseDto.Name);
            database.command.Parameters.AddWithValue("id", courseDto.Id);

            int result = database.command.ExecuteNonQuery();

            if (result > 0)
                return true;
            return false;
        }

        public static bool Remove(int courseId, int userId)
        {
            Database database = new Database();

            if (!database.OpenConnection())
                // FIXME: throw exception;
                return false;

            database.command.CommandText = "UPDATE courses SET deleted_at=@deleted_at, deleted_by=@deleted_by WHERE id = @id";

            database.command.Parameters.AddWithValue("deleted_at", DateTime.Now);
            database.command.Parameters.AddWithValue("deleted_by", userId);

            database.command.Parameters.AddWithValue("id", courseId);

            int affectedRows = database.command.ExecuteNonQuery();

            if (affectedRows > 0)
                return true;
            return false;
        }
    }
}
