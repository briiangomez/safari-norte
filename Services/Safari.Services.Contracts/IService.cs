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
    public interface IService<TEntidad> where TEntidad : IEntity
    {

        [OperationContract]
        TEntidad Agregar(TEntidad entidad);

        [OperationContract]
        List<TEntidad> ListarTodos();

        [OperationContract]
        void Actualizar(TEntidad entidad);

        [OperationContract]
        void Borrar(int id);

        [OperationContract]
        TEntidad ObtenerPorId(int id);

    }
}
