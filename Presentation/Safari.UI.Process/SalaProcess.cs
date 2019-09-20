using Safari.Entities;
using Safari.Services;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process
{
    public partial class SalaProcess : ProcessComponent
    {
        public List<Sala> ListarTodos()
        {
            List<Sala> result = default(List<Sala>);
            IServices<Sala> proxy = new SalaService();

            try
            {
                result = proxy.ListarTodos();
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
            return result;
        }

        public Sala Agregar(Sala Sala)
        {
            Sala result = default(Sala);
            IServices<Sala> proxy = new SalaService();

            try
            {
                result = proxy.Agregar(Sala);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public void Eliminar(int id)
        {
            IServices<Sala> proxy = new SalaService();

            try
            {
                proxy.Eliminar(id);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
        }

        public void Actualizar(Sala Sala)
        {
            IServices<Sala> proxy = new SalaService();

            try
            {
                proxy.Actualizar(Sala);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
        }

        public Sala Listar(int id)
        {
            IServices<Sala> proxy = new SalaService();

            try
            {
                return proxy.Listar(id);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
        }

    }
}
