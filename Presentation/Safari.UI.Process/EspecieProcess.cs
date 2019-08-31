using Safari.Entities;
using Safari.Services;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;

namespace Safari.UI.Process
{    
    public partial class EspecieProcess : ProcessComponent
    {       
        public List<Especie> ListarTodos()
        {
            List<Especie> result = default(List<Especie>);
            IServices<Especie> proxy = new EspecieService();
            
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
        
        public Especie Agregar(Especie especie)
        {
            Especie result = default(Especie);
            IServices<Especie> proxy = new EspecieService();

            try
            {
                result = proxy.Agregar(especie);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
            
            return result;
        }

        public void Actualizar(Especie especie)
        {
            IServices<Especie> proxy = new EspecieService();

            try
            {
                proxy.Actualizar(especie);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
        }

        public void Eliminar(int id)
        {
            IServices<Especie> proxy = new EspecieService();

            try
            {
                proxy.Eliminar(id);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
        }

        public Especie Listar(int id)
        {
            Especie result = default(Especie);
            IServices<Especie> proxy = new EspecieService();

            try
            {
                result = proxy.Listar(id);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }
    }
}
