using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts.Response
{
    public class ListarPacienteResponse : IListResponse<Paciente>
    {
        public List<Paciente> Result { get; set; }

    }
}
