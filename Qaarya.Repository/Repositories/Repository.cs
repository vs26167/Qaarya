using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Qaarya.Data.DataModel;
using Qaarya.Repository.Interfaces;
using System.Linq.Expressions;

namespace Qaarya.Repository.Repository
{
    public class Repository<T>:IRepository<T> where T : class
    {
        
        private QaaryaEntities dbContext = new QaaryaEntities();

        protected QaaryaEntities _dbContext
        {
            get
            {
                return dbContext;
            }
            set
            {
                dbContext =value;
            }
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = dbContext.Set<T>();
            return query;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
           return dbContext.Set<T>().Where(predicate);
        }

        public void Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
        }

        public void Edit(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified; 
        }

        public void Delete(T entity)
        {
            if (dbContext.Entry(entity).State == EntityState.Detached)
            {
                dbContext.Set<T>().Attach(entity);
            }
            dbContext.Set<T>().Remove(entity);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {

            if (!this.disposed)
                if (disposing)
                    dbContext.Dispose();

            this.disposed = true;
        }

        public void Dispose()
        {

            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
