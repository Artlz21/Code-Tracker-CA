using Spectre.Console;

namespace CodeTracker {
    public class Table{
        
        private Grid grid;
        public Table() {
            CreateTable();
        }

        private void CreateTable() {
            grid = new Grid();
            grid.AddColumn();
            grid.AddColumn();
            grid.AddColumn();
            grid.AddColumn();

            grid.AddRow(new string[]{"ID", "Name", "Date", "Duration"});
        }

        public void ShowTable() {
            AnsiConsole.Write(grid);
        }

        public void AddRow(ProjectEntry projectEntry) {
            grid.AddRow(new string[]{$"{projectEntry.Id}", $"{projectEntry.Name}", $"{projectEntry.Date}", $"{projectEntry.Duration}"});
        }
    }
}