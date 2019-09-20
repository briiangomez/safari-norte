using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public partial class TipoMovimientoComponent
    {
        public TipoMovimiento Agregar(TipoMovimiento tipo)
        {
            TipoMovimiento result = default(TipoMovimiento);
            var dac = new TipoMovimientoDAC();
            result = dac.Create(tipo);
            return result;
        }

        public void Eliminar(int id) => new TipoMovimientoDAC().Delete(id);

        public void Actualizar(TipoMovimiento tipo) => new TipoMovimientoDAC().Update(tipo);

        public TipoMovimiento Listar(int id)
        {
            return new TipoMovimientoDAC().ReadBy(id);
        }

        public List<TipoMovimiento> ListarTodos()
        {
            List<TipoMovimiento> result = default(List<TipoMovimiento>);

            var tipoDAC = new TipoMovimientoDAC();
            result = tipoDAC.Read();
            return result;

        }

    }
}
