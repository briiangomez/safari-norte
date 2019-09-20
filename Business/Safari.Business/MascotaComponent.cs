using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public partial class MascotaComponent
    {
        public Mascota Agregar(Mascota Mascota)
        {
            Mascota result = default(Mascota);
            var dac = new MascotaDAC();
            result = dac.Create(Mascota);
            return result;
        }

        public void Eliminar(int id) => new MascotaDAC().Delete(id);

        public void Actualizar(Mascota Mascota) => new MascotaDAC().Update(Mascota);

        public Mascota Listar(int id)
        {
            return new MascotaDAC().ReadBy(id);
        }

        public List<Mascota> ListarTodos()
        {
            List<Mascota> result = default(List<Mascota>);

            var MascotaDAC = new MascotaDAC();
            result = MascotaDAC.Read();
            return result;

        }

    }
}