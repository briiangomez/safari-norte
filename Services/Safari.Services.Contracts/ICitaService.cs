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
    public interface ICitaService
    {
        [OperationContract]
        Cita Agregar(Cita cita);

        [OperationContract]
        List<Cita> ListarTodos();

        [OperationContract]
        void Eliminar(int id);

        [OperationContract]
        Cita Ver(int id);

        [OperationContract]
        void Editar(int id, Cita cita);
    }
    
}
