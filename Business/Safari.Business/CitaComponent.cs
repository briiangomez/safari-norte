using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Safari.Entities;
using Safari.Data;


namespace Safari.Business
{
   
    public partial class CitaComponent : GenericComponent<Cita>
    {
        public CitaComponent(IRepository<Cita> repository) : base(repository)
        {

        }

        public CitaComponent()
        {
            this.repository = new CitaDAC();
        }
    }
}
