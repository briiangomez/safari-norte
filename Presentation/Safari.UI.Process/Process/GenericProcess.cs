using Safari.Entities;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process
{
    public abstract class GenericProcess<T> : ProcessComponent, IProcess<T> where T : IEntity
    {
        protected IGenericService<T> proxy;

        public List<T> ListarTodos()
        {
            List<T> result = default(List<T>);

            try
            {
                result = proxy.List();
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
            return result;
        }

        public T Get(int id)
        {
            T result = default(T);

            try
            {
                result = proxy.Get(id);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
            return result;
        }

        public T Agregar(T especie)
        {
            T result = default(T);

            try
            {
                result = proxy.Agregar(especie);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public void Actualizar(T especie)
        {
            try
            {
                proxy.Actualizar(especie);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                proxy.Eliminar(id);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
        }
    }
}
