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
    public partial class TipoServicioProcess : ProcessComponent
    {
        private ITipoServicioService _tipoServicioService;
        public TipoServicioProcess()
        {
            _tipoServicioService = ServiceFactory.Get<ITipoServicioService>();
        }
        public List<TipoServicio> ListarTodos()
        {
            List<TipoServicio> result = default(List<TipoServicio>);
            ITipoServicioService proxy = _tipoServicioService;
            
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
        
        public TipoServicio Agregar(TipoServicio TipoServicio)
        {
            TipoServicio result = default(TipoServicio);
            ITipoServicioService proxy = _tipoServicioService;

            try
            {
                result = proxy.Agregar(TipoServicio);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
            
            return result;
        }

        public TipoServicio Ver(int id)
        {
            TipoServicio result = default(TipoServicio);
            ITipoServicioService proxy = _tipoServicioService;

            try
            {
                result = proxy.Ver(id);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public TipoServicio Eliminar(int id)
        {
            TipoServicio result = default(TipoServicio);
            ITipoServicioService proxy = _tipoServicioService;

            try
            {
                proxy.Eliminar(id);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public TipoServicio Editar(int id, TipoServicio TipoServicio)
        {
            TipoServicio result = default(TipoServicio);
            ITipoServicioService proxy = _tipoServicioService;

            try
            {
                proxy.Editar(id, TipoServicio);
                result = proxy.Ver(id);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }
    }
}
