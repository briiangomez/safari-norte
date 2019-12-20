using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;


namespace Safari.Entities
{

    public partial class Cita : IEntity
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Fecha")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }


        [DisplayName("MedicoId")]
        [Required]
        public int MedicoId { get; set; }

        public Medico Medico { get; set; }


        [DisplayName("PacienteId")]
        [Required]
        public int PacienteId { get; set; }

        public Paciente Paciente { get; set; }


        [DisplayName("SalaId")]
        [Required]
        public int SalaId { get; set; }

        public Sala Sala { get; set; }


        [DisplayName("Tipo de servicio")]
        [Required]
        public int TipoServicioId { get; set; }

        public TipoServicio TipoServicio { get; set; }

        [DisplayName("Estado")]
        [Required]
        public string Estado { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ChangedDate { get; set; }

        public int ChangedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DeletedDate { get; set; }

        public int DeletedBy { get; set; }

        public bool Deleted { get; set; }

        public override string ToString()
        {
            return this.GetType().Name + ": " +
                string.Join(",", this.GetType().GetProperties()
                .Where(p => !p.PropertyType.IsGenericType && !p.PropertyType.IsArray)
                .Select(p => string.Format("{0}={1}", p.Name, p.GetValue(this, null))));
        }
    }
}
