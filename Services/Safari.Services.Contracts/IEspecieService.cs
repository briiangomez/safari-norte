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
    public interface IEspecieService
    {
        [OperationContract]
        Especie Agregar(Especie especie);

        [OperationContract]
        List<Especie> ListarTodos();

        [OperationContract]
        void Eliminar(int id);

        [OperationContract]
        Especie Ver(int id);

        [OperationContract]
        void Editar(int id, Especie especie);
    }

}
