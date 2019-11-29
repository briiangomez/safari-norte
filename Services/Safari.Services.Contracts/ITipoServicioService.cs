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
    public interface ITipoServicioService
    {
        [OperationContract]
        TipoServicio Agregar(TipoServicio TipoServicio);

        [OperationContract]
        List<TipoServicio> ListarTodos();

        [OperationContract]
        void Eliminar(int id);

        [OperationContract]
        TipoServicio Ver(int id);

        [OperationContract]
        void Editar(int id, TipoServicio TipoServicio);
    }
    
}
