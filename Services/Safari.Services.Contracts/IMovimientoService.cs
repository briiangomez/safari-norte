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
    public interface IMovimientoService
    {
        [OperationContract]
        Movimiento Agregar(Movimiento movimiento);

        [OperationContract]
        List<Movimiento> ListarTodos();

        [OperationContract]
        void Eliminar(int id);

        [OperationContract]
        Movimiento Ver(int id);

        [OperationContract]
        void Editar(int id, Movimiento movimiento);
    }
    
}
