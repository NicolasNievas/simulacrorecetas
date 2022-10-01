using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSimulacro.Dominio
{
    public class Ingredientes
    {
        public int IngredienteID { get; set; }
        public string Nombre { get; set; }
        public string UnidadMedida { get; set; }
        public Ingredientes(int ingredienteId, string nombre, string unidadMedida)
        {
            IngredienteID = ingredienteId;
            Nombre = nombre;
            UnidadMedida = unidadMedida;
        }
        public Ingredientes()
        {
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
