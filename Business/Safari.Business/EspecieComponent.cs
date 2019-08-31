using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Safari.Entities;
using Safari.Data;


namespace Safari.Business
{
   
    public partial class EspecieComponent
    {
        /// <summary>
        /// Desarrollo del metodo
        /// </summary>
        /// <param name="especie">Objeto Entity Especie</param>
        /// <returns></returns>
        public Especie Agregar(Especie especie)
        {
            Especie result = default(Especie);
            var dac = new EspecieDAC();
            result = dac.Create(especie);
            return result;
        }

        /// <summary>
        /// Desarrollo del metodo
        /// </summary>
        /// <returns></returns>
        public List<Especie> ListarTodos()
        {
            List<Especie> result = default(List<Especie>);

            var especieDAC = new EspecieDAC();
            result = especieDAC.Read();
            return result;

        }

        /// <summary>
        /// Desarrollo del metodo
        /// </summary>
        /// <returns></returns>
        public void Actualizar(Especie especie)
        {
            var dac = new EspecieDAC();
            dac.Update(especie);
        }

        /// <summary>
        /// Desarrollo del metodo
        /// </summary>
        /// <returns></returns>
        public void Eliminar(int id)
        {
            var dac = new EspecieDAC();
            dac.Delete(id);
        }

        public Especie Listar(int id)
        {
            Especie result = default(Especie);
            var dac = new EspecieDAC();
            result = dac.ReadBy(id);
            return result;
        }
    }
}
