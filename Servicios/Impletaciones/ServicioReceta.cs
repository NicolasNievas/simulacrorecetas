using RecetasSimulacro.Datos.Interfaces;
using RecetasSimulacro.Servicios.Interfaces;
using RecetasSimulacro.Datos.Implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecetasSimulacro.Dominio;

namespace RecetasSimulacro.Servicios.Impletaciones
{
    public class ServicioReceta : IServicio 
    {
        private IRecetaDao dao;
        public ServicioReceta()
        {
            dao = new ResetaDao();
        }

        public bool ConfirmarReceta(Receta nuevo)
        {
            return dao.Save(nuevo);
        }

        public List<Ingredientes> ObtenerIngredientes()
        {
            return dao.ToGetIngredientes();
        }

        public int ProximaReseta()
        {
            return dao.ObtenerProximoID();
        }
    }
}
