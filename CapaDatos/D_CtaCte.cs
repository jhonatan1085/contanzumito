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
    public class D_CtaCte
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_CtaCte> ListarCtaCte(E_CtaCte CtaCte)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCACTACTE", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@COD_BANCO", CtaCte.COD_BANCO);
          
            LeerFilas = cmd.ExecuteReader();

            List<E_CtaCte> Listar = new List<E_CtaCte>();

            while (LeerFilas.Read())
            {
                Listar.Add(new E_CtaCte
                {
                    COD_BANCO = LeerFilas.GetString(0),
                    NRO_CTACTE = LeerFilas.GetString(1),
                    COD_CTA = LeerFilas.GetString(2),
                    CHEQUERA = LeerFilas.GetString(3),
                    TIPO_CTA = LeerFilas.GetString(4),
                    CTA_ESTADO = LeerFilas.GetString(5)
                    
                });
            }

            conexion.Close();
            LeerFilas.Close();
            return Listar;
        }
    }
}
