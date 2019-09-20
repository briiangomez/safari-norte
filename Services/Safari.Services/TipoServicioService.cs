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
    public class TipoServicioService : IServices<TipoServicio>
    {
        public void Actualizar(TipoServicio entity)
        {
            var bc = new TipoServicioComponent();
            bc.Actualizar(entity);
        }

        public TipoServicio Agregar(TipoServicio TipoServicio)
        {
            var bc = new TipoServicioComponent();
            return bc.Agregar(TipoServicio);
        }

        public void Eliminar(int id)
        {
            var bc = new TipoServicioComponent();
            bc.Eliminar(id);
        }

        public TipoServicio Listar(int id)
        {
            var bc = new TipoServicioComponent();
            return bc.Listar(id);
        }

        public List<TipoServicio> ListarTodos()
        {
            var bc = new TipoServicioComponent();
            return bc.ListarTodos();
        }
    }
}
