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
    public class NotesManager : INotesService
    {
        private readonly INotesDal _notesDal;

        public NotesManager(INotesDal notesDal)
        {
            _notesDal = notesDal;
        }

        public void TDelete(Notes entity)
        {
            _notesDal.Delete(entity);
        }

        public List<Notes> TGetAll()
        {
            return _notesDal.GetAll();
        }

        public Notes TGetById(int id)
        {
            return _notesDal.GetById(id);
        }

        public void TInsert(Notes entity)
        {
            _notesDal.Insert(entity);
        }

        public void TUpdate(Notes entity)
        {
            _notesDal.Update(entity);
        }
    }
}
