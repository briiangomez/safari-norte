using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Safari.Business;
using System.ServiceModel;

namespace Safari.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ClienteService : GenericService<Cliente>
    {
        public ClienteService(IComponent<Cliente> component) : base(component)
        {
        }
    }
}
