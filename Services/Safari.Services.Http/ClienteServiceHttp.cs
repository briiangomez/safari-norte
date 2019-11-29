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
    [RoutePrefix("api/cliente")]
    public class ClienteServiceHttp : GenericServiceHttp<Cliente, ClienteRequest, ClienteResponse, ListarClienteResponse>
    {
        public ClienteServiceHttp(IComponent<Cliente> component) : base(component)
        {

        }

        public ClienteServiceHttp()
        {
            this.component = new ClienteComponent();
        }
    }
}
