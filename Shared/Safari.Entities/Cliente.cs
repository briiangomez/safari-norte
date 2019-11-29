using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;


namespace Safari.Entities
{

    public partial class Cliente : IEntity
    {
        [DisplayName("Id")]
        public int Id { get; set; }
       
        [DisplayName("Apellido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Debe tener entre 2 y 50 caracteres")]
        [Required]
        public string Apellido { get; set; }

        [DisplayName("Nombre")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Debe tener entre 2 y 50 caracteres")]
        [Required]
        public string Nombre { get; set; }

        [DisplayName("Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail inválido")]
        [Required]
        public string Email { get; set; }

        [DisplayName("Teléfono")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Debe tener entre 2 y 50 caracteres")]
        [Required]
        public string Telefono { get; set; }

        [DisplayName("URL")]
        public string URL { get; set; }

        [DisplayName("Fecha de Nacimiento")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        [DisplayName("Domicilio")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Debe tener entre 2 y 100 caracteres")]
        [Required]
        public string Domicilio { get; set; }

        public override string ToString()
        {
            return this.GetType().Name + ": " +
                string.Join(",", this.GetType().GetProperties()
                .Where(p => !p.PropertyType.IsGenericType && !p.PropertyType.IsArray)
                .Select(p => string.Format("{0}={1}", p.Name, p.GetValue(this, null))));
        }
    }
}
