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
    public class MascotaService : IServices<Mascota>
    {
        public void Actualizar(Mascota entity)
        {
            var bc = new MascotaComponent();
            bc.Actualizar(entity);
        }

        public Mascota Agregar(Mascota Mascota)
        {
            var bc = new MascotaComponent();
            return bc.Agregar(Mascota);
        }

        public void Eliminar(int id)
        {
            var bc = new MascotaComponent();
            bc.Eliminar(id);
        }

        public Mascota Listar(int id)
        {
            var bc = new MascotaComponent();
            return bc.Listar(id);
        }

        public List<Mascota> ListarTodos()
        {
            var bc = new MascotaComponent();
            return bc.ListarTodos();
        }
    }
}
