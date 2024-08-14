# Code Tracker app

### Summary

This is a code tracker app that will hold and 
display data on the name, duration, and date of 
projects you worked on. It is the next step to
the previous project habit tracker and will have
the same functionality and requirements.

### Requirements

- Needs to have a menu display to interact with.
- Needs to retrieve data from db to display on
the functions view, delete, and update.
- Needs to use SQLite.
- Needs to exit program when 0 is entered in menu.
- Needs to store and retrieve from a real db.
- Needs to create a db if one doesn't exist.
- Needs to create a table in db if doesn't exist.
- Should have sufficient exception handling. 
- Should use Spectre.Console library to display 
data.
- Should have separate file for each class.
- Should show the user the proper format for date
and time entries and prevent anything else.
- Need to use a config file for database path and
connection strings.
- Need a CodingSession class in a file to contain
properties of your session i.e. Id, project, date, and Duration.
- Duration should be calculated based on StartTime
and EndTime entered and should be done in a 
CalculateDuration method.
- User should be able to enter Start and End times
manually.
- Need to Use Dapper ORM for data access instead 
of ADO.NET.
- When reading from db you can't use anonymous 
object, need to read table into a list of coding
sessions.

### Tools/Concepts learned

1. Using Spectre.Console to give a console app structure to display data.
2. Working with DateTime and TimeSpan to set time variables and calculate
   differences in times with 2 variables.
3. Using more exception handling to catch issues in code.
4. Learning how to setup and use a config file for c#.

