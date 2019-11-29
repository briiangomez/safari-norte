using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts.Response
{
    public class TipoMovimientoResponse : IResponse<TipoMovimiento>
    {
        public TipoMovimiento Result { get; set; }
    }
}
