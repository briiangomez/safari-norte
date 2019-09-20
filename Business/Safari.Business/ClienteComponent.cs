using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public partial class ClienteComponent
    {
        public Cliente Agregar(Cliente cliente)
        {
            Cliente result = default(Cliente);
            var dac = new ClienteDAC();
            result = dac.Create(cliente);
            return result;
        }

        public void Eliminar(int id) => new ClienteDAC().Delete(id);

        public void Actualizar(Cliente cliente) => new ClienteDAC().Update(cliente);

        public Cliente Listar(int id)
        {
            return new ClienteDAC().ReadBy(id);
        }

        public List<Cliente> ListarTodos()
        {
            List<Cliente> result = default(List<Cliente>);

            var clienteDAC = new ClienteDAC();
            result = clienteDAC.Read();
            return result;

        }
    }
}
