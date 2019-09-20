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
    public partial class TipoMovimientoProcess : ProcessComponent
    {
        public List<TipoMovimiento> ListarTodos()
        {
            List<TipoMovimiento> result = default(List<TipoMovimiento>);
            IServices<TipoMovimiento> proxy = new TipoMovimientoService();

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

        public TipoMovimiento Agregar(TipoMovimiento TipoMovimiento)
        {
            TipoMovimiento result = default(TipoMovimiento);
            IServices<TipoMovimiento> proxy = new TipoMovimientoService();

            try
            {
                result = proxy.Agregar(TipoMovimiento);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public void Eliminar(int id)
        {
            IServices<TipoMovimiento> proxy = new TipoMovimientoService();

            try
            {
                proxy.Eliminar(id);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
        }

        public void Actualizar(TipoMovimiento TipoMovimiento)
        {
            IServices<TipoMovimiento> proxy = new TipoMovimientoService();

            try
            {
                proxy.Actualizar(TipoMovimiento);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
        }

        public TipoMovimiento Listar(int id)
        {
            IServices<TipoMovimiento> proxy = new TipoMovimientoService();

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
