using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{

    [ServiceContract]
    public interface IServices<TService> 
    {
        [OperationContract]
        TService Agregar(TService entity);

        [OperationContract]
        List<TService> ListarTodos();

        [OperationContract]
        TService Listar(int id);
        [OperationContract]
        void Actualizar(TService entity);
        [OperationContract]
        void Eliminar(int id);


    }
}
