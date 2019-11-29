using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{
    public interface IGenericService<T> where T : IEntity
    {
        List<T> List();
        T Agregar(T entity);
        void Actualizar(T entity);
        void Eliminar(int id);
        T Get(int id);
    }
}
