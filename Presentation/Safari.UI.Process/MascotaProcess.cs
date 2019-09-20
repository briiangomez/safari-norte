using Safari.Entities;
using Safari.Services;
using Safari.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;

namespace Safari.UI.Process
{
    public partial class MascotaProcess : ProcessComponent
    {
        public List<Mascota> ListarTodos()
        {
            List<Mascota> result = default(List<Mascota>);
            IServices<Mascota> proxy = new MascotaService();

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

        public Mascota Agregar(Mascota Mascota)
        {
            Mascota result = default(Mascota);
            IServices<Mascota> proxy = new MascotaService();

            try
            {
                result = proxy.Agregar(Mascota);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }

            return result;
        }

        public void Actualizar(Mascota Mascota)
        {
            IServices<Mascota> proxy = new MascotaService();

            try
            {
                proxy.Actualizar(Mascota);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
        }

        public void Eliminar(int id)
        {
            IServices<Mascota> proxy = new MascotaService();

            try
            {
                proxy.Eliminar(id);
            }
            catch (FaultException fex)
            {
                throw new ApplicationException(fex.Message);
            }
        }

        public Mascota Listar(int id)
        {
            Mascota result = default(Mascota);
            IServices<Mascota> proxy = new MascotaService();

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
