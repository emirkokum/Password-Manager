using System;
using System.Data.SQLite;
using System.IO;

namespace DataAcceess.Concrete.Sqlite
{
    public class DatabaseCreator
    {
        public static string selectedPath = "C:\\Users\\emir_\\MyDatabase";
        string databasePath;

        public DatabaseCreator()
        {
            databasePath = Path.Combine(selectedPath, "mydatabase.db");
        }

        public void CreateDatabase()
        {
            if (!File.Exists(databasePath))
            {
                SQLiteConnection.CreateFile(databasePath);
                Console.WriteLine("Database created successfully!");
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source={databasePath}"))
                {
                    connection.Open();
                    string createCategoryTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Categories (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT
                    );
                ";
                    using (SQLiteCommand createCategoryTableCommand = new SQLiteCommand(createCategoryTableQuery, connection))
                    {
                        createCategoryTableCommand.ExecuteNonQuery();
                    }

                    string createPasswordTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Records (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT,
                        Username TEXT,
                        Password TEXT,
                        Url TEXT,
                        Notes TEXT,
                        CategoryId INTEGER,
                        FOREIGN KEY(CategoryId) REFERENCES Categories(Id)
                    );";
                    using (SQLiteCommand createPasswordTableCommand = new SQLiteCommand(createPasswordTableQuery, connection))
                    {
                        createPasswordTableCommand.ExecuteNonQuery();
                    }

                    string createMainUserTableQuery = @"
                    CREATE TABLE IF NOT EXISTS MainUser (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        FirstName TEXT,
                        LastName TEXT,
                        Email TEXT,
                        PasswordSalt BLOB,
                        PasswordHash BLOB,
                        Status INTEGER
                        );";
                    using (SQLiteCommand createMainUserTableCommand = new SQLiteCommand(createMainUserTableQuery, connection))
                    {
                        createMainUserTableCommand.ExecuteNonQuery();
                    }


                    connection.Close();
                }
            }
            else
            {
                Console.WriteLine("Database already exists.");
            }
        }
    }
}
