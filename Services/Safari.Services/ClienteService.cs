using Safari.Business;
using Safari.Entities;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ClienteService : IServices<Cliente>
    {
        public void Actualizar(Cliente entity)
        {
            var bc = new ClienteComponent();
            bc.Actualizar(entity);
        }

        public Cliente Agregar(Cliente Cliente)
        {
            var bc = new ClienteComponent();
            return bc.Agregar(Cliente);
        }

        public void Eliminar(int id)
        {
            var bc = new ClienteComponent();
            bc.Eliminar(id);
        }

        public Cliente Listar(int id)
        {
            var bc = new ClienteComponent();
            return bc.Listar(id);
        }

        public List<Cliente> ListarTodos()
        {
            var bc = new ClienteComponent();
            return bc.ListarTodos();
        }
    }
}
