using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using RecetasSimulacro.Dominio;

namespace RecetasSimulacro.Datos.Interfaces
{
    public interface IRecetaDao
    {
        int ObtenerProximoID();
        List<Ingredientes> ToGetIngredientes();
        bool Save(Receta nuevo);
    }
}
