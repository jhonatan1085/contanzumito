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
    public class D_Agencias
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Agencias> ListarAgencias(String buscar, String tipobusqueda)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCAAGENCIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            cmd.Parameters.AddWithValue("@TIPOBUSQUEDA", tipobusqueda);
            LeerFilas = cmd.ExecuteReader();

            List<E_Agencias> Listar = new List<E_Agencias>();

            while (LeerFilas.Read())
            {
                Listar.Add(new E_Agencias
                {
                    COD_COOP = LeerFilas.GetString(0),
                    COD_AGE_DESTINO = LeerFilas.GetString(1),
                    NOM_AGE = LeerFilas.GetString(2),
                    //NRO_CUENTA = Convert.ToInt32( LeerFilas.GetString(3)),
                    DIRECCION = LeerFilas.GetString(4),
                     //DATE_ACT = LeerFilas.GetString(5),
                    EMAIL = LeerFilas.GetString(6),
                   STD_AGE = Convert.ToChar( LeerFilas.GetString(7)),
                    EXONERA_IGV = Convert.ToChar(LeerFilas.GetString(8)),
                    COD_CTA = LeerFilas.GetString(9),
                    COD_CTA_H = LeerFilas.GetString(10),
                    CIUDAD = LeerFilas.GetString(11),
                    COD_CTA_ING = LeerFilas.GetString(12),
                    COD_CTA_EGR = LeerFilas.GetString(13),
                    CTA_GTOS_COMP_D = LeerFilas.GetString(14),
                    CTA_GTOS_COMP_H = LeerFilas.GetString(15),
                    INTEGRADA = Convert.ToChar(LeerFilas.GetString(16)),
                    CREDITOFISCAL = Convert.ToChar(LeerFilas.GetString(17))

                });
            }

            conexion.Close();
            LeerFilas.Close();
            return Listar;
        }

        public DataTable BuscaGastoCompartido(string periodo,string mes, decimal monto)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("SEL_GASTO_COMPARTIDO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@PERIODO", periodo);
            cmd.Parameters.AddWithValue("@MES", mes);
            cmd.Parameters.AddWithValue("@MONTO", monto);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);

            conexion.Close();

            return tabla;
        }

    }
}
