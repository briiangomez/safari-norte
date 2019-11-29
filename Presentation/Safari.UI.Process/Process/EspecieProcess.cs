using Safari.Entities;
using Safari.Services;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process
{
    public class EspecieProcess : GenericProcess<Especie>
    {
        public EspecieProcess(IGenericService<Especie> proxy)
        {
            base.proxy = proxy;
        }
    }
}

