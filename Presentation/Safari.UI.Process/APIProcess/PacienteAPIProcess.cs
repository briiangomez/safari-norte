using Safari.Entities;
using Safari.Services.Contracts.Request;
using Safari.Services.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace Safari.UI.Process.APIProcess
{
    public class PacienteAPIProcess : GenericAPIProcess<Paciente, PacienteRequest, PacienteResponse, ListarPacienteResponse>
    {
        public PacienteAPIProcess()
        {
            Prefix = "api/Paciente";
        }

        public List<Paciente> GetByCliente(int id)
        {
            var result = default(List<Paciente>);
            try
            {
                var response = HttpGet<ListarPacienteResponse>(Prefix + $"/Buscar/{id}", new Dictionary<string, object>(), MediaType.Json);
                result = response.Result;
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
            return result;
        }
    }
}
