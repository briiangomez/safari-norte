using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Entities
{
    public class Cliente : IEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public virtual string Email { get; set; }
        public virtual string Telefono { get; set; }
        public virtual string Url { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Domicilio { get; set; }
        public virtual List<Mascota> Mascotas { get; set; }
    }
}
