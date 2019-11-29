using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Safari.Entities;
using Safari.Data;


namespace Safari.Business
{
   
    public partial class PrecioComponent
    {        
        public Precio Agregar(Precio Precio)
        {
            Precio result = default(Precio);
            var PrecioDAC = new PrecioDAC();

            result = PrecioDAC.Create(Precio);
            return result;
        }

        public List<Precio> ListarTodos()
        {
            List<Precio> result = default(List<Precio>);

            var PrecioDAC = new PrecioDAC();
            result = PrecioDAC.Read();
            return result;

        }

        public Precio Ver(Precio precio)
        {
            Precio result = default(Precio);

            var PrecioDAC = new PrecioDAC();
            result = PrecioDAC.ReadBy(precio);
            return result;

        }

        public void Editar(Precio precio)
        {
            var PrecioDAC = new PrecioDAC();
            PrecioDAC.Update(precio);

        }

        public void Eliminar(Precio precio)
        {
            var PrecioDAC = new PrecioDAC();
            PrecioDAC.Delete(precio);
        }

    }
}
