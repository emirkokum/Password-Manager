using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAcceess.Concrete.Sqlite;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

public class Program
{
    public static void Main(string[] args)
    {
        ICategoryService categoryManager = new CategoryManager(new EfCategoryDal());
        IRecordService recordManager = new RecordManager(new EfRecordDal());

        //foreach (var item in recordManager.GetAll().Data)
        //{
        //    Console.WriteLine(item.Username);
        //    Console.WriteLine(item.Password);
        //    Console.WriteLine(item.Id);
        //}

        DatabaseCreator databaseCreator = new DatabaseCreator();
        databaseCreator.CreateDatabase();
        
    }
}