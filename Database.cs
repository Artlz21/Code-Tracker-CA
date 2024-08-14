using System.Data.SQLite;

namespace CodeTracker {
    public class Database {
        private readonly string connectionString;

        public Database (string cs) {
            this.connectionString = cs;
            CreateDatabase();
        }
        private void CreateDatabase () {
            try {
                using var connection = new SQLiteConnection(this.connectionString);
                connection.Open();
                var Command = connection.CreateCommand();

                Command.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Code_Projects(
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name STRING,
                            Date STRING,
                            Duration STRING
                            )
                    ";
                Command.ExecuteNonQuery();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}