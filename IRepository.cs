using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IRepository<T> where T : Model
    {
        IEnumerable<T> GetAll();
        void Create(T o);
        T Read(int Id);
        void Update(T o);
        void Delete(T o);
        void Save();
    }
}
