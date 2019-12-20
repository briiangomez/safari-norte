using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Safari.UI.Web.Models
{
    public class MovimientoVM
    {
        public int idCliente { get; set; }
        public Cliente Cliente { get; set; }
        public decimal saldo { get; set; }
        public DateTime FechaUltimoMov { get; set; }
    }
}