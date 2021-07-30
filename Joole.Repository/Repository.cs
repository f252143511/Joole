using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Joole.Dal;

namespace Joole.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext context;
        string errorMessage = string.Empty;

        public Repository(DbContext context)
        {
            this.context = context;

        }
        
        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }
        //public void Insert(T entity)
        //{
        //    if (entity == null)
        //    {
        //        throw new ArgumentNullException("entity");
        //    }
        //    entities.Add(entity);
        //    context.SaveChanges();
        //}

        //public void Update(T entity)
        //{
        //    if (entity == null)
        //    {
        //        throw new ArgumentNullException("entity");
        //    }
        //    context.SaveChanges();
        //}

        //public void Delete(T entity)
        //{
        //    if (entity == null)
        //    {
        //        throw new ArgumentNullException("entity");
        //    }
        //    entities.Remove(entity);
        //    context.SaveChanges();
        //}
        //public void Remove(T entity)
        //{
        //    if (entity == null)
        //    {
        //        throw new ArgumentNullException("entity");
        //    }
        //    entities.Remove(entity);
        //}

        //public void SaveChanges()
        //{
        //    context.SaveChanges();
        //}

    }
}
