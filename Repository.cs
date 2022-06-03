using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Repository<T> : IRepository<T> where T : Model,IMap
    {
        private readonly DbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public Repository()
        {
            this.context = new DbContex();
            this.entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Create(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(obj);
            context.SaveChanges();
        }

        public T Read(int Id)
        {
            return entities.SingleOrDefault(o => o.Id == Id);
        }

        public void Update(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("entity");
            }
            var result = entities.Update(obj);
            context.SaveChanges();
        }

        public void Delete(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("entity");
            }

            var result = entities.SingleOrDefault(o => o.Id == obj.Id);
            if (result != null)
            {
                entities.Remove(obj);
                context.SaveChanges();
            }
            context.SaveChanges();
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }

}
