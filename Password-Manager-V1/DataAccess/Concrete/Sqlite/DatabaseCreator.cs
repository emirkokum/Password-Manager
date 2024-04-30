using System.Data.SQLite;

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
                        Id INTEGER PRIMARY KEY,
                        Name TEXT
                    );
                ";
                    using (SQLiteCommand createCategoryTableCommand = new SQLiteCommand(createCategoryTableQuery, connection))
                    {
                        createCategoryTableCommand.ExecuteNonQuery();
                    }

                    // Şifre tablosunu oluşturma
                    string createPasswordTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Passwords (
                        Id INTEGER PRIMARY KEY,
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
