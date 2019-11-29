using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{
      
    [ServiceContract]
    public interface IClienteService
    {
        [OperationContract]
        Cliente Agregar(Cliente cliente);

        [OperationContract]
        List<Cliente> ListarTodos();

        [OperationContract]
        void Eliminar(int id);

        [OperationContract]
        Cliente Ver(int id);

        [OperationContract]
        void Editar(int id, Cliente cliente);
    }
    
}
