using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts.Response
{
   public class TipoServicioResponse : IResponse<TipoServicio>
    {
        public TipoServicio Result { get; set; }

    }
}
