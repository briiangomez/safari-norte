using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts.Response
{
    public class ListarMovimientoResponse : IListResponse<Movimiento>
    {
        public List<Movimiento> Result { get; set; }
    }
}
