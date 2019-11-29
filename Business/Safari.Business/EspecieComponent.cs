using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Safari.Entities;
using Safari.Data;
using Safari.Business;

namespace Safari.Business
{
   
    public partial class EspecieComponent : GenericComponent<Especie>
    {
        public EspecieComponent(IRepository<Especie> repository) : base(repository)
        {

        }

        public EspecieComponent()
        {
            this.repository = new EspecieDAC();
        }
    }
}
