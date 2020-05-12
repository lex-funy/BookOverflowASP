using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookOverflowASP.Data
{
    public class BookDAL
    {
        public static bool Save(BookDTO bookDto)
        {
            // TODO: Connect to database
            Database database = new Database();

            if (!database.OpenConnection())
                // FIXME: throw exception;
                return false;

            // Insert items into database
            database.command.CommandText = "INSERT INTO books(name, quality_rating, price) VALUES (@name, @quality_rating, @price)";

            // bind some shit
            database.command.Parameters.AddWithValue("name", bookDto.Name);
            database.command.Parameters.AddWithValue("quality_rating", bookDto.QualityRating);
            database.command.Parameters.AddWithValue("price", bookDto.Price);

            int result = database.command.ExecuteNonQuery();

            database.CloseConnection();

            if (result > 0)
                return true;
            return false;
        }

        public static bool Update(BookDTO bookDto)
        {
            Database database = new Database();

            if (!database.OpenConnection())
                // FIXME: throw exception;
                return false;

            // Insert items into database
            database.command.CommandText = "UPDATE books SET name=@name, quality_rating=@quality_rating, price=@price WHERE ID = @id";

            // bind some shit
            database.command.Parameters.AddWithValue("id", bookDto.Id);
            database.command.Parameters.AddWithValue("name", bookDto.Name);
            database.command.Parameters.AddWithValue("quality_rating", bookDto.QualityRating);
            database.command.Parameters.AddWithValue("price", bookDto.Price);

            int result = database.command.ExecuteNonQuery();

            database.CloseConnection();

            if (result > 0)
                return true;
            return false;
        }

        public static List<BookDTO> GetAll(int limit)
        {
            Database database = new Database();

            if (!database.OpenConnection())
                // FIXME: throw exception;
                return null;

            if (limit == -1) 
            {
                database.command.CommandText = "SELECT * FROM books WHERE deleted_at IS NULL";
            } 
            else 
            {
                database.command.CommandText = "SELECT * FROM books WHERE deleted_at IS NULL LIMIT @limit";

                database.command.Parameters.AddWithValue("limit", limit);
            }

            MySqlDataReader result = database.command.ExecuteReader();

            List<BookDTO> items = new List<BookDTO>();
            while (result.Read())
            {
                items.Add(new BookDTO(result));
            }

            database.CloseConnection();

            return items;
        }

        public static List<BookDTO> GetNewest(int limit) 
        {
            Database database = new Database();

            if (!database.OpenConnection())
                // FIXME: throw exception;
                return null;

            if (limit == -1) 
            {
                database.command.CommandText = "SELECT * FROM books WHERE deleted_at IS NULL ORDER BY created_at DESC";
            }
            else 
            {
                database.command.CommandText = "SELECT * FROM books WHERE deleted_at IS NULL ORDER BY created_at DESC LIMIT @limit";

                database.command.Parameters.AddWithValue("limit", limit);
            }

            MySqlDataReader result = database.command.ExecuteReader();

            List<BookDTO> items = new List<BookDTO>();
            while (result.Read())
            {
                items.Add(new BookDTO(result));
            }

            database.CloseConnection();

            return items;
        }

        public static BookDTO GetById(int id)
        {
            Database database = new Database();

            if (!database.OpenConnection())
                // FIXME: throw exception;
                return null;

            database.command.CommandText = "SELECT * FROM books WHERE id = @id AND deleted_at IS NULL";

            database.command.Parameters.AddWithValue("id", id);

            MySqlDataReader result = database.command.ExecuteReader();

            while (result.Read())
            {
                return new BookDTO(result);
            }

            database.CloseConnection();

            return new BookDTO();
        }

        public static bool Remove(int bookId, int userId)
        {
            Database database = new Database();

            if (!database.OpenConnection())
                // FIXME: throw exception;
                return false;

            database.command.CommandText = "UPDATE books SET deleted_at=@deleted_at, deleted_by=@deleted_by WHERE id = @id";

            database.command.Parameters.AddWithValue("deleted_at", DateTime.Now);
            database.command.Parameters.AddWithValue("deleted_by", userId);

            database.command.Parameters.AddWithValue("id", bookId);

            int affectedRows = database.command.ExecuteNonQuery();

            database.CloseConnection();

            if (affectedRows > 0)
                return true;
            return false;
        }
    }
}
