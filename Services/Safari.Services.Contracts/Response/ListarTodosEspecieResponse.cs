using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{
    [DataContract]
    public class ListarTodosEspecieResponse : IListResponse<Especie>
    {
        [DataMember]
        public List<Especie> Result { get; set; }
    }
}
