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
                    string createCategoriesTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Categories (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT
                    );
                ";
                    using (SQLiteCommand createCategoriesTableCommand = new SQLiteCommand(createCategoriesTableQuery, connection))
                    {
                        createCategoriesTableCommand.ExecuteNonQuery();
                    }

                    string createRecordsTableQuery = @"
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
                    using (SQLiteCommand createRecordsTableCommand = new SQLiteCommand(createRecordsTableQuery, connection))
                    {
                        createRecordsTableCommand.ExecuteNonQuery();
                    }

                    string createMainUsersTableQuery = @"
                    CREATE TABLE IF NOT EXISTS MainUsers (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        FirstName TEXT,
                        LastName TEXT,
                        Email TEXT,
                        PasswordSalt BLOB,
                        PasswordHash BLOB,
                        Status INTEGER
                        );";
                    using (SQLiteCommand createMainUsersTableCommand = new SQLiteCommand(createMainUsersTableQuery, connection))
                    {
                        createMainUsersTableCommand.ExecuteNonQuery();
                    }

                    string createOperationClaimsTableQuery = @"
                    CREATE TABLE IF NOT EXISTS OperationClaims (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT
                        );";

                    using (SQLiteCommand createOperationClaimsTableCommand = new SQLiteCommand(createOperationClaimsTableQuery, connection))
                    {
                        createOperationClaimsTableCommand.ExecuteNonQuery();
                    }

                    string createUserOperationClaimsTableQuery = @"
                    CREATE TABLE IF NOT EXISTS UserOperationClaims (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserId INTEGER,
                        OperationClaimId INTEGER,
                        FOREIGN KEY(UserId) REFERENCES Users(Id),
                        FOREIGN KEY(OperationClaimId) REFERENCES OperationClaims(Id)
                        );";

                    using (SQLiteCommand createUserOperationClaimsTableCommand = new SQLiteCommand(createUserOperationClaimsTableQuery, connection))
                    {
                        createUserOperationClaimsTableCommand.ExecuteNonQuery();
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
