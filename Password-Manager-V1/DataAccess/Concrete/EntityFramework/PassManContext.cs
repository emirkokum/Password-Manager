using DataAcceess.Concrete.Sqlite;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class PassManContext : DbContext
    {
        public static string selectedPath => DatabaseCreator.selectedPath;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\emir_\\MyDatabase\\mydatabase.db");
        }

        public DbSet<Record> Records { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
