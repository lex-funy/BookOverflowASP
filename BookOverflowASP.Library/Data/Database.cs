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
            // Localhost
            //this.server = "localhost";
            //this.username = "root";
            //this.password = "";
            //this.database = "bookoverflow";

            // FHICT
            //this.server = "studmysql01.fhict.local";
            //this.username = "dbi433468";
            //this.password = "root";
            //this.database = "dbi433468";

            // Azure
            this.server = "433468-book-overflow.mysql.database.azure.com";
            this.username = "i433468@433468-book-overflow";
            this.password = "Root1324";
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
            catch (Exception e)
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
