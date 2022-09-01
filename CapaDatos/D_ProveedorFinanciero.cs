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
    public class D_ProveedorFinanciero
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public void InsertarProveedor(E_ProveedorFinanciero Proveedor)
        {
            SqlCommand cmd = new SqlCommand("SP_ADD_PROVEEDORFINANCIERO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@RUC", Proveedor.NRO_RUC);
            cmd.Parameters.AddWithValue("@RAZONSOCIAL", Proveedor.RAZON_SOCIAL);
            cmd.Parameters.AddWithValue("@CODCTA", Proveedor.COD_CTA);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public DataTable BuscaProveedor(string Busqueda, string TipoBusqueda)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_BUSCAPROVEEDOR", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@BUSQUEDA", Busqueda);
            cmd.Parameters.AddWithValue("@TIPOBUSQUEDA", TipoBusqueda);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);

            conexion.Close();

            return tabla;
        }
    }
}
