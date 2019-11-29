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
    [RoutePrefix("api/Cita")]
    public class CitaServiceHttp : GenericServiceHttp<Cita, CitaRequest, CitaResponse, ListarCitaResponse>
    {
        public CitaServiceHttp(IComponent<Cita> component) : base(component)
        {

        }

        public CitaServiceHttp()
        {
            this.component = new CitaComponent();
        }
    }
}
