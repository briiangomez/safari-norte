using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public class TipoMovimientoComponent : GenericComponent<TipoMovimiento>
    {
        public TipoMovimientoComponent(IRepository<TipoMovimiento> repository) : base(repository)
        {

        }

        public TipoMovimientoComponent()
        {
            this.repository = new TipoMovimientoDAC();
        }
    }
}
