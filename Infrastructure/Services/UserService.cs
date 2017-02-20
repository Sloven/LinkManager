using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Abstractions;
using Entities;

namespace BusinessLogic
{
    public class UserService
    {
        //public static UserService Instance { get; } = new UserService();
        private IDBLookup<ApplicationUser> lookup { get; }
        public UserService(IDBLookup<ApplicationUser> Lookup)
        {
            if(lookup == null)
                throw new NotImplementedException("IDBLookup<ApplicationUser> is not implemented");
            Lookup = lookup;
        }


        public ApplicationUser GetSingleUser(Expression<Func<ApplicationUser, bool>> predicate)
        {
            return lookup.Single(predicate);
        }
    }
}
