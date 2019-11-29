using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process.APIProcess
{
    public interface IApiProcess<T> where T : IEntity
    {
        List<T> ListarTodos();

        T Ver(int id);

        T Agregar(T entity);

        void Editar(T entity);

        void Eliminar(T entity);
    }
}
