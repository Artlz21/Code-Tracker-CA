using Spectre.Console;

namespace CodeTracker {
    public class Table{
        private Grid grid;

        public Table() {
            grid = new Grid();
        }

        public void CreateTable(List<ProjectEntry> entries) {
            grid = new Grid();
            grid.AddColumn();
            grid.AddColumn();
            grid.AddColumn();
            grid.AddColumn();

            grid.AddRow(new string[]{"ID", "Name", "Date", "Duration"});

            foreach (var entry in entries) {
                grid.AddRow(new string[]{$"{entry.Id}", $"{entry.Name}", $"{entry.Date}", $"{entry.Duration}"});
            }
        }

        public void ShowTable() {
            AnsiConsole.Write(grid);
        }
    }
}