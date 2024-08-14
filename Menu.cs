using System.Globalization;

namespace CodeTracker {
    public class Menu {
        private List<ProjectEntry> entries = new();
        private string userInput = "";
        private bool exitApp = false;
        private int menuSelection = -1;
        private Table table = new();
        DatabaseManager databaseManager;
        public Menu (string cs) {
            databaseManager = new DatabaseManager(cs);
        }

        public void RunApp () {
            while (!exitApp) {
                MainMenu();
                userInput = Console.ReadLine() ?? "";

                if (int.TryParse(userInput, out menuSelection)) {
                    switch (menuSelection) {
                        case 0:
                            exitApp = true;
                            break;
                        case 1:
                            ShowEntries();
                            Console.WriteLine("Press enter to return to menu.");
                            Console.ReadLine();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("".PadLeft(25, '-'));
                            GetTableData();
                            Console.WriteLine("".PadLeft(25, '-'));
                            AddEntry();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("".PadLeft(25, '-'));
                            GetTableData();
                            Console.WriteLine("".PadLeft(25, '-'));
                            UpdateEntry();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("".PadLeft(25, '-'));
                            GetTableData();
                            Console.WriteLine("".PadLeft(25, '-'));
                            DeleteEntry();
                            break;
                        default:
                            Console.WriteLine("Please enter a valid input.");
                            break;
                    }
                }
                else {
                    Console.WriteLine("Please enter a valid input.");
                }
            }
        }

        private void MainMenu () {
            Console.Clear();
            Console.WriteLine("Main Menu\n");
            Console.WriteLine("Select an option from below.");
            Console.WriteLine("".PadLeft(25, '-'));
            Console.WriteLine("Enter 0 to close");
            Console.WriteLine("Enter 1 to View all records");
            Console.WriteLine("Enter 2 to Add new record");
            Console.WriteLine("Enter 3 to Update a record");
            Console.WriteLine("Enter 4 to Delete a record");
            Console.WriteLine("".PadLeft (25, '-'));
        }

        private void GetTableData() {
            try{
                entries = databaseManager.Get();
                table.CreateTable(entries);
                table.ShowTable();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void ShowEntries() {
            try {
                Console.Clear();
                Console.WriteLine("".PadLeft(50, '-'));
                GetTableData();
                Console.WriteLine("".PadLeft(50, '-'));
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

        private void AddEntry () {
            try {
                Console.WriteLine("Enter a Project name:");
                string projectName = Console.ReadLine() ?? "";
                Console.WriteLine("Enter a Date in the following format(MM/dd/yyyy):");
                string date = GetDateValue();
                Console.WriteLine("Enter a Time you started at using this format(hh:mm using 24 hour clock):");
                string startTime = GetTimeValue();
                Console.WriteLine("Enter a Time you ended at using this format(hh:mm using 24 hour clock):");
                string endTime = GetTimeValue();
                
                string duration = CalculateDuration(startTime, endTime);

                ProjectEntry entry = new ProjectEntry{
                    Name = projectName,
                    Date = date,
                    Duration = duration
                };

                databaseManager.Post(entry);
                ShowEntries();
            }
            catch (Exception ex) {
                Console.WriteLine("Error: Invalid format. " + ex.Message);
            }
            finally {
                Console.WriteLine("Press Enter to return to menu");
                Console.ReadLine();
            }
        }

        private void UpdateEntry() {
            try {
                Console.WriteLine("Select a project to update by Id:");
                string entryToUpdate = Console.ReadLine() ?? "";
                int entryIdToUpdate = -1;
                while(!int.TryParse(entryToUpdate, out entryIdToUpdate) && entryIdToUpdate < 0) {
                    Console.WriteLine("Please enter a valid Id");
                    entryToUpdate = Console.ReadLine() ?? "";
                }
                char updateOption = GetUpdateOption();

                string userInputUpdate;

                switch (updateOption) {
                    case 'N':
                        Console.WriteLine("Enter a name you want to update with:");
                        userInputUpdate = Console.ReadLine() ?? "";
                        Console.WriteLine(userInputUpdate);
                        break;
                    case 'D':
                        Console.WriteLine("Enter a new date with the following format(MM/dd/yyyy):");
                        userInputUpdate = GetDateValue();
                        Console.WriteLine(userInputUpdate);
                        break;
                    case 'U':
                        Console.WriteLine("Enter a new duration with the following format(HH:mm using 24 hour clock):");
                        userInputUpdate = GetTimeValue();
                        Console.WriteLine(userInputUpdate);
                        break;
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Error: Invalid format. " + ex.Message);
            }
            finally {
                Console.WriteLine("Press Enter to return to menu");
                Console.ReadLine();
            }
        }

        private void DeleteEntry() {
            try {
                Console.WriteLine("Select a project to delete by Id:");
                string enteredId = Console.ReadLine() ?? "";
                int entryIdToDelete = -1;
                while(!int.TryParse(enteredId, out entryIdToDelete) && entryIdToDelete < 0) {
                    Console.WriteLine("Please enter a valid Id");
                    enteredId = Console.ReadLine() ?? "";
                }

                Console.WriteLine($"Entry with ID {entryIdToDelete} deleted");
            }
            catch (Exception ex) {
                Console.WriteLine("Error: Invalid format. " + ex.Message);
            }
            finally {
                Console.WriteLine("Press Enter to return to menu");
                Console.ReadLine();
            }
        }

        private char GetUpdateOption() {
            Console.WriteLine("Select an option from below to update the entry. Enter a letter to select:");
            Console.WriteLine("N - Name, D - Date, U - Duration");
            string updateOption = Console.ReadLine() ?? "";
            char updateSelection;

            while(!char.TryParse(updateOption, out updateSelection) || 
                !(updateSelection == 'N' || updateSelection == 'D' || updateSelection == 'U' )) {
                Console.WriteLine("Please select a single character from the selection");
                updateOption = Console.ReadLine() ?? "";
            }

            return updateSelection;
        }

        private string GetDateValue() {
            string date = Console.ReadLine() ?? "";
            while(!DateTime.TryParseExact(date, "MM/dd/yyyy", null, DateTimeStyles.None, out _)){
                Console.WriteLine("Please enter a date in the format MM/dd/yyyy");
                date = Console.ReadLine() ?? "";
            }
            return date;
        }

        private string GetTimeValue() {
            string timeValue = Console.ReadLine() ?? "";
            while(!DateTime.TryParseExact(timeValue, "HH:mm", null, DateTimeStyles.None, out _)){
                Console.WriteLine("Please use this format(HH:mm using 24 hour clock):");
                timeValue = Console.ReadLine() ?? "";
            }
            return timeValue;
        }
        
        private string CalculateDuration(string start, string end) {
            DateTime startTime = DateTime.ParseExact(start, "HH:mm", null);
            DateTime endTime = DateTime.ParseExact(end, "HH:mm", null);

            if (endTime < startTime)
                endTime = endTime.AddDays(1);

            TimeSpan duration = endTime.Subtract(startTime);
            
            return duration.ToString(@"hh\:mm");
        }
    }
}