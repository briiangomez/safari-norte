using Safari.Entities;
using Safari.Services;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process
{
    public partial class TipoServicioProcess : ProcessComponent
    {
        public List<TipoServicio> ListarTodos()
        {
            List<TipoServicio> result = default(List<TipoServicio>);
            IServices<TipoServicio> proxy = new TipoServicioService();

            try
            {
                result = proxy.ListarTodos();
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
            return result;
        }

        public TipoServicio Agregar(TipoServicio TipoServicio)
        {
            TipoServicio result = default(TipoServicio);
            IServices<TipoServicio> proxy = new TipoServicioService();

            try
            {
                result = proxy.Agregar(TipoServicio);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public void Eliminar(int id)
        {
            IServices<TipoServicio> proxy = new TipoServicioService();

            try
            {
                proxy.Eliminar(id);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
        }

        public void Actualizar(TipoServicio TipoServicio)
        {
            IServices<TipoServicio> proxy = new TipoServicioService();

            try
            {
                proxy.Actualizar(TipoServicio);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
        }

        public TipoServicio Listar(int id)
        {
            IServices<TipoServicio> proxy = new TipoServicioService();

            try
            {
                return proxy.Listar(id);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
        }

    }
}
