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
    public interface ISalaService
    {
        [OperationContract]
        Sala Agregar(Sala Sala);

        [OperationContract]
        List<Sala> ListarTodos();

        [OperationContract]
        void Eliminar(int id);

        [OperationContract]
        Sala Ver(int id);

        [OperationContract]
        void Editar(int id, Sala Sala);
    }
    
}
