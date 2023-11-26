using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DailyManager : IDailyService
    {
        private readonly IDailyDal _dailyDal;

        public DailyManager(IDailyDal dailyDal)
        {
            _dailyDal = dailyDal;
        }

        public void TDelete(Daily entity)
        {
            _dailyDal.Delete(entity);
        }

        public List<Daily> TGetAll()
        {
            return _dailyDal.GetAll();
        }

        public Daily TGetById(int id)
        {
            return _dailyDal.GetById(id);
        }

        public void TInsert(Daily entity)
        {
            _dailyDal.Insert(entity);
        }

        public void TUpdate(Daily entity)
        {
            _dailyDal.Update(entity);
        }
    }
}
