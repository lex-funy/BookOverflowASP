using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookOverflowASP.Library.Data
{
    class Database
    {
        private string server;
        private string username;
        private string password;
        private string database;

        private MySqlConnection connection;
        public MySqlCommand command;

        public Database()
        {
            // TODO: Put in config.
            this.server = "localhost";
            this.username = "root";
            this.password = "";
            this.database = "bookoverflow";
        }

        public bool OpenConnection()
        {
            string connectionString = $"server={this.server};userid={this.username};password={this.password};database={this.database}";

            this.connection = new MySqlConnection(connectionString);

            try
            {
                this.connection.Open();

                this.command = this.connection.CreateCommand();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public void CloseConnection()
        {
            this.connection.Close();
        }
    }
}
