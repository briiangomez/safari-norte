using Safari.Data;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Business
{
    public partial class SalaComponent
    {
        public Sala Agregar(Sala sala)
        {
            Sala result = default(Sala);
            var dac = new SalaDAC();
            result = dac.Create(sala);
            return result;
        }

        public void Eliminar(int id) => new SalaDAC().Delete(id);

        public void Actualizar(Sala sala) => new SalaDAC().Update(sala);

        public Sala Listar(int id)
        {
            return new SalaDAC().ReadBy(id);
        }

        public List<Sala> ListarTodos()
        {
            List<Sala> result = default(List<Sala>);

            var salaDAC = new SalaDAC();
            result = salaDAC.Read();
            return result;

        }

    }
}
