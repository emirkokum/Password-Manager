using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRecordService
    {
        IResult Add(Record record);
        IResult Delete(Record record);
        IResult Update(Record record);
        IDataResult<List<Record>> GetAll();
        IDataResult<List<Record>> GetByCategoryId(int id);
        IDataResult<Record> GetById(int id);
    }
}
