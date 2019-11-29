using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safari.Entities;
using Safari.Business;
using System.ServiceModel;

namespace Safari.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class EspecieService : GenericService<Especie>
    {
        public EspecieService(IComponent<Especie> component) : base(component)
        {

        }
    }
}
