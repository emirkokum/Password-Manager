using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRecordDal : IEntityRepository<Record>
    {
        public List<RecordDto> GetRecordDetails();
        public List<RecordDto> GetRecordDetailsById(int id);
        public List<RecordDto> GetRecordDetailsByCategoryId(int categoryId);
    }
}
