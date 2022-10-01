using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecetasSimulacro.Dominio;

namespace RecetasSimulacro.Servicios.Interfaces
{
    public interface IServicio
    {
        int ProximaReseta();
        List<Ingredientes> ObtenerIngredientes();
        bool ConfirmarReceta(Receta nuevo);
    }
}
