using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSimulacro.Dominio
{
    public class Receta
    {
        public int RecetaNro { get; set; }
        public string Nombre { get; set; }
        public int TipoReceta { get; set; }
        public string Cheff { get; set; }
        public List<DetalleReceta> DetalleRecetas { get; set; }
        public Receta()
        {
            DetalleRecetas = new List<DetalleReceta>();
        }
        public void AgregarDetalle(DetalleReceta detalle)
        {
            DetalleRecetas.Add(detalle);
        }
        public void QuitarDetalle(int indice)
        {
            DetalleRecetas.RemoveAt(indice);
        }
    }
}
