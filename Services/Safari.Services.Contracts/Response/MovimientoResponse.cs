using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts.Response
{
    public class MovimientoResponse : IResponse<Movimiento>
    {
        public Movimiento Result { get; set; }

    }
}
