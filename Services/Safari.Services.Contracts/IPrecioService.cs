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
    public interface IPrecioService
    {
        [OperationContract]
        Precio Agregar(Precio precio);

        [OperationContract]
        List<Precio> ListarTodos();
        
        [OperationContract]
        void Eliminar(Precio precio);

        [OperationContract]
        Precio Ver(Precio precio);

        [OperationContract]
        void Editar(Precio precio);
    }
    
}
