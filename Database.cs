using System.Data.SQLite;

// Should be created at the start if none exists.
// Should have a table created if none exists. 
// Should have columns for Id, Project, Date, and Duration

namespace CodeTracker {
    public class Database {
        private readonly string connectionString;

        public Database (string connectionString) {
            this.connectionString = connectionString;
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