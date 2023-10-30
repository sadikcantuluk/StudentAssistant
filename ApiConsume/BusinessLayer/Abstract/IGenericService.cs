using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        List<T> TGetAll();
        T TGetById(int id);
        void TUpdate(T entity);
        void TDelete(T entity);
        void TInsert(T entity);
    }
}
