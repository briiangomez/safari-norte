using Safari.Entities;
using Safari.Services.Contracts.Request;
using Safari.Services.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.UI.Process.Api
{
    public class MedicoApiProcess : ProcessComponent
    {

        public List<Medico> Read()
        {
            try
            {
                var r = HttpGet<ListarTodosMedicoResponse>(
                    "api/Medico/ListarTodos", new Dictionary<string, object>(), MediaType.Json);
                return r.Result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public Medico ReadBy(int id)
        {
            try
            {
                var parameters = new Dictionary<string, object>
                {
                    { "id", id }
                };
                var r = HttpGet<MedicoResponse>("api/Medico/LeerPorId", parameters, MediaType.Json);
                return r.Result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public Medico Create(Medico medico)
        {
            try
            {
                var r = HttpPost<MedicoResponse, MedicoRequest>("api/Medico/Agregar",
                    new MedicoRequest() { Medico = medico },
                    MediaType.Json);
                return r.Result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public void Update(Medico medico)
        {
            try
            {
                var r = HttpPost<MedicoResponse, MedicoRequest>("api/Medico/Actualizar",
                    new MedicoRequest() { Medico = medico }, MediaType.Json);
                return;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var parameters = new Dictionary<string, object>
                {
                    { "id", id }
                };
                var r = HttpPost<EspecieResponse, int>("api/Medico/Eliminar", id, MediaType.Json);
                return;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}
