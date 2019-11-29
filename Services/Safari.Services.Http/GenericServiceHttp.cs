using Safari.Business;
using Safari.Entities;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Safari.Services.Http
{
    public abstract class GenericServiceHttp<TEntity, TRequest, TResponse, TListResponse> : ApiController 
        where TEntity : IEntity
        where TRequest : IRequest<TEntity>
        where TResponse : IResponse<TEntity>, new()
        where TListResponse : IListResponse<TEntity>, new()
    {
        protected IComponent<TEntity> component;

        protected GenericServiceHttp(IComponent<TEntity> component)
        {
            this.component = component;
        }

        protected GenericServiceHttp()
        {

        }

        [HttpGet]
        [Route("ListarTodos")]
        public TListResponse ListarTodos()
        {
            try
            {
                var result = new TListResponse();
                result.Result = component.ListarTodos();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("Buscar/{id}")]
        public TResponse Buscar(int id)
        {
            try
            {
                var result = new TResponse();
                result.Result = component.Ver(id);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("Agregar")]
        public TResponse Agregar(TRequest request)
        {
            try
            {
                var result = new TResponse();
                result.Result = component.Agregar(request.Request);

                return result;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);
            }
        }

        [HttpPost]
        [Route("Editar")]
        public void Editar(TRequest request)
        {
            try
            {
                component.Editar(request.Request);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);
            }
        }

        [HttpPost]
        [Route("Eliminar")]
        public void Eliminar(TRequest request)
        {
            try
            {
                component.Eliminar(request.Request.Id);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };
                throw new HttpResponseException(httpError);
            }
        }
    }
}
