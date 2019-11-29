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
    [RoutePrefix("api/tipoMovimiento")]
    public class TipoMovimientoServiceHttp : GenericServiceHttp<TipoMovimiento, TipoMovimientoRequest, TipoMovimientoResponse, ListarTipoMovimientoResponse>
    {
        public TipoMovimientoServiceHttp(IComponent<TipoMovimiento> component) : base (component)
        {
            this.component = component;
        }

        public TipoMovimientoServiceHttp()
        {
            this.component = new TipoMovimientoComponent();
        }
    }
}
