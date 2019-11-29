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
    [RoutePrefix("api/medico")]
    public class MedicoServiceHttp : GenericServiceHttp<Medico, MedicoRequest, MedicoResponse, ListarMedicoResponse> 
    {
        public MedicoServiceHttp(IComponent<Medico> component) : base(component)
        {

        }

        public MedicoServiceHttp()
        {
            this.component = new MedicoComponent();
        }
    }
}
