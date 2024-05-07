using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RecordManager : IRecordService
    {
        IRecordDal _recordDal;

        public RecordManager(IRecordDal recordDal)
        {
            _recordDal = recordDal;
        }

        public IResult Add(Record record)
        {
            _recordDal.Add(record);
            return new SuccessResult(Messages.EntityAdded);
        }

        public IResult Delete(int id)
        {
            _recordDal.Delete(_recordDal.Get(r => r.Id == id));
            return new SuccessResult(Messages.EntityDeleted);
        }

        public IDataResult<List<Record>> GetAll()
        {
            return new SuccessDataResult<List<Record>>(_recordDal.GetAll(), Messages.EntitiesListed);
        }

        public IDataResult<List<Record>> GetByCategoryId(int id)
        {
            return new SuccessDataResult<List<Record>>(_recordDal.GetAll(r => r.CategoryId == id), Messages.EntitiesListed);
        }

        public IDataResult<Record> GetById(int id)
        {
            return new SuccessDataResult<Record>(_recordDal.Get(r => r.Id == id));
        }

        public IDataResult<List<RecordDto>> GetRecordDetails()
        {
            return new SuccessDataResult<List<RecordDto>>(_recordDal.GetRecordDetails());
        }

        public IDataResult<List<RecordDto>> GetRecordDetailsById(int id)
        {
            return new SuccessDataResult<List<RecordDto>>(_recordDal.GetRecordDetailsById(id));
        }

        public IDataResult<List<RecordDto>> GetRecordDetailsByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<RecordDto>>(_recordDal.GetRecordDetailsByCategoryId(categoryId));
        }

        public IResult Update(Record record)
        {
            if (record.Id > 0)
            {
                _recordDal.Update(record);
                return new SuccessResult(Messages.EntityUpdated);
            }
            return new ErrorResult(Messages.EntityUpdateError);
        }
    }
}
