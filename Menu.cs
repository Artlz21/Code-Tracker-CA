// - User should see a menu giving options of what
// they can do.
// - User should be able to enter 0 and exit app.
// - User should select an option and be taken to a 
// menu for that option that displays data and a 
// menu of options.
// - User should be shown proper format for each
// entry in a given menu.
// - User should enter StartTime and EndTime to 
// calculate duration.

namespace CodeTracker {
    public class Menu {
        private List<ProjectEntry> entries = new();
        private string userInput = "";
        private bool exitApp = false;
        private int menuSelection = -1;
        // public Menu () {

        // }

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
                            Console.WriteLine("".PadLeft(25, '-'));
                            Console.WriteLine("Table with data");
                            Console.WriteLine("".PadLeft(25, '-'));
                            Console.WriteLine("Press enter to return to menu.");
                            Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("".PadLeft(25, '-'));
                            Console.WriteLine("Table with data");
                            Console.WriteLine("".PadLeft(25, '-'));
                            AddEntry();
                            break;
                        case 3:
                            Console.WriteLine("".PadLeft(25, '-'));
                            Console.WriteLine("Table with data");
                            Console.WriteLine("".PadLeft(25, '-'));
                            UpdateEntry();
                            break;
                        case 4:
                            Console.WriteLine("".PadLeft(25, '-'));
                            Console.WriteLine("Table with data");
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

        private void AddEntry () {
            Console.WriteLine("Enter a Project name:");
            Console.ReadLine();
            Console.WriteLine("Enter a Date in the following format(dd-MM-yyyy):");
            Console.ReadLine();
            Console.WriteLine("Enter a Time you started at using this format(hh:mm using 12 hour clock):");
            Console.ReadLine();
            Console.WriteLine("Enter a Time you ended at using this format(hh:mm using 12 hour clock):");
            Console.ReadLine();
        }

        private void UpdateEntry() {
            Console.WriteLine("Select a project to update by Id:");
            Console.ReadLine();
            Console.WriteLine("Select an option from below to update the entry. Enter a letter to select:");
            Console.WriteLine("N - Name, D - Date, U - Duration");
            Console.ReadLine();
        }

        private void DeleteEntry() {
            Console.WriteLine("Select a project to delete by Id:");
            Console.ReadLine();
        }

        // private void AddEntry () {
        //     Console.WriteLine("Enter a project name");
        //     string projectName = Console.ReadLine() ?? "";
            
        //     string date = GetDateValue();
        //     DateTime startTime = GetStartTimeValue();
        //     DateTime endTime = GetEndTimeValue();
        //     string duration = CalculateDuration(startTime, endTime);
        //     Console.WriteLine(duration);

        //     ProjectEntry projectEntry = new()
        //     {
        //         Name = projectName,
        //         Date = date,
        //         Duration = duration
        //     };

        //     entries.Add(projectEntry);         
        // }

        // private string GetDateValue () {
        //     Console.WriteLine("Enter the date in the following format dd-mm-yyyy");
        //     string date = Console.ReadLine() ?? "";

        //     while(!DateTime.TryParseExact(date, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out _)) {
        //         Console.WriteLine("Please enter a date in the format dd-mm-yyyy");
        //         date = Console.ReadLine() ?? "";
        //     }

        //     return date;
        // }

        // private DateTime GetStartTimeValue () {
        //     Console.WriteLine("Enter the time you started project in the following format hh:mm");
        //     string startTime = Console.ReadLine() ?? "";
        //     DateTime parsedTime;

        //     while(!DateTime.TryParseExact(startTime, "HH:mm", null, System.Globalization.DateTimeStyles.None, out parsedTime)) {
        //         Console.WriteLine("Please enter a start time in the format hh:mm");
        //         startTime = Console.ReadLine() ?? "";
        //     }

        //     return parsedTime;
        // }
        
        // private DateTime GetEndTimeValue () {
        //     Console.WriteLine("Enter the time you ended project in the following format hh:mm");
        //     string endTime = Console.ReadLine() ?? "";
        //     DateTime parsedTime;

        //     while(!DateTime.TryParseExact(endTime, "HH:mm", null, System.Globalization.DateTimeStyles.None, out parsedTime)) {
        //         Console.WriteLine("Please enter an end time in the format hh:mm");
        //         endTime = Console.ReadLine() ?? "";
        //     }

        //     return parsedTime;
        // }

        // private string CalculateDuration(DateTime start, DateTime end) {
        //     TimeSpan difference = end - start;
        //     Console.WriteLine(difference.ToString(@"hh\:mm"));
        //     return difference.ToString(@"hh\:mm");
        // }

    }
}