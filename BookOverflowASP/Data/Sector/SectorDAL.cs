using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using BookOverflowASP.Logic;
using System.Linq;
using System.Threading.Tasks;

namespace BookOverflowASP.Data
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

            return items;
        }

        public static SectorDTO GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
