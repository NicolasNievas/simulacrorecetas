using RecetasSimulacro.Datos.Interfaces;
using RecetasSimulacro.Dominio;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSimulacro.Datos.Implementaciones
{
    public class ResetaDao : IRecetaDao
    {
        public int ObtenerProximoID()
        {
            return HelperDAO.ObtenerInstancia().ObtenerProximoID("SP_PROXIMO_ID", "@next");
        }

        public bool Save(Receta nuevo)
        {
            return HelperDAO.ObtenerInstancia().GrabarReceta(nuevo, "SP_INSERTAR_RECETA", "SP_INSERTAR_DETALLE");
        }

        public List<Ingredientes> ToGetIngredientes()
        {
            List<Ingredientes> list = new List<Ingredientes>();
            DataTable dt = HelperDAO.ObtenerInstancia().CargarCombo("SP_CONSULTAR_INGREDIENTES");
            foreach(DataRow dr in dt.Rows)
            {
                Ingredientes i = new Ingredientes();
                i.IngredienteID = (int)dr["id_ingrediente"];
                i.Nombre = dr["n_ingrediente"].ToString();
                i.UnidadMedida = dr["unidad_medida"].ToString();
                list.Add(i);
            }
            return list;
        }
    }
}
