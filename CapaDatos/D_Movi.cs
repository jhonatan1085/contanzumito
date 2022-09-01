using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidades;
using System.Data;

namespace CapaDatos
{
    public class D_Movi
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public DataTable BuscarMovi(E_Movi movi)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_LISTAMOVI", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@tipo_asiento", movi.TIPO_ASIENTO);
            cmd.Parameters.AddWithValue("@nro_asiento", movi.NRO_ASIENTO);
            cmd.Parameters.AddWithValue("@periodo", movi.PERIODO);
            cmd.Parameters.AddWithValue("@mes", movi.MES);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);

            conexion.Close();

            return tabla;
        }
    }
}
