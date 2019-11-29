using Safari.Entities;
using Safari.Services.Contracts.Request;
using Safari.Services.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process.APIProcess
{
    public class SalaAPIProcess : GenericAPIProcess<Sala, SalaRequest, SalaResponse, ListarSalaResponse>
    {
        public SalaAPIProcess()
        {
            Prefix = "api/sala";
        }
    }
}
