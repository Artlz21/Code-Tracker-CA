namespace CodeTracker {
    class Program
    {
        static void Main(string[] args)
        {
            ProjectEntry projectEntry = new(1, "Dar", "10-10-2022", "02:00");
            
            Table table= new Table();
            table.AddRow(projectEntry);
            table.ShowTable();
            // Database database= new Database("Data Source=Code_Tracker.db");
            // Menu menu = new Menu();
            // menu.RunApp();
        }
    }
}