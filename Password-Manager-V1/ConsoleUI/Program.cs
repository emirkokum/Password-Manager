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
        { CategoryId=1,Notes="gizli12323",Password="emir1123345",Title="XCOm",Username="emirkokum"
        };
        recordManager.Add(record1);
    }
}