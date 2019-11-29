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
    public interface ITipoMovimientoService
    {
        [OperationContract]
        TipoMovimiento Agregar(TipoMovimiento TipoMovimiento);

        [OperationContract]
        List<TipoMovimiento> ListarTodos();

        [OperationContract]
        void Eliminar(int id);

        [OperationContract]
        TipoMovimiento Ver(int id);

        [OperationContract]
        void Editar(int id, TipoMovimiento TipoMovimiento);
    }
    
}
