using System;
using DataAccess.Abstractions;

namespace Services.Resources
{
    public abstract class AbstractBasicService<T>
    {
        protected IBasicCRUD<T> CRUD { get; }

        protected AbstractBasicService(IBasicCRUD<T> basicCrud)
        {
            if (basicCrud == null)
                throw new NotImplementedException("CRUD Is not implemented");

            CRUD = basicCrud;
        }
    }
}
