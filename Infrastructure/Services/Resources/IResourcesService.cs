using System.Collections.Generic;
using Entities;

namespace Services.Resources
{
    public interface IResourcesService
    {
        Resource AddLink(string userId, string URL);
        Resource GetFirst();
        IEnumerable<Resource> GetAll(string userName);
    }
}