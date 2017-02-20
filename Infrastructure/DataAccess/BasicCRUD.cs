using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Abstractions;
using DataAccess.Contexts;
using Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAccess
{
    public class BasicCRUD<T> : IBasicCRUD<T> where T : class
    {
        internal AbstractDBContext db;

        public BasicCRUD(AbstractDBContext dbContext)
        {
            if(dbContext == null)
                throw new NullReferenceException("AbstractDBContext is not defined");
            db = dbContext;
        }

        public virtual void Add(T entity)
        {
            db.Entry(entity).State = EntityState.Added;
            db.SaveChanges();
        }

        public virtual IQueryable<T> AsQueryable()
        {
            return db.Set<T>();
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            var entity = db.Set<T>().Single(predicate);
            db.Set<T>().Remove(entity);
            db.SaveChanges();
        }

        public virtual void Edit(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual T First(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public virtual T Single(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().Single(predicate);
        }
    }
}
