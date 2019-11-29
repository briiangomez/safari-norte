using Safari.Business;
using Safari.Entities;
using Safari.Services.Contracts;
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
    [RoutePrefix("api/Especie")]
    public class EspecieServiceHttp : GenericServiceHttp<Especie, EspecieRequest, EspecieResponse, ListarTodosEspecieResponse>
    {
        public EspecieServiceHttp(IComponent<Especie> component) : base(component)
        {

        }

        public EspecieServiceHttp()
        {
            this.component = new EspecieComponent();
        }
    }
}
