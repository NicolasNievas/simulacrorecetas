using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RecetasSimulacro.Dominio;

namespace RecetasSimulacro.Datos
{
    public class HelperDAO
    {
        private SqlConnection cnn;
        private SqlCommand cmd;
        private static HelperDAO instance;

        public HelperDAO()
        {
            cnn = new SqlConnection(@"Data Source=DESKTOP-HJBQUI6\SQLEXPRESS;Initial Catalog=recetas_db;Integrated Security=True");
            cmd = new SqlCommand();
        }
        public static HelperDAO ObtenerInstancia()
        {
            if(instance == null)
            {
                instance = new HelperDAO();
            }
            return instance;
        }
        public int ObtenerProximoID(string nombreSP,string nombreparametro)
        {
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = nombreSP;
            SqlParameter pOut = new SqlParameter();
            pOut.ParameterName = nombreparametro;
            pOut.DbType = DbType.Int32;
            pOut.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pOut);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cnn.Close();
            return (int)pOut.Value;
        }
        public DataTable CargarCombo(string nombreSP)
        {
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = nombreSP;
            cmd.Parameters.Clear();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            cnn.Close();
            return dt;
        }
        public bool GrabarReceta(Receta oReceta,string MaestroSP,string DetalleSP)
        {
            bool ok = false;
            SqlTransaction sqlTransaction = null;
            try
            {
                cnn.Open();
                sqlTransaction = cnn.BeginTransaction();
                SqlCommand comandoMaestro = new SqlCommand(MaestroSP, cnn, sqlTransaction);
                comandoMaestro.CommandType = CommandType.StoredProcedure;
                comandoMaestro.Parameters.AddWithValue("@nombre", oReceta.Nombre);
                comandoMaestro.Parameters.AddWithValue("@cheff", oReceta.Cheff);
                comandoMaestro.Parameters.AddWithValue("@tipo_receta", oReceta.TipoReceta);
                SqlParameter pOut = new SqlParameter();
                pOut.ParameterName = "@id";
                pOut.DbType = DbType.Int32;
                pOut.Direction = ParameterDirection.Output;
                comandoMaestro.Parameters.Add(pOut);
                comandoMaestro.ExecuteNonQuery();
                int numeroReceta = (int)pOut.Value;
                SqlCommand cmdDetalle = null;
                foreach(DetalleReceta dt in oReceta.DetalleRecetas)
                {
                    cmdDetalle = new SqlCommand(DetalleSP, cnn, sqlTransaction);
                    cmdDetalle.Parameters.AddWithValue("@id_receta", numeroReceta);
                    cmdDetalle.Parameters.AddWithValue("@id_ingrediente", dt.Ingrediente.IngredienteID);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", dt.Cantidad);
                }
                sqlTransaction.Commit();
                ok = true;
            }
            catch (Exception)
            {
                sqlTransaction.Rollback();
                ok = false;
            }
            finally
            {
                if(cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return ok;
        }
    }
}
