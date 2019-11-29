using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using Safari.Business;
using Safari.Entities;
using Safari.Services.Contracts;

namespace Safari.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class PacienteService : GenericService<Paciente>
    {

        public PacienteService(IComponent<Paciente> component) : base(component)
        {

        }


        public List<Paciente> ListarTodosDeCliente(int clienteId)
        {
            var bc = new PacienteComponent();
            return bc.ListarTodosDeCliente(clienteId);
        }
    }
}
