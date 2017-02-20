using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Abstractions;
using NSubstitute.Core;

namespace Backend.UnitTest.Fakes
{
    public class FakeBasicCRUD<T> : IBasicCRUD<T>
    {
        private List<T> hc = new List<T>();

        public void Add(T entity)
        {
            hc.Add(entity);
        }

        public IQueryable<T> AsQueryable()
        {
            return hc.AsQueryable();
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            var itm = hc.AsQueryable().Single(predicate);
            hc.Remove(itm);
        }

        public void Edit(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return hc.AsQueryable().Where(predicate);
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return hc.AsQueryable().FirstOrDefault(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return hc;
        }

        public T Single(Expression<Func<T, bool>> predicate)
        {
            return hc.AsQueryable().Single(predicate);
        }
    }
}
