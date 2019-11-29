using Safari.Entities;
using Safari.Framework.Common;
using Safari.Services;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;

namespace Safari.UI.Process
{    
    public partial class PrecioProcess : ProcessComponent
    {
        private IPrecioService _precioService;
        public PrecioProcess()
        {
            _precioService = ServiceFactory.Get<IPrecioService>();
        }
        public List<Precio> ListarTodos()
        {
            List<Precio> result = default(List<Precio>);
            IPrecioService proxy = _precioService;
            
            try
            {
                result = proxy.ListarTodos();
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }            
            return result;
        }
        
        public Precio Agregar(Precio precio)
        {
            Precio result = default(Precio);
            IPrecioService proxy = _precioService;

            try
            {
                result = proxy.Agregar(precio);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
            
            return result;
        }

        public Precio Ver(Precio precio)
        {
            Precio result = default(Precio);
            IPrecioService proxy = _precioService;

            try
            {
                result = proxy.Ver(precio);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public Precio Eliminar(Precio precio)
        {
            Precio result = default(Precio);
            IPrecioService proxy = _precioService;

            try
            {
                proxy.Eliminar(precio);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public void Editar(Precio precio)
        {
            IPrecioService proxy = _precioService;

            try
            {
                proxy.Editar(precio);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
        }
    }
}
