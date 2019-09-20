using Safari.Business;
using Safari.Entities;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class SalaService : IServices<Sala>
    {
        public void Actualizar(Sala entity)
        {
            var bc = new SalaComponent();
            bc.Actualizar(entity);
        }

        public Sala Agregar(Sala Sala)
        {
            var bc = new SalaComponent();
            return bc.Agregar(Sala);
        }

        public void Eliminar(int id)
        {
            var bc = new SalaComponent();
            bc.Eliminar(id);
        }

        public Sala Listar(int id)
        {
            var bc = new SalaComponent();
            return bc.Listar(id);
        }

        public List<Sala> ListarTodos()
        {
            var bc = new SalaComponent();
            return bc.ListarTodos();
        }
    }
}
