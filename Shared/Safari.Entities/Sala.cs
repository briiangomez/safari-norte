using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;


namespace Safari.Entities
{

    public partial class Sala : IEntity
    {
        [DisplayName("Id")]
        public int Id { get; set; }


        [DisplayName("Nombre")]
        [Required]
        public string Nombre { get; set; }

        [DisplayName("Tipo")]
        [Required]
        public string TipoSala { get; set; }

        public override string ToString()
        {
            return this.GetType().Name + ": " +
                string.Join(",", this.GetType().GetProperties()
                .Where(p => !p.PropertyType.IsGenericType && !p.PropertyType.IsArray)
                .Select(p => string.Format("{0}={1}", p.Name, p.GetValue(this, null))));
        }
    }
}
