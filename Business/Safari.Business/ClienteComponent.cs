using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public class ClienteComponent : GenericComponent<Cliente>
    {
        public ClienteComponent(IRepository<Cliente> repository) : base(repository)
        {

        }

        public ClienteComponent()
        {
            this.repository = new ClienteDAC();
        }
    }
}
