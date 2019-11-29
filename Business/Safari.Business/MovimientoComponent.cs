using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Safari.Entities;
using Safari.Data;


namespace Safari.Business
{
    public class MovimientoComponent : GenericComponent<Movimiento>
    {
        public MovimientoComponent(IRepository<Movimiento> repository) : base(repository)
        {

        }

        public MovimientoComponent()
        {
            this.repository = new MovimientoDAC();
        }
    }
}