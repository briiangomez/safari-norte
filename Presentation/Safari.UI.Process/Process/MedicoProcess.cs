using Safari.Entities;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process
{
    public class MedicoProcess : GenericProcess<Medico>
    {
        public MedicoProcess(IGenericService<Medico> proxy)
        {
            base.proxy = proxy;
        }
    }
}
