using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Resources;
using DataAccess.Abstractions;

namespace Services.Resources
{
   public class ResourceService: AbstractBasicService<Resource>, IResourcesService
    {
        public ResourceService(IBasicCRUD<Resource> basicCRUD):base(basicCRUD){}

        public Resource AddLink(string userId, string URL)
        {
            var link = new Resource()
            {
                URL = URL,
                UserId = userId
            };

            CRUD.Add(link);

            return link;
        }

        public Resource GetFirst()
        {
            return CRUD.First(null);
        }

        public IEnumerable<Resource> GetAll(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return null;

            var query = CRUD.AsQueryable().Where(l => l.ApplicationUser.UserName == userName);

            List<Resource> res = query.ToList();
            return res;
        } 
    }
}
