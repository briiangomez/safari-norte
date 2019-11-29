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
    [RoutePrefix("api/tipoServicio")]
    public class TipoServicioServiceHttp : GenericServiceHttp<TipoServicio, TipoServicioRequest, TipoServicioResponse, ListarTipoServicioResponse>
    {
        public TipoServicioServiceHttp(IComponent<TipoServicio> component) : base (component)
        {

        }

        public TipoServicioServiceHttp()
        {
            component = new TipoServicioComponent();
        }
    }
}
