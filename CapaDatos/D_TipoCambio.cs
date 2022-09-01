using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidades;
using System.Data;
using CapaEntidades.lib;




namespace CapaDatos
{
    public class D_TipoCambio
    {
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

           
       

        public DataTable BuscaTipoCambio(E_Control control)
        {

            
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("SEL_TIPO_CAMBIO_01", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@PERIODO", control.PERIODO);
            cmd.Parameters.AddWithValue("@MES", control.MES);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);

            conexion.Close();

            return tabla;
        }

        public DataTable BuscaTipoCambioFecha(E_TipoCambio tipocambio)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_TIPOCAMBIO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@FECHA", tipocambio.FEC_CAMBIO);
           
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);

            conexion.Close();

            return tabla;
        }


        public void InsertandoTipoCambio(E_TipoCambio tipoCambio)
        {
            SqlCommand cmd = new SqlCommand("ins_tipo_cambio", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@HORA", tipoCambio.FEC_CAMBIO);
            cmd.Parameters.AddWithValue("@COMPRA", tipoCambio.COMPR_CAMBIO);
            cmd.Parameters.AddWithValue("@VENTA", tipoCambio.VENTA_CAMBIO);
            cmd.Parameters.AddWithValue("@SBS", tipoCambio.PROMEDIO_CAMBIO);
            cmd.Parameters.AddWithValue("@USER", tipoCambio.COD_USER);
            cmd.Parameters.AddWithValue("@COMPRA1", tipoCambio.SUNAT_COMPRA);
            cmd.Parameters.AddWithValue("@VENTA1", tipoCambio.SUNAT_VENTA);
            cmd.Parameters.AddWithValue("@sunat", tipoCambio.SUNAT_PROMEDIO);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        

        public void EditarTipoCambio(E_TipoCambio tipoCambio)
        {
            SqlCommand cmd = new SqlCommand("ins_tipo_cambio", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@HORA", tipoCambio.FEC_CAMBIO);
            cmd.Parameters.AddWithValue("@COMPRA", tipoCambio.COMPR_CAMBIO);
            cmd.Parameters.AddWithValue("@VENTA", tipoCambio.VENTA_CAMBIO);
            cmd.Parameters.AddWithValue("@SBS", tipoCambio.PROMEDIO_CAMBIO);
            cmd.Parameters.AddWithValue("@USER", tipoCambio.COD_USER);
            cmd.Parameters.AddWithValue("@COMPRA1", tipoCambio.SUNAT_COMPRA);
            cmd.Parameters.AddWithValue("@VENTA1", tipoCambio.SUNAT_VENTA);
            cmd.Parameters.AddWithValue("@sunat", tipoCambio.SUNAT_PROMEDIO);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        

    }
}
