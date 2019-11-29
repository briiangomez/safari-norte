using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public class SalaComponent : GenericComponent<Sala>
    {
        public SalaComponent(IRepository<Sala> repository) : base(repository)
        {

        }

        public SalaComponent()
        {
            this.repository = new SalaDAC();
        }
    }
}
