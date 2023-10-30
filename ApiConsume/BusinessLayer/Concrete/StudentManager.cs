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
    public class StudentManager : IStudentService
    {
        private readonly IStudentDal _studentDal;

        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        public void TDelete(Student entity)
        {
            _studentDal.Delete(entity);
        }

        public List<Student> TGetAll()
        {
            return _studentDal.GetAll();
        }

        public Student TGetById(int id)
        {
            return _studentDal.GetById(id);
        }

        public void TInsert(Student entity)
        {
            _studentDal.Insert(entity);
        }

        public void TUpdate(Student entity)
        {
            _studentDal.Update(entity);
        }
    }
}
