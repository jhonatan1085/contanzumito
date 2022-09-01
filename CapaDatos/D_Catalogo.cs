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
    
    public class D_Catalogo
    {

        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Catalogo> ListarCatalogo(String buscar, String tipobusqueda)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCACATALOGO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            cmd.Parameters.AddWithValue("@TIPOBUSQUEDA", tipobusqueda);
            LeerFilas = cmd.ExecuteReader();

            List<E_Catalogo> Listar = new List<E_Catalogo>();

            while (LeerFilas.Read())
            {
                Listar.Add(new E_Catalogo
                {
                            COD_CTA= LeerFilas.GetString(0),
                    NOM_CTA = LeerFilas.GetString(1),
                    NIVEL_CTA = LeerFilas.GetString(2),
                    TIPO_CTA = LeerFilas.GetString(3),
                    TIPO_BAL = LeerFilas.GetString(4),
                    TIPO_SALDO = LeerFilas.GetString(5),
                    MONEDA = LeerFilas.GetString(6),
                    ESTADO = LeerFilas.GetString(7),
                    RELACION = LeerFilas.GetString(8),
                    TIPO_PRESUP = LeerFilas.GetString(9),
                    MIGRA = LeerFilas.GetString(10),
                    CENTRO_COSTO = LeerFilas.GetString(11),
                   // DATE_ACT = Convert.ToDateTime( LeerFilas.GetString(12)),
                    COD_CTA_EQUI = LeerFilas.GetString(13)

                });
            }

            conexion.Close();
            LeerFilas.Close();
            return Listar;
        }


        public DataTable BuscarCatalogo(E_Catalogo catalogo)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_BUSCACATALOGO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", catalogo.Buscar );
            cmd.Parameters.AddWithValue("@TIPOBUSQUEDA", catalogo.TipoBusqueda);
           

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);

            conexion.Close();

            return tabla;
        }


        public void seleccionaCuenta(E_Catalogo Catalogo)
        {
            Variables.cod_cta = Catalogo.COD_CTA;
            Variables.nom_cta = Catalogo.NOM_CTA;
        }


    }
}
