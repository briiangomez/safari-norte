using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    public class Mascota : IEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Observacion { get; set; }
        public int ClienteId { get; set; }
        public int EspecieId { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Especie Especie { get; set; }

    }
}
