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
    public interface IMedicoService
    {
        [OperationContract]
        Medico Agregar(Medico cliente);

        [OperationContract]
        List<Medico> ListarTodos();

        [OperationContract]
        void Eliminar(int id);

        [OperationContract]
        Medico Ver(int id);

        [OperationContract]
        void Editar(int id, Medico cliente);
    }
    
}
