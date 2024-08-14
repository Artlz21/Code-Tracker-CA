using System.Data.SQLite;

namespace CodeTracker {
    public class DatabaseManager {
        private string connectionString = "";
        public DatabaseManager (string cs) {
            connectionString = cs;
        }
        
        // Method to handle Viewing content in db
        public List<ProjectEntry> Get() {
            List<ProjectEntry> entries = new ();
            using(var connection = new SQLiteConnection(connectionString)) {
                using(var command = connection.CreateCommand()) {
                    connection.Open();
                    command.CommandText = "Select * FROM Code_Projects";

                    using(var reader = command.ExecuteReader()) {
                        if (reader.HasRows) {
                            while (reader.Read()) {
                                entries.Add(new ProjectEntry{
                                    Id = reader.GetInt32(0), 
                                    Name = reader.GetString(1), 
                                    Date = reader.GetString(2), 
                                    Duration = reader.GetString(3)
                                });
                            }
                        }
                        else {
                            Console.WriteLine("No data found...");
                        }
                    }
                }
            }

            return entries;
        }

        public ProjectEntry? GetById(int Id) {
            ProjectEntry entry;

            try {
                using(var connection = new SQLiteConnection(connectionString)) {
                    using(var command = connection.CreateCommand()) {
                        connection.Open();
                        command.CommandText = $"Select * FROM Code_Projects WHERE Id = {Id}";

                        using(var reader = command.ExecuteReader()) {
                            if (reader.HasRows) {
                                reader.Read();

                                entry = new ProjectEntry{
                                    Id = reader.IsDBNull(0) ? null : reader.GetInt32(0),
                                    Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                    Date = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                                    Duration = reader.IsDBNull(3) ? string.Empty : reader.GetString(3)
                                };

                                return entry;
                            }
                            else {
                                Console.WriteLine("No data found...");
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Error: Could not find data" + ex.Message);
            }

            return null;
        }

        // Method to handle Adding to db
        public void Post(ProjectEntry projectEntry) {
            using(var connection = new SQLiteConnection(connectionString)) {
                using(var command = connection.CreateCommand()) {
                    connection.Open();
                    command.CommandText = $"INSERT INTO Code_Projects (Name, Date, Duration) VALUES ('{projectEntry.Name}', '{projectEntry.Date}', '{projectEntry.Duration}')";
                    command.ExecuteNonQuery();
                }
            }
        }

        // Method to handle Updating db
        public void Update(ProjectEntry projectEntry, int entryId) {
            using(var connection = new SQLiteConnection(connectionString)) {
                using(var command = connection.CreateCommand()) {
                    connection.Open();
                    command.CommandText = $@"UPDATE Code_Projects SET 
                    Name = '{projectEntry.Name}', Date = '{projectEntry.Date}', Duration = '{projectEntry.Duration}'
                    WHERE Id = {entryId}";

                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine($"Project with Id {projectEntry.Id} was updated");
        }

        // Method to handle Deleting from db
        public void Delete(int Id) {
            using(var connection = new SQLiteConnection(connectionString)) {
                using(var command = connection.CreateCommand()){
                    connection.Open();
                    command.CommandText = $"DELETE FROM Code_Projects WHERE Id = {Id}";
                    command.ExecuteNonQuery();
                }
            }
            Console.WriteLine($"Project with Id {Id} was deleted");
        }
    }
}