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
    [RoutePrefix("api/sala")]
    public class SalaServiceHttp : GenericServiceHttp<Sala, SalaRequest, SalaResponse, ListarSalaResponse>
    {
        public SalaServiceHttp(IComponent<Sala> component) : base(component)
        {

        }

        public SalaServiceHttp()
        {
            this.component = new SalaComponent();
        }
    }
}
