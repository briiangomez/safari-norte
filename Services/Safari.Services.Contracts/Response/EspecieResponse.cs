using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{
    public class EspecieResponse : IResponse<Especie>
    {
        [DataMember]
        public Especie Result { get; set; }
    }
}
