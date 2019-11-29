using System.ComponentModel.DataAnnotations;

namespace Safari.UI.Web.Models
{
    public class PacienteList
    {
        [Display(Name="Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Cliente")]
        public string Cliente { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        public string FechaNacimiento { get; set; }

        [Display(Name = "Especie")]
        public string Especie { get; set; }

        [Display(Name = "Observación")]
        public string Observacion { get; set; }
    }


}