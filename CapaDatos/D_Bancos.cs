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
   public  class D_Bancos
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Bancos> ListarBancos(String buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCABANCOS", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
           
            LeerFilas = cmd.ExecuteReader();

            List<E_Bancos> Listar = new List<E_Bancos>();

            while (LeerFilas.Read())
            {
                Listar.Add(new E_Bancos
                {
                    COD_BANCO = LeerFilas.GetString(0),
                    NOM_BANCO = LeerFilas.GetString(1),

                });
            }

            conexion.Close();
            LeerFilas.Close();
            return Listar;
        }

    }
}
