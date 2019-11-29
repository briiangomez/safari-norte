using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public interface IComponent<T> where T : IEntity
    {
        List<T> ListarTodos();

        T Agregar(T entity);

        void Editar(T entity);

        void Eliminar(int id);

        T Ver(int id);
    }
}
