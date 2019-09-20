using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safari.Entities;
using Safari.Services.Contracts;
using Safari.Business;
using System.ServiceModel;

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

        public Especie Agregar(Especie Especie)
        {
            var bc = new EspecieComponent();
            return bc.Agregar(Especie);
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
