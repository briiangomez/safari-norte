using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Data
{
    public interface IRepositoryObject<TEntityObject> where TEntityObject : IEntityObject
    {

        TEntityObject Create(TEntityObject entity);
        List<TEntityObject> Read();
        TEntityObject ReadBy(TEntityObject entity);
        void Update(TEntityObject entity);
        void Delete(TEntityObject entity);

        
    }
}
