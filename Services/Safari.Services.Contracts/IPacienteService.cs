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
    public interface IPacienteService
    {
        [OperationContract]
        Paciente Agregar(Paciente cliente);

        [OperationContract]
        List<Paciente> ListarTodos();

        [OperationContract]
        List<Paciente> ListarTodosDeCliente(int clienteId);

        [OperationContract]
        void Eliminar(int id);

        [OperationContract]
        Paciente Ver(int id);

        [OperationContract]
        void Editar(Paciente cliente);
    }
    
}
