using Safari.Entities;
using Safari.Business;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services
{
    public abstract class GenericService<T> : IGenericService<T> where T : IEntity
    {
        IComponent<T> component;

        protected GenericService(IComponent<T> component)
        {
            this.component = component;
        }

        public void Actualizar(T entity)
        {
            component.Editar(entity);
        }

        public T Agregar(T entity)
        {
            return component.Agregar(entity);
        }

        public void Eliminar(int id)
        {
            component.Eliminar(id);
        }

        public T Get(int id)
        {
            return component.Ver(id);
        }

        public List<T> List()
        {
            return component.ListarTodos();
        }
    }
}
