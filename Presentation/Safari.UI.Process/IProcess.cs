using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process
{
    public interface IProcess<T> where T : IEntity
    {
        List<T> ListarTodos();

        T Get(int id);

        T Agregar(T entity);

        void Actualizar(T entity);

        void Eliminar(int id);
    }
}
