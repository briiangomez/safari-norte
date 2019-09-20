using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using Safari.Business;
using Safari.Entities;
using Safari.Services;
using Safari.Services.Contracts;

namespace Safari.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class TipoMovimientoService : IServices<TipoMovimiento>
    {
        public void Actualizar(TipoMovimiento entity)
        {
            var bc = new TipoMovimientoComponent();
            bc.Actualizar(entity);
        }

        public TipoMovimiento Agregar(TipoMovimiento TipoMovimiento)
        {
            var bc = new TipoMovimientoComponent();
            return bc.Agregar(TipoMovimiento);
        }

        public void Eliminar(int id)
        {
            var bc = new TipoMovimientoComponent();
            bc.Eliminar(id);
        }

        public TipoMovimiento Listar(int id)
        {
            var bc = new TipoMovimientoComponent();
            return bc.Listar(id);
        }

        public List<TipoMovimiento> ListarTodos()
        {
            var bc = new TipoMovimientoComponent();
            return bc.ListarTodos();
        }
    }
}
