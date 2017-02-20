using System.Collections.Generic;
using Entities;

namespace BusinessLogic.Links
{
    public interface IResourcesService
    {
        Resource AddLink(string userId, string URL);
        Resource GetFirst();
        IEnumerable<Resource> GetAll(string userName);
    }
}