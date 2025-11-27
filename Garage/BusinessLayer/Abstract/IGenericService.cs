using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void TAdd(T t);          // Ekleme
        void TDelete(T t);       // Silme
        void TUpdate(T t);       // Güncelleme
        List<T> GetList();       // Listeleme
        T GetById(int id);       // ID'ye göre getirme
    }
}
