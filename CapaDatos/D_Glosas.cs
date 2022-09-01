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
    public class D_Glosas
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public bool BuscaGlosas (E_Glosas Glosas)
        {

            try
            {
                DataTable tabla = new DataTable();
                SqlDataReader LeerFilas;
                SqlCommand cmd = new SqlCommand("SEL_GLOSAS", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();

                cmd.Parameters.AddWithValue("@tipo_asiento", Glosas.TIPO_ASIENTO);
                cmd.Parameters.AddWithValue("@nro_asiento", Glosas.NRO_ASIENTO);
                cmd.Parameters.AddWithValue("@periodo", Glosas.PERIODO);
                cmd.Parameters.AddWithValue("@mes", Glosas.MES);
                cmd.Parameters.AddWithValue("@fecha", "");

                LeerFilas = cmd.ExecuteReader();
                tabla.Load(LeerFilas);

                LeerFilas.Close();
                conexion.Close();

                if (tabla.Rows.Count == 0)
                {
                    return false;
                }
                else
                {
                    Variables.nroAsiento = Convert.ToInt32(Glosas.NRO_ASIENTO);
                    Variables.tipoasiento = Glosas.TIPO_ASIENTO;
                    Variables.periodo = Glosas.PERIODO;
                    Variables.mes = Glosas.MES;
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            

        }

        public DataSet DetalleGlosas(E_Movi movi)
        {
          
            //  SqlConnection sqlConn = new SqlConnection(conexion);
            //SqlCommand es utilizado para ejecutar los comandos SQL
                SqlCommand cmd = new SqlCommand("SEL_GLOSAS", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();


                cmd.Parameters.AddWithValue("@tipo_asiento", movi.TIPO_ASIENTO);
                cmd.Parameters.AddWithValue("@nro_asiento", movi.NRO_ASIENTO);
                cmd.Parameters.AddWithValue("@periodo", movi.PERIODO);
                cmd.Parameters.AddWithValue("@mes", movi.MES);
                cmd.Parameters.AddWithValue("@fecha", "");

            // 'Se le define el tiempo de espera en segundos para la consulta,
            //'el valor default es 30 segundos.
            cmd.CommandTimeout = 9600;

            //'SqlAdapter utiliza el SqlCommand para llenar el Dataset
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                // 'Se llena el dataset
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds;
                
        }
    }
}
