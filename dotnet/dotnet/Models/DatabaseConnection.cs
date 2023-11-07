using MySql.Data.MySqlClient;

namespace dotnet.Models
{
    public class DatabaseConnection
    {
        public String ConnectionString { get; set; }

        public DatabaseConnection (string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection getConnection()
        {
            return new MySqlConnection (ConnectionString);
        }
    }
}
