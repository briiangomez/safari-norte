using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public abstract class GenericComponent<T> : IComponent<T> where T : IEntity
    {
        protected IRepository<T> repository;

        protected GenericComponent(IRepository<T> repository)
        {
            this.repository = repository;
        }

        protected GenericComponent()
        {

        }

        public void Editar(T entity)
        {
            repository.Update(entity);
        }

        public T Agregar(T entity)
        {
            T result = default(T);
            result = repository.Create(entity);
            return result;
        }

        public void Eliminar(int id)
        {
            repository.Delete(id);
        }

        public T Ver(int id)
        {
            T result = default(T);
            result = repository.ReadBy(id);
            return result;
        }

        public List<T> ListarTodos()
        {
            List<T> result = default(List<T>);

            result = repository.Read();
            return result;
        }
    }
}
