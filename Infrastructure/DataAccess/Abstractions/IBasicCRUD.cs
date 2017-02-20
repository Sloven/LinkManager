using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstractions
{
    public interface IBasicCRUD<T>: IDBLookup<T>
    {
        void Delete(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Edit(T entity);
    }
}
