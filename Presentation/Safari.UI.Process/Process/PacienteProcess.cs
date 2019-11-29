using Safari.Entities;
using Safari.Framework.Common;
using Safari.Services;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process
{
    public partial class PacienteProcess : ProcessComponent
    {
        public List<Paciente> ListarTodos()
        {
            List<Paciente> result = default(List<Paciente>);
            IPacienteService proxy = ServiceFactory.Get<IPacienteService>();

            try
            {
                result = proxy.ListarTodos();
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
            return result;
        }

        public List<Paciente> ListarTodosDeCliente(int ClienteId)
        {
            List<Paciente> result = default(List<Paciente>);
            IPacienteService proxy = ServiceFactory.Get<IPacienteService>();

            try
            {
                result = proxy.ListarTodosDeCliente(ClienteId);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
            return result;
        }

        public Paciente Agregar(Paciente paciente)
        {
            Paciente result = default(Paciente);
            IPacienteService proxy = ServiceFactory.Get<IPacienteService>();

            try
            {
                result = proxy.Agregar(paciente);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public void Eliminar(int id)
        {
            IPacienteService proxy = ServiceFactory.Get<IPacienteService>();

            try
            {
                proxy.Eliminar(id);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
        }

        public void Actualizar(Paciente paciente)
        {
            IPacienteService proxy = ServiceFactory.Get<IPacienteService>();

            try
            {
                proxy.Editar(paciente);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
        }

        public Paciente LeerPorId(int id)
        {
            IPacienteService proxy = ServiceFactory.Get<IPacienteService>();

            try
            {
                return proxy.Ver(id);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
        }
    }
}
