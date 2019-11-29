using Safari.Business;
using Safari.Entities;
using Safari.Services.Contracts.Request;
using Safari.Services.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Safari.Services.Http
{
    [RoutePrefix("api/Paciente")]
    public class PacienteServiceHttp : GenericServiceHttp<Paciente, PacienteRequest, PacienteResponse, ListarPacienteResponse>
    {
        public PacienteServiceHttp(IComponent<Paciente> component) : base(component)
        {

        }

        public PacienteServiceHttp()
        {
            this.component = new PacienteComponent();
        }

        [HttpGet]
        [Route("ListarByCliente/{id}")]
        public ListarPacienteResponse ListarTodosByCliente(int id)
        {
            try
            {
                var result = new ListarPacienteResponse();
                result.Result = new PacienteComponent().ListarTodosDeCliente(id);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
