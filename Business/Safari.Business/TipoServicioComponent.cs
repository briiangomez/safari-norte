using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public class TipoServicioComponent : GenericComponent<TipoServicio>
    {
        public TipoServicioComponent(IRepository<TipoServicio> repository) : base(repository)
        {

        }

        public TipoServicioComponent()
        {
            repository = new TipoServicioDAC();
        }
    }
}
