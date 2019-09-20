using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public partial class TipoServicioComponent
    {
        public TipoServicio Agregar(TipoServicio tipo)
        {
            TipoServicio result = default(TipoServicio);
            var dac = new TipoServicioDAC();
            result = dac.Create(tipo);
            return result;
        }

        public void Eliminar(int id) => new TipoServicioDAC().Delete(id);

        public void Actualizar(TipoServicio tipo) => new TipoServicioDAC().Update(tipo);

        public TipoServicio Listar(int id)
        {
            return new TipoServicioDAC().ReadBy(id);
        }

        public List<TipoServicio> ListarTodos()
        {
            List<TipoServicio> result = default(List<TipoServicio>);

            var tipoDAC = new TipoServicioDAC();
            result = tipoDAC.Read();
            return result;

        }

    }
}
