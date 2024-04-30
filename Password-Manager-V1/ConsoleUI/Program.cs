using Business.Abstract;
using Business.Concrete;
using DataAcceess.Concrete.Sqlite;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

public class Program
{
    public static void Main(string[] args)
    {
        ICategoryService categoryManager = new CategoryManager(new EfCategoryDal());
        IRecordService recordManager = new RecordManager(new EfRecordDal());

        Record record1 = new Record 
        {CategoryId=2,Notes="Gorkemgottenyermi123",Password="yeryemezbilmem",Title="ozztech",Username="gorkempala"
        };
        recordManager.Add(record1);
    }
}