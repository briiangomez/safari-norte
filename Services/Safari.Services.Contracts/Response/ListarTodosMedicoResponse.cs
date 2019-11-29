using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts.Response
{
    [DataContract]
    public class ListarTodosMedicoResponse
    {
        [DataMember]
        public List<Medico> Result { get; set; }
    }
}
