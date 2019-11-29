using Safari.Business;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class TipoMovimientoService : GenericService<TipoMovimiento>
    {
        public TipoMovimientoService(IComponent<TipoMovimiento> component) : base (component)
        {

        }
    }
}
