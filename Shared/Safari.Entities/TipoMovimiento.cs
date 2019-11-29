using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;


namespace Safari.Entities
{

    public partial class TipoMovimiento : IEntity
    {
        [DisplayName("Id")]
        public int Id { get; set; }


        [DisplayName("Nombre")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Debe tener entre 2 y 50 caracteres")]
        [Required]
        public string Nombre { get; set; }

        [DisplayName("Multiplicador")]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "Debe tener entre 1 y 3 caracteres")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Debe ser un número")]
        [Required]
        public int Multiplicador { get; set; }

        public override string ToString()
        {
            return this.GetType().Name + ": " +
                string.Join(",", this.GetType().GetProperties()
                .Where(p => !p.PropertyType.IsGenericType && !p.PropertyType.IsArray)
                .Select(p => string.Format("{0}={1}", p.Name, p.GetValue(this, null))));
        }
    }
}
