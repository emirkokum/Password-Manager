using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRecordDal : EfEntityRepositoryBase<Record, PassManContext>, IRecordDal
    {
        public List<RecordDto> GetRecordDetails()
        {
            using (PassManContext context = new PassManContext())
            {
                var result = from r in context.Records
                             join c in context.Categories on r.CategoryId equals c.Id
                             select new RecordDto { Id = r.Id,UserName =r.Username ,CategoryName= c.Name ,Notes=r.Notes,Password=r.Password ,Title=r.Title,Url=r.Url}; 
                return result.ToList();
            }  
        }

        public List<RecordDto> GetRecordDetailsById(int id)
        {
            using (PassManContext context = new PassManContext())
            {
                var result = from r in context.Records
                             join c in context.Categories on r.CategoryId equals c.Id
                             where r.Id == id
                             select new RecordDto { Id = r.Id, UserName = r.Username, CategoryName = c.Name, Notes = r.Notes, Password = r.Password, Title = r.Title, Url = r.Url };
                return result.ToList();
            }
        }

        public List<RecordDto> GetRecordDetailsByCategoryId(int categoryId)
        {
            using (PassManContext context = new PassManContext())
            {
                var result = from r in context.Records
                             join c in context.Categories on r.CategoryId equals c.Id
                             where r.CategoryId == categoryId
                             select new RecordDto { Id = r.Id, UserName = r.Username, CategoryName = c.Name, Notes = r.Notes, Password = r.Password, Title = r.Title, Url = r.Url };
                return result.ToList();
            }
        }
    }
}
