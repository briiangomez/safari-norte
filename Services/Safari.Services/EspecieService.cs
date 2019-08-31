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
    public class EspecieService : IServices<Especie>
    {
        public void Actualizar(Especie entity)
        {
            var bc = new EspecieComponent();
            bc.Actualizar(entity);
        }

        public Especie Agregar(Especie especie)
        {
            var bc = new EspecieComponent();
            return bc.Agregar(especie);
        }

        public void Eliminar(int id)
        {
            var bc = new EspecieComponent();
            bc.Eliminar(id);
        }

        public Especie Listar(int id)
        {
            var bc = new EspecieComponent();
            return bc.Listar(id);
        }

        public List<Especie> ListarTodos()
        {
            var bc = new EspecieComponent();
            return bc.ListarTodos();
        }
    }
}
