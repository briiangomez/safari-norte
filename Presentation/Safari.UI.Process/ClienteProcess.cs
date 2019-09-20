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
    public partial class ClienteProcess : ProcessComponent
    {
        public List<Cliente> ListarTodos()
        {
            List<Cliente> result = default(List<Cliente>);
            IServices<Cliente> proxy = new ClienteService();

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

        public Cliente Agregar(Cliente cliente)
        {
            Cliente result = default(Cliente);
            IServices<Cliente> proxy = new ClienteService();

            try
            {
                result = proxy.Agregar(cliente);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public void Eliminar(int id)
        {
            IServices<Cliente> proxy = new ClienteService();

            try
            {
                proxy.Eliminar(id);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
        }

        public void Actualizar(Cliente cliente)
        {
            IServices<Cliente> proxy = new ClienteService();

            try
            {
                proxy.Actualizar(cliente);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
        }

        public Cliente Listar(int id)
        {
            IServices<Cliente> proxy = new ClienteService();

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
