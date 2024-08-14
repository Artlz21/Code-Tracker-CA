using System.Configuration;

namespace CodeTracker {
    class Program
    {
        static void Main(string[] args)
        {
            string? connectionString = ConfigurationManager.AppSettings["connectionString"];
            
            if (connectionString == null)
                return;

            Database database = new Database(connectionString);
            Menu menu = new Menu(connectionString);
            
            menu.RunApp();
        }
    }
}
