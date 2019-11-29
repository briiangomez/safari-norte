using Safari.Entities;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process
{
    public class CitaProcess : GenericProcess<Cita>
    {
        public CitaProcess(IGenericService<Cita> proxy)
        {
            base.proxy = proxy;
        }
    }
}
