using Safari.Entities;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process.APIProcess
{
    public abstract class GenericAPIProcess<TEntity, TRequest, TResponse, TListResponse> : ProcessComponent, IApiProcess<TEntity> 
        where TEntity : IEntity, new()
        where TRequest : IRequest<TEntity>, new()
        where TResponse : IResponse<TEntity>
        where TListResponse : IListResponse<TEntity>
    {
        protected string Prefix { get; set; }

        public void Editar(TEntity entity)
        {
            try
            {
                var request = new TRequest() { Request = entity };

                HttpPost<TRequest>(Prefix + "/Editar", request, MediaType.Json);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
        }

        public TEntity Agregar(TEntity entity)
        {
            TEntity result = default(TEntity);

            try
            {
                var response = default(TResponse);
                var request = new TRequest() { Request = entity };

                response = HttpPost<TResponse, TRequest>(Prefix + "/Agregar", request, MediaType.Json);
                result = response.Result;
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public void Eliminar(TEntity entity)
        {
            try
            {
                var request = new TRequest() { Request = entity };

                HttpPost<TRequest>(Prefix + "/Eliminar", request, MediaType.Json);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
        }

        public TEntity Ver(int id)
        {
            var result = default(TEntity);
            try
            {
                var response = HttpGet<TResponse>(Prefix + $"/Buscar/{id}", new Dictionary<string, object>(), MediaType.Json);
                result = response.Result;
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
            return result;
        }

        public List<TEntity> ListarTodos()
        {
            var result = default(List<TEntity>);
            try
            {
                var response = HttpGet<TListResponse>(Prefix + "/ListarTodos", new Dictionary<string, object>(), MediaType.Json);
                result = response.Result;
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
            return result;
        }
    }
}
