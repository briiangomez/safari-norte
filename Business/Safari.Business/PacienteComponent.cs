using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Safari.Entities;
using Safari.Data;


namespace Safari.Business
{
    public class PacienteComponent : GenericComponent<Paciente>
    {
        public PacienteComponent(IRepository<Paciente> repository) : base(repository)
        {

        }

        public PacienteComponent()
        {
            this.repository = new PacienteDAC();
        }

        public List<Paciente> ListarTodosDeCliente(int clienteId)
        {
            return new PacienteDAC().ReadByClient(clienteId);
        }
    }
}