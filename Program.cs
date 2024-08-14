namespace CodeTracker {
    class Program
    {
        static void Main(string[] args)
        {
            Database database= new Database("Data Source=Code_Tracker.db");
            Menu menu = new Menu("Data Source=Code_Tracker.db");
            menu.RunApp();
        }
    }
}