using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    public class Sala : IEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string TipoSala { get; set; }
    }

}
