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
    [RoutePrefix("api/Movimiento")]
    public class MovimientoServiceHttp : GenericServiceHttp<Movimiento, MovimientoRequest, MovimientoResponse, ListarMovimientoResponse>
    {
        public MovimientoServiceHttp(IComponent<Movimiento> component) : base(component)
        {
            this.component = component;
        }

        public MovimientoServiceHttp()
        {
            this.component = new MovimientoComponent();
        }
    }
}
