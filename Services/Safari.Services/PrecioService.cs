using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using Safari.Business;
using Safari.Entities;
using Safari.Services.Contracts;

namespace Safari.Services
{    
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class PrecioService : IPrecioService
    {
        public Precio Agregar(Precio precio)
        {
            var bc = new PrecioComponent();
            return bc.Agregar(precio);
        }

        public List<Precio> ListarTodos()
        {
            var bc = new PrecioComponent();
            return bc.ListarTodos();
        }
        
        public void Eliminar(Precio precio)
        {
            var bc = new PrecioComponent();
            bc.Eliminar(precio);
        }

        public Precio Ver(Precio precio)
        {
            var bc = new PrecioComponent();
            return bc.Ver(precio);
        }

        public void Editar(Precio precio)
        {
            var bc = new PrecioComponent();
            bc.Editar(precio);
        }
    }
}
