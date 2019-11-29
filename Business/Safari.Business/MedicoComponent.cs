using Safari.Data;
using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public class MedicoComponent : GenericComponent<Medico>
    {
        public MedicoComponent(IRepository<Medico> repository) : base(repository)
        {

        }

        public MedicoComponent()
        {
            this.repository = new MedicoDAC();
        }
    }
}
