using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using BookOverflowASP.Library.Logic;
using System.Linq;
using System.Threading.Tasks;

namespace BookOverflowASP.Library.Data
{
    public class SectorDAL
    {
        public static bool Save(SectorDTO sectorDto)
        {
            Database database = new Database();

            if (!database.OpenConnection())
                // FIXME: throw exception;
                return false;

            // Insert items into database
            database.command.CommandText = "INSERT INTO sectors(name) VALUES (@name)";

            // bind some shit
            database.command.Parameters.AddWithValue("name", sectorDto.Name);

            int result = database.command.ExecuteNonQuery();

            database.CloseConnection();

            if (result > 0)
                return true;
            return false;
        }

        public static List<SectorDTO> GetAll(int limit)
        {
            Database database = new Database();

            if (!database.OpenConnection())
                // FIXME: throw exception;
                return null;

            if (limit == -1) 
            {
                database.command.CommandText = "SELECT * FROM sectors WHERE deleted_at IS NULL";
            } 
            else 
            {
                database.command.CommandText = "SELECT * FROM sectors WHERE deleted_at IS NULL LIMIT @limit";

                database.command.Parameters.AddWithValue("limit", limit);
            }

            MySqlDataReader result = database.command.ExecuteReader();

            List<SectorDTO> items = new List<SectorDTO>();
            while (result.Read())
            {
                SectorDTO temp = new SectorDTO();

                temp.Id = result.GetInt16(0);
                temp.Name = result.GetString(1);
                temp.CreatedAt = result.GetDateTime(2);
                try {
                    temp.DeletedAt = result.GetDateTime(3);
                } catch (Exception) {}

                items.Add(temp);
            }

            database.CloseConnection();

            return items;
        }

        public static SectorDTO GetById(int id)
        {
            Database database = new Database();

            if (!database.OpenConnection())
                // FIXME: throw exception;
                return null;

            database.command.CommandText = "SELECT * FROM sectors WHERE id = @id AND deleted_at IS NULL";

            database.command.Parameters.AddWithValue("id", id);

            MySqlDataReader result = database.command.ExecuteReader();

            SectorDTO item = new SectorDTO();
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

            database.CloseConnection();

            return item;
        }

        public static bool Update(SectorDTO sectorDto)
        {
            // TODO: Doe de shit
            Database database = new Database();

            if (!database.OpenConnection())
                // FIXME: throw exception;
                return false;

            // Insert items into database
            database.command.CommandText = "UPDATE sectors SET name=@name WHERE ID = @id";

            // bind some shit
            database.command.Parameters.AddWithValue("name", sectorDto.Name);
            database.command.Parameters.AddWithValue("id", sectorDto.Id);

            int result = database.command.ExecuteNonQuery();

            database.CloseConnection();

            if (result > 0)
                return true;
            return false;
        }

        public static bool Remove(int sectorId, int userId)
        {
            Database database = new Database();

            if (!database.OpenConnection())
                // FIXME: throw exception;
                return false;

            database.command.CommandText = "UPDATE sectors SET deleted_at=@deleted_at, deleted_by=@deleted_by WHERE id = @id";

            database.command.Parameters.AddWithValue("deleted_at", DateTime.Now);
            database.command.Parameters.AddWithValue("deleted_by", userId);

            database.command.Parameters.AddWithValue("id", sectorId);

            int affectedRows = database.command.ExecuteNonQuery();

            database.CloseConnection();

            if (affectedRows > 0)
                return true;
            return false;
        }
    }
}
