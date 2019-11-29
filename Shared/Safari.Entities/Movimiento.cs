using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;


namespace Safari.Entities
{

    public partial class Movimiento : IEntity
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Fecha")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [DisplayName("ClienteId")]
        [Required]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        [DisplayName("TipoMovimientoId")]
        [Required]
        public int TipoMovimientoId { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }

        [DisplayName("Valor")]
        [Required]
        public Decimal Valor { get; set; }

        public override string ToString()
        {
            return this.GetType().Name + ": " +
                string.Join(",", this.GetType().GetProperties()
                .Where(p => !p.PropertyType.IsGenericType && !p.PropertyType.IsArray)
                .Select(p => string.Format("{0}={1}", p.Name, p.GetValue(this, null))));
        }
    }
}
