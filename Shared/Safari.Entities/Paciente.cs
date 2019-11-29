using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;


namespace Safari.Entities
{

    public partial class Paciente : IEntity
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Nombre")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Debe tener entre 2 y 50 caracteres")]
        [Required]
        public string Nombre { get; set; }

        [DisplayName("Cliente")]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        [DisplayName("Fecha de nacimiento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime FechaNacimiento { get; set; }

        [DisplayName("Especie")]
        [Required]
        public int EspecieId { get; set; }
        public Especie Especie { get; set; }

        [DisplayName("Observacion")]
        public string Observacion { get; set; }

        public override string ToString()
        {
            return this.GetType().Name + ": " +
                string.Join(",", this.GetType().GetProperties()
                .Where(p => !p.PropertyType.IsGenericType && !p.PropertyType.IsArray)
                .Select(p => string.Format("{0}={1}", p.Name, p.GetValue(this, null))));
        }
    }
}
