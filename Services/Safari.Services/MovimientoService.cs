using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using Safari.Business;
using Safari.Entities;
using Safari.Services.Contracts;

namespace Safari.Services
{    
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class MovimientoService : GenericService<Movimiento>
    {
        public MovimientoService(IComponent<Movimiento> component) : base(component)
        {

        }
    }
}
